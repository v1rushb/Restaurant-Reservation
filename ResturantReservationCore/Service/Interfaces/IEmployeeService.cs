namespace RestaurantReservationCore.Service
{
    public interface IEmployeeService : IService<Employee>
    {
        Task<List<Employee>> ListManagersAsync();
    }
}
