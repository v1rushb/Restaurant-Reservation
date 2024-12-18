using System.ComponentModel.DataAnnotations;
using AutoMapper;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using RestaurantReservation.API.Common;
using RestaurantReservation.API.Extensions;
using RestaurantReservation.API.Models;
using RestaurantReservation.API.Services;
using RestaurantReservation.API.Utilities;
using RestaurantReservation.Db.Entities;
using RestaurantReservation.Db.Service.Interfaces;

namespace RestaurantReservation.API.Controllers
{
    [Route("api/customers")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerService _customerService;
        private readonly IMapper _mapper;
        private IValidator<CustomerWithoutIdDTO> _customerValidator;

        public CustomerController(
            ICustomerService customerService,
            IMapper mapper,
            IValidator<CustomerWithoutIdDTO> customerValidator)
        {
            _customerService = customerService ??
                throw new ArgumentNullException(nameof(customerService));
            _mapper = mapper ??
                throw new ArgumentNullException(nameof(mapper));
            _customerValidator = customerValidator ??
                throw new ArgumentNullException(nameof(customerValidator));
        }

        [HttpGet]
        public async Task<IActionResult> GetCustomersAsync([FromQuery] int page = 1, [FromQuery] int pageSize = 10)
        {

            var (customers, metadata) = await _customerService.GetAllAsync(page, pageSize);

            var customerDtos = _mapper.Map<List<CustomerDTO>>(customers);
            return Ok(ApiResponseHelper.CreateSuccessResponse(customerDtos, metadata)); 
        }

        [HttpGet("{customerId}")]
        public async Task<IActionResult> GetCustomerAsync([FromQuery] int customerId)
        {
            try
            {
                var customer = await _customerService.GetByIdAsync(customerId);
                var customerDto = _mapper.Map<CustomerDTO>(customer);

                return Ok(ApiResponseHelper.CreateSuccessResponse(customerDto));
            }
            catch (KeyNotFoundException)
            {
                return NotFound(ApiResponseHelper.CreateErrorResponse<CustomerDTO>(
                    new List<ValidationResultDTO>
                    {
                        new ValidationResultDTO { ErrorMessage = $"Customer with ID {customerId} was not found." }
                    }));    
            }
        }

        [HttpPost]
        public async Task<IActionResult> CreateCustomerAsync(CustomerWithoutIdDTO newCustomer)
        {
            var validationResult = await _customerValidator.ValidateAsync(newCustomer);

            if(!validationResult.IsValid)
            {
                return BadRequest(ApiResponseHelper.CreateErrorResponse<CustomerDTO>(
                    validationResult.Errors.Select(e => new ValidationResultDTO
                    {
                        ErrorMessage = e.ErrorMessage,
                        PropertyName = e.PropertyName,
                        AttemptedValue = e.AttemptedValue?.ToString()
                    }).ToList()));
            }

            var newCustomerId = await _customerService.CreateAsync(_mapper.Map<Customer>(newCustomer));

            var responseCustomer = _mapper.Map<Customer>(newCustomer);
            responseCustomer.CustomerId = newCustomerId;

            return Created($"api/customer/{newCustomerId}", ApiResponseHelper.CreateSuccessResponse(responseCustomer));
        }


        [HttpPut("{customerId}")]
        public async Task<IActionResult> UpdateCustomerAsync(
            int customerId,
            CustomerWithoutIdDTO updatedCustomer)
        {
            var validationResult = await _customerValidator.ValidateAsync(updatedCustomer);

            if(!validationResult.IsValid)
            {
                return BadRequest(ApiResponseHelper.CreateErrorResponse<CustomerDTO>(
                    validationResult.Errors.Select(e => new ValidationResultDTO
                    {
                        ErrorMessage = e.ErrorMessage,
                        PropertyName = e.PropertyName,
                        AttemptedValue = e.AttemptedValue?.ToString()
                    }).ToList()));
            }

            var updatedCustomerWithId = _mapper.Map<Customer>(updatedCustomer);
            updatedCustomerWithId.CustomerId = customerId;

            try
            {
                await _customerService.UpdateAsync(updatedCustomerWithId); //validate later for exceptions.
                return NoContent();
            }
            catch(KeyNotFoundException)
            {
                return NotFound(ApiResponseHelper.CreateErrorResponse<CustomerDTO>(
                    new List<ValidationResultDTO>
                    {
                        new ValidationResultDTO { ErrorMessage = $"Customer with ID {customerId} was not found." }
                    }));
            }
        }

        [HttpDelete("{customerId}")]
        public async Task<IActionResult> DeleteCustomerAsync(int customerId)
        {
            try
            {
                await _customerService.DeleteAsync(customerId);
                return NoContent();
            }
            catch (KeyNotFoundException)
            {
                 return NotFound(ApiResponseHelper.CreateErrorResponse<string>(
                    new List<ValidationResultDTO>
                    {
                        new ValidationResultDTO { ErrorMessage = $"Customer with ID {customerId} was not found." }
                    }));
            }
        }

    }
}