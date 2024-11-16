using RestaurantReservation.Db.Entities;

namespace RestaurantReservation.Db.Repositories.interfaces {
    public interface ICustomerRepository : IRepository<Customer>
    {
        Task<List<Customer>> GetCustomersWithPartySizeGreaterThanValueAsync(int value);
    }   
}