using RestaurantReservation.Db.Entities;

namespace RestaurantReservationCore.Service
{
    public interface ICustomerService : IService<Customer>
    {
        Task<List<Customer>> GetCustomerWithPartySizeGreaterThanValue(int Value);
    }
}
