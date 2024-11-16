using RestaurantReservation.Db.Entities;
using RestaurantReservation.Db.Repositories.interfaces;

namespace RestaurantReservation.Db.Repositories
{
    public class CustomerRepository : ICustomerRepository
    {
        public Task<int> CreateAsync(Customer entity)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(int Id)
        {
            throw new NotImplementedException();
        }

        public Task<List<Customer>> GetAllAsync(Customer entity)
        {
            throw new NotImplementedException();
        }

        public Task<Customer> GetByIdAsync(Customer entity)
        {
            throw new NotImplementedException();
        }

        public Task<int> GetCountAsync()
        {
            throw new NotImplementedException();
        }

        public Task<List<Customer>> GetCustomersWithPartySizeGreaterThanValueAsync(int value)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(Customer entity)
        {
            throw new NotImplementedException();
        }
    }
}