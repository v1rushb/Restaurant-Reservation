namespace RestaurantReservationCore.Service
{
    public class IReservationsService
    {
        Task<List<Reservation> GetReservationsByCustomerAsync(int CustomerId);
        Task<List<Order>> ListOrdersAndMenuItemsByReservationAsync(int ReservationId);
        Task<List<MenuItem>> ListOrderedMenuItemsAsync(int ReservationId);
    }
}
