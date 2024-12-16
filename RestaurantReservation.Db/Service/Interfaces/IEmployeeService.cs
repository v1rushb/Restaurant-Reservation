using RestaurantReservation.Db.Entities;

namespace RestaurantReservationCore.Service.Interfaces
{
    public interface IEmployeeService : IService<Employee>
    {
        Task<List<Employee>> ListManagersAsync();
    }
}
