using AutoMapper;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using RestaurantReservation.API.Models;
using RestaurantReservation.API.Utilities;
using RestaurantReservation.Db.Service.Interfaces;

namespace RestaurantReservation.API.Controllers
{
    [Route("api/employees")]
    [ApiController]
    public class EmployeeOrderController : ControllerBase
    {
        private readonly IEmployeeService _employeeService;
        private readonly IConfiguration _config;
        private readonly IValidator<EmployeeWithoutIdDTO> _employeeValidator;
        private readonly IMapper _mapper;
        public EmployeeOrderController(
            IEmployeeService employeeService,
            IConfiguration config,
            IValidator<EmployeeWithoutIdDTO> employeeValidator,
            IMapper mapper)
        {
            _employeeService = employeeService; 
            _config = config;
            _employeeValidator = employeeValidator;
            _mapper = mapper;
        }

        [HttpGet("{employeeId}/average-order-amount")]
        public async Task<IActionResult> AverageOrderAmountForEmployee(int employeeId)
        {
            if(!await _employeeService.EmployeeExistsAsync(employeeId)) {
                return NotFound(ApiResponseHelper.CreateErrorResponse<string>(
                    new List<ValidationResultDTO>
                    {
                        new ValidationResultDTO { ErrorMessage = $"Employee with ID {employeeId} does not exist." }
                    }));
            }

            try
            {
                var averageOrderAmount = await _employeeService.CalculateAverageOrderAmountAsync(employeeId);

                var result = new
                {
                    EmployeeId = employeeId,
                    AverageOrderAmount = averageOrderAmount
                };

                return Ok(ApiResponseHelper.CreateSuccessResponse(result));
            }
             catch (Exception)
            {
                return StatusCode(500, ApiResponseHelper.CreateErrorResponse<string>(
                    new List<ValidationResultDTO>
                    {
                        new ValidationResultDTO { ErrorMessage = "An unexpected error occurred while processing the request." }
                    }));
            }
        }
    }
}