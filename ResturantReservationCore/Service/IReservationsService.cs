namespace RestaurantReservationsCore.Service
{
    public class ReservationService
    {
        private readonly ReservationService _reservationService;

        public ReserervationService(ReservationService reservationService)
        {
            _reservationService = reservationService;
        }
        
        public async Task<int> CreateAsync(Reservation newReservation)
        {
            return await _reservationService.CreateAsync(newReservation);
        }

        public async Task UpdateAsync(Reservation updatedReservation)
        {
            await _reservationService.UpdateAsync(updatedReservation);
        }
        
        public async Task DeleteAsync(int reservationId)
        {
            await _reservationService.DeleteAsync(reservationId);
        }

        public async Task<Reservation> GetByIdAsync(int reservationId)
        {
            return await _reservationService.GetByIdAsync(reservationId);
        }

        public async Task<List<Reservation>> GetAllAsync()
        {
            return await _reservationService.GetAllAsync();
        }

        public async Task<List<Reservation>> GetReservationsByCustomerAsync(int customerId)
        {
            return await _reservationService.GetReservationsByCustomerAsync(customerId);
        }

        public async Task<List<Order>> ListOrdersAndMenuItemsByReservationAsync(int reservationId)
        {
            return _reservationService.ListOrdersAndMenuItemsByReservationAsync(reservationId);
        }
    }
}
