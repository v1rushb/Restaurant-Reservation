using RestaurantReservation.Db.Entities;

namespace RestaurantReservation.Db.Service.Interfaces
{
    public interface ICustomerService : IService<Customer>
    {
        Task<List<Customer>> GetCustomerWithPartySizeGreaterThanValue(int Value, int page, int pageSize);
    }
}
