using RestaurantReservation.Db.Entities;
using RestaurantReservation.Db.Repositories.interfaces;
using RestaurantReservationCore.Service;

namespace RestaurantReservation.Service
{
    public class CustomerService : ICustomerService
    {
        private readonly ICustomerRepository _customerRepository;

        public CustomerService(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }
        
        public async Task<int> CreateAsync(Customer newCustomer)
        {
            return await _customerRepository.CreateAsync(newCustomer);
        }

        public async Task UpdateAsync(Customer updatedCustomer)
        {
            await _customerRepository.UpdateAsync(updatedCustomer);
        }

        public async Task DeleteAsync(int customerId)
        {
            await _customerRepository.DeleteAsync(customerId);
        }

        public async Task<Customer> GetByIdAsync(int customerId)
        {
            return await _customerRepository.GetByIdAsync(customerId);
        }

        public async Task<List<Customer>> GetAllAsync()
        {
            return await _customerRepository.GetAllAsync();
        }

        public async Task<List<Customer>> GetCustomerWithPartySizeGreaterThanValue(int value)
        {
            return await _customerRepository.GetCustomersWithPartySizeGreaterThanValueAsync(value);
        }
    }
}
