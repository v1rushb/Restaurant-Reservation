using RestaurantReservation.Db.Entities;

namespace RestaurantReservationCore.Service.Interfaces
{
    public interface  IReservationsService : IService<Reservation>
    {
        Task<List<Reservation>> GetReservationsByCustomerAsync(int CustomerId);
        Task<List<Order>> ListOrdersAndMenuItemsByReservationAsync(int ReservationId);
        Task<List<MenuItem>> ListOrderedMenuItemsAsync(int ReservationId);
    }
}
