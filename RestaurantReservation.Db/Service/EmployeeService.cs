using RestaurantReservation.Db.Entities;
using RestaurantReservation.Db.Repositories.interfaces;
using RestaurantReservation.Db.Service.Interfaces;
using RestaurantReservation.Db.Utilities;
using RestaurantReservation.Db.Utilities.Models;

namespace RestaurantReservation.Db.Service
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IEmployeeRepository _employeeRepository;
        private readonly PaginationMetadataGenerator<Employee> _paginationMetadataGenerator = new();

        
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

        public async Task<(List<Employee>, Meta)> GetAllAsync(int page, int pageSize)
        {
            var employees = await _employeeRepository.GetAllAsync(page, pageSize);
            var metadata = _paginationMetadataGenerator.GetGeneratedMetadata(employees, page, pageSize);
                
            return (employees, metadata);
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