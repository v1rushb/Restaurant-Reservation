using Microsoft.EntityFrameworkCore;
using RestaurantReservation.Db.Entities;
using RestaurantReservation.Db.Extensions;
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

        public async Task<Employee> CreateAsync(Employee newEmployee)
        {
            var employee = await _context.Employees.AddAsync(newEmployee);
            await _context.SaveChangesAsync();
            return employee.Entity;
        }

        public async Task DeleteAsync(int Id)
        {
            var employee = await GetByIdAsync(Id);
            _context.Employees.Remove(employee);
            await _context.SaveChangesAsync();
        }

        public async Task<List<Employee>> GetAllAsync(int page, int pageSize)
        {
            return await _context
                .Employees
                .PaginateAsync(page, pageSize);
        }

        public async Task<Employee> GetByIdAsync(int Id)
        {
            var employee = await _context.Employees
                        .SingleOrDefaultAsync(employee => employee.EmployeeId == Id);
            if(employee == null)
                throw new KeyNotFoundException("Not found.");
            return employee;
        }

        Task<int> IRepository<Employee>.GetCountAsync()
        {
            throw new NotImplementedException();
        }

        public async Task UpdateAsync(Employee updatedEmployee)
        {
            _context.Employees.Update(updatedEmployee);
            await _context.SaveChangesAsync();
        }

        public async Task<List<Employee>> ListManagersAsync() 
        {
            return await _context.Employees
                    .Where(employee => employee.Position.Equals("Manager"))
                    .OrderBy(employee => employee.FirstName)
                    .ThenBy(employee => employee.LastName)
                    .ToListAsync();
        }
        public async Task<bool> ExistsAsync(int Id) =>
            await _context.Employees.AnyAsync(employee => employee.EmployeeId.Equals(Id));
    }
}