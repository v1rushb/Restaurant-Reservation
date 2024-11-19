using RestaurantReservation.Db.Entities;
using RestaurantReservation.Db.Repositories.interfaces;
using RestaurantReservationCore.Service.Interfaces;

namespace RestaurantReservationsCore.Service
{
    public class ReservationService : IReservationsService
    {
        private readonly IReservationRepository _reservationRepository;

        public ReservationService(IReservationRepository reservationRepository)
        {
            _reservationRepository = reservationRepository;
        }
        
        public async Task<int> CreateAsync(Reservation newReservation)
        {
            return await _reservationRepository.CreateAsync(newReservation);
        }

        public async Task UpdateAsync(Reservation updatedReservation)
        {
            await _reservationRepository.UpdateAsync(updatedReservation);
        }
        
        public async Task DeleteAsync(int reservationId)
        {
            await _reservationRepository.DeleteAsync(reservationId);
        }

        public async Task<Reservation> GetByIdAsync(int reservationId)
        {
            return await _reservationRepository.GetByIdAsync(reservationId);
        }

        public async Task<List<Reservation>> GetAllAsync()
        {
            return await _reservationRepository.GetAllAsync();
        }

        public async Task<List<Reservation>> GetReservationsByCustomerAsync(int customerId)
        {
            return await _reservationRepository.GetReservationsByCustomerAsync(customerId);
        }

        public async Task<List<Order>> ListOrdersAndMenuItemsByReservationAsync(int reservationId)
        {
            return await _reservationRepository.ListOrdersAndMenuItemsByReservationAsync(reservationId);
        }

        public async Task<List<MenuItem>> ListOrderedMenuItemsAsync(int reservationId)
        {
            return await _reservationRepository.ListOrderedMenuItemsAsync(reservationId);
        }
    }
}
