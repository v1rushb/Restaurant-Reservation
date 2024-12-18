using RestaurantReservation.Db.Entities;
using RestaurantReservation.Db.Repositories.interfaces;
using RestaurantReservation.Db.Service.Interfaces;

namespace RestaurantReservation.Db.Service
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IEmployeeRepository _employeeRepository;
        
        public EmployeeService(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }
        public async Task<int> CreateAsync(Employee newEmployee)
        {
            return await _employeeRepository.CreateAsync(newEmployee);
        }

        public async Task DeleteAsync(int employeeId)
        {
            await _employeeRepository.DeleteAsync(employeeId);
        }

        public async Task<List<Employee>> GetAllAsync(int size, int pageSize)
        {
            return await _employeeRepository.GetAllAsync(size, pageSize);
        }

        public async Task<Employee> GetByIdAsync(int employeeId)
        {
            return await _employeeRepository.GetByIdAsync(employeeId);
        }

        public async Task<List<Employee>> ListManagersAsync()
        {
            return await _employeeRepository.ListManagersAsync();
        }

        public async Task UpdateAsync(Employee updatedEmployee)
        {
            await _employeeRepository.UpdateAsync(updatedEmployee);
        }
    }
}