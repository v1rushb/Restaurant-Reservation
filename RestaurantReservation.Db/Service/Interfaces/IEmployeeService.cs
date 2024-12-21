using RestaurantReservation.Db.Entities;

namespace RestaurantReservation.Db.Service.Interfaces
{
    public interface IEmployeeService : IService<Employee>
    {
        Task<List<Employee>> ListManagersAsync();
        Task<bool> EmployeeExistsAsync(int employeeId);
        Task<decimal> CalculateAverageOrderAmountAsync(int EmployeeId);
    }
}
