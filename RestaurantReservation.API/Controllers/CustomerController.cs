using AutoMapper;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using RestaurantReservation.API.Models;
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
        public async Task<IActionResult> Get()
        {
            var customers = await _customerService.GetAllAsync();
            return Ok(_mapper.Map<List<CustomerDTO>>(customers));
        }
    }
}