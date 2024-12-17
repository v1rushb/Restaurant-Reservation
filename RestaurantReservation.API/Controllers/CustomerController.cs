using AutoMapper;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using RestaurantReservation.API.Models;
using RestaurantReservation.Db.Entities;
using RestaurantReservation.Db.Service.Interfaces;

namespace RestaurantReservation.API.Controllers
{
    [Route("api/customers")]
    [ApiController]
    public class CustomerControllers : ControllerBase
    {
        private readonly ICustomerService _customerService;
        private readonly IMapper _mapper;

        public CustomerControllers(
            ICustomerService customerService,
            IMapper mapper)
        {
            _customerService = customerService ??
                throw new ArgumentNullException(nameof(customerService));
            _mapper = mapper ??
                throw new ArgumentNullException(nameof(mapper));
        }

        [HttpGet]
        public async Task<IActionResult> GetCustomersAsync()
        {
            var customers = await _customerService.GetAllAsync();
            return Ok(_mapper.Map<List<CustomerDTO>>(customers));
        }

        [HttpGet("{customerId}")]
        public async Task<IActionResult> GetCustomerAsync(int customerId)
        {
            try
            {
                var customer = await _customerService.GetByIdAsync(customerId);
                return Ok(_mapper.Map<CustomerDTO>(customer));
            }
            catch (KeyNotFoundException)
            {
                return NotFound();
            }
        }

        [HttpPost]
        public async Task<IActionResult> CreateCustomerAsync(CustomerWithoutIdDTO newCustomer)
        {
            var newCustomerId = await _customerService.CreateAsync(_mapper.Map<Customer>(newCustomer));

            var responseCustomer = _mapper.Map<Customer>(newCustomer);
            responseCustomer.CustomerId = newCustomerId;

            return Created($"api/customer/{newCustomerId}", responseCustomer);
        }
        [HttpPut("{customerId}")]
        public async Task<IActionResult> UpdateCustomerAsync(
            int customerId,
            CustomerWithoutIdDTO updatedCustomer)
        {
            var updatedCustomerWithId = _mapper.Map<Customer>(updatedCustomer);
            updatedCustomerWithId.CustomerId = customerId;

            try
            {
                await _customerService.UpdateAsync(updatedCustomerWithId); //validate later for exceptions.
            }
            catch(KeyNotFoundException)
            {
                return NotFound();
            }
            return NoContent();
        }

        public async Task<IActionResult> DeleteCustomerAsync(int customerId)
        {
            try
            {
                await _customerService.DeleteAsync(customerId);
            }
            catch (KeyNotFoundException)
            {
                return NotFound();
            }
            return NoContent();
        }

    }
}