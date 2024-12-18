using RestaurantReservation.Db.Entities;
using RestaurantReservation.Db.Repositories.interfaces;
using RestaurantReservation.Db.Service.Interfaces;
using RestaurantReservation.Db.Utilities;
using RestaurantReservation.Db.Utilities.Models;

namespace RestaurantReservation.Db.Service
{
    public class CustomerService : ICustomerService
    {
        private readonly ICustomerRepository _customerRepository;
        private readonly PaginationMetadataGenerator<Customer> _paginationMetadataGenerator;

        public CustomerService(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
            _paginationMetadataGenerator = new PaginationMetadataGenerator<Customer>();
        }
        
        public async Task<Customer> CreateAsync(Customer newCustomer)
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

        public async Task<(List<Customer>, Meta)> GetAllAsync(int page, int pageSize)
        {
            var customers = await _customerRepository.GetAllAsync(page, pageSize);
            var metadata = _paginationMetadataGenerator.GetGeneratedMetadata(customers, page, pageSize);
            
            return (customers, metadata);
        }

        public async Task<List<Customer>> GetCustomerWithPartySizeGreaterThanValue(int value, int page, int pageSize)
        {
            return await _customerRepository.GetCustomersWithPartySizeGreaterThanValueAsync(value, page, pageSize);
        }
    }
}
