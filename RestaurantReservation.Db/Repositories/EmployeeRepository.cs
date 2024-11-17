using Microsoft.EntityFrameworkCore;
using RestaurantReservation.Db.Entities;
using RestaurantReservation.Db.Repositories.interfaces;

namespace RestaurantReservation.Db.Repositories 
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly RestaurantReservationDbContext _context;

        public EmployeeRepository(RestaurantReservationDbContext context) {
            _context = context;
            _context.Database.EnsureCreatedAsync().Wait();
        }

        public async Task<int> CreateAsync(Employee newEmployee)
        {
            var employee = await _context.Employees.AddAsync(newEmployee);
            return employee.Entity.EmployeeId;
        }

        public async Task DeleteAsync(int Id)
        {
            var employee = await GetByIdAsync(Id);
            _context.Employees.Remove(employee);
            await _context.SaveChangesAsync();
            
        }

        public async Task<List<Employee>> GetAllAsync(Employee entity)
        {
            return await _context.Employees.ToListAsync();
        }

        public async Task<Employee> GetByIdAsync(int Id)
        {
            var employee = await _context.Employees
                        .SingleOrDefaultAsync(employee => employee.EmployeeId == Id);
            return employee;
        }

        Task<int> IRepository<Employee>.GetCountAsync()
        {
            throw new NotImplementedException();
        }

        Task IRepository<Employee>.UpdateAsync(Employee entity)
        {
            throw new NotImplementedException();
        }
    }
}