using RestaurantReservation.Db.Entities;
using RestaurantReservation.Db.Repositorie.interfaces;

namespace RestaurantReservation.Db.Repositories.interfaces {
    public interface ICustomerRepository : IRepository<Customer>
    {
        Task<List<Customer>> GetCustomersWithPartySizeGreaterThanValueAsync(int value);
    }   
}