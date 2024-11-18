using Microsoft.EntityFrameworkCore;
using RestaurantReservation.Db.Entities;
using RestaurantReservation.Db.Repositories.interfaces;

namespace RestaurantReservation.Db.Repositories
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly RestaurantReservationDbContext _context;

        public CustomerRepository(RestaurantReservationDbContext context)
        {
            _context = context;
            _context.Database.EnsureCreatedAsync().Wait();
        }

        public async Task<int> CreateAsync(Customer newCustomer)
        {
            var customer = await _context.Customers.AddAsync(newCustomer);
            return customer.Entity.CustomerId;
        }

        public async Task DeleteAsync(int Id)
        {
            var customer = await GetByIdAsync(Id);
            _context.Customers.Remove(customer);
            await _context.SaveChangesAsync();
        }

        public async Task<List<Customer>> GetAllAsync()
        {
            return await _context.Customers.ToListAsync();
        }

        public async Task<Customer> GetByIdAsync(int Id)
        {
            var customer = await _context.Customers
                    .SingleOrDefaultAsync(customer => customer.CustomerId == Id);
                if(customer == null) 
                {
                    // do a CEH here
                    throw new Exception("Yoink");
                }
                return customer;
        }

        public Task<int> GetCountAsync()
        {
            throw new NotImplementedException();
        }

        public Task<List<Customer>> GetCustomersWithPartySizeGreaterThanValueAsync(int value)
        {
            throw new NotImplementedException();
        }

        public async Task UpdateAsync(Customer updatedCustomer)
        {
            _context.Customers.Update(updatedCustomer);
            await _context.SaveChangesAsync();
        }

        public async Task<List<Customer>> GetCustomersWithPartySizeGreateThanValueAsync(int value)
        {
            return await _context.Customers
                        .FromSqlInterpolated($"EXEC GetCustomerWithPartySizeGreateThanValue {value}")
                        .ToListAsync();
        }
    }
}