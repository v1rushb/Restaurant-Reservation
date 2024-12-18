using AutoMapper;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using RestaurantReservation.API.Models;
using RestaurantReservation.API.Utilities;
using RestaurantReservation.Db.Entities;
using RestaurantReservation.Db.Service.Interfaces;

namespace RestaurantReservation.API.Controllers
{
    [Route("/api/employees")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeService _employeeService;
        private readonly IMapper _mapper;
        private IValidator<EmployeeWithoutIdDTO> _employeeValidator;
        public EmployeeController(
            IEmployeeService employeeService,
            IMapper mapper,
            IValidator<EmployeeWithoutIdDTO> employeeValidator)
        {
            _employeeService = employeeService ??
                throw new ArgumentNullException(nameof(employeeService));
            _mapper = mapper ??
                throw new ArgumentNullException(nameof(mapper));
            _employeeValidator = employeeValidator ??
                throw new ArgumentNullException(nameof(employeeValidator));
        }

        [HttpGet]
        public async Task<IActionResult> GetEmployeesAsync([FromQuery] int page = 1, [FromQuery] int pageSize = 10)
        {

            var (employees, metadata) = await _employeeService.GetAllAsync(page, pageSize);

            var employeeDtos = _mapper.Map<List<CustomerDTO>>(employees);
            return Ok(ApiResponseHelper.CreateSuccessResponse(employeeDtos, metadata)); 
        }

        [HttpGet("{employeeId}")]
        public async Task<IActionResult> GetEmployeeAsync([FromQuery] int employeeId)
        {
            try
            {
                var employee = await _employeeService.GetByIdAsync(employeeId);
                var employeeDto = _mapper.Map<EmployeeDTO>(employee);

                return Ok(ApiResponseHelper.CreateSuccessResponse(employeeDto));
            }
            catch (KeyNotFoundException)
            {
                return NotFound(ApiResponseHelper.CreateErrorResponse<EmployeeDTO>(
                    new List<ValidationResultDTO>
                    {
                        new ValidationResultDTO { ErrorMessage = $"Customer with ID {employeeId} was not found." }
                    }));    
            }
        }

        [HttpPost]
        public async Task<IActionResult> CreateEmployeeAsync(EmployeeWithoutIdDTO newEmployee)
        {
            var validationResult = await _employeeValidator.ValidateAsync(newEmployee);

            if(!validationResult.IsValid)
            {
                return BadRequest(ApiResponseHelper.CreateErrorResponse<EmployeeDTO>(
                    validationResult.Errors.Select(err => new ValidationResultDTO
                    {
                        ErrorMessage = err.ErrorMessage,
                        PropertyName = err.PropertyName,
                        AttemptedValue = err.AttemptedValue?.ToString()
                    }).ToList()));
            }

            var newEmployeeId = await _employeeService.CreateAsync(_mapper.Map<Employee>(newEmployee));

            var responseCustomer = _mapper.Map<Employee>(newEmployee);
            responseCustomer.EmployeeId = newEmployeeId;

            return Created($"api/customer/{newEmployeeId}", ApiResponseHelper.CreateSuccessResponse(responseCustomer));
        }

        [HttpPut("{employeeId}")]
        public async Task<IActionResult> UpdateEmployeeAsync(
            int employeeId,
            EmployeeWithoutIdDTO updatedEmployee)
        {
            var validationResult = await _employeeValidator.ValidateAsync(updatedEmployee);

            if(!validationResult.IsValid)
            {
                return BadRequest(ApiResponseHelper.CreateErrorResponse<EmployeeDTO>(
                    validationResult.Errors.Select(err => new ValidationResultDTO
                    {
                        ErrorMessage = err.ErrorMessage,
                        PropertyName = err.PropertyName,
                        AttemptedValue = err.AttemptedValue?.ToString()
                    }).ToList()));
            }

            var updatedEmployeeWithId = _mapper.Map<Employee>(updatedEmployee);
            updatedEmployeeWithId.EmployeeId = employeeId;

            try
            {
                await _employeeService.UpdateAsync(updatedEmployeeWithId); //validate later for exceptions.
                return NoContent();
            }
            catch(KeyNotFoundException)
            {
                return NotFound(ApiResponseHelper.CreateErrorResponse<EmployeeDTO>(
                    new List<ValidationResultDTO>
                    {
                        new ValidationResultDTO { ErrorMessage = $"Customer with ID {employeeId} was not found." }
                    }));
            }
        }

        [HttpDelete("{employeeId}")]
        public async Task<IActionResult> DeleteCustomerAsync(int employeeId)
        {
            try
            {
                await _employeeService.DeleteAsync(employeeId);
                return NoContent();
            }
            catch (KeyNotFoundException)
            {
                 return NotFound(ApiResponseHelper.CreateErrorResponse<string>(
                    new List<ValidationResultDTO>
                    {
                        new ValidationResultDTO { ErrorMessage = $"Customer with ID {employeeId} was not found." }
                    }));
            }
        }

    }
}