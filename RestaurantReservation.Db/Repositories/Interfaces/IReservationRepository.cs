using RestaurantReservation.Db.Entities;

namespace RestaurantReservation.Db.Repositories.interfaces
{
    public interface IReservationRepository : IRepository<Reservation>
    {
        Task<List<Reservation>> GetReservationsByCustomerAsync(int CustomerId);
        Task<List<Order>> ListOrdersAndMenuItemsByReservationAsync(int ReservationId);

        Task<List<MenuItem>> ListOrderedMenuItemsAsync(int ReservationId);
    }
}