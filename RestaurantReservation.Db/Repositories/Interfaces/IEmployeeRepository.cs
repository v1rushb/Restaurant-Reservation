using RestaurantReservation.Db.Entities;

namespace RestaurantReservation.Db.Repositories.interfaces
{
    public interface IEmployeeRepository : IRepository<Employee>
    {
        Task<List<Employee>> ListManagersAsync();
        Task<decimal> CalcualteAverageOrderAmountAsync(int EmployeeId);
    }
}