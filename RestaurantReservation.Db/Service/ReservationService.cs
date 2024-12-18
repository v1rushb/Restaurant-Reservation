using RestaurantReservation.Db.Entities;
using RestaurantReservation.Db.Repositories.interfaces;
using RestaurantReservation.Db.Service.Interfaces;
using RestaurantReservation.Db.Utilities;
using RestaurantReservation.Db.Utilities.Models;

namespace RestaurantReservation.Db.Service
{
    public class ReservationService : IReservationsService
    {
        private readonly IReservationRepository _reservationRepository;
        private readonly PaginationMetadataGenerator<Reservation> _paginationMetadataGenerator = new();


        public ReservationService(IReservationRepository reservationRepository)
        {
            _reservationRepository = reservationRepository;
        }
        
        public async Task<Reservation> CreateAsync(Reservation newReservation)
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

        public async Task<(List<Reservation>, Meta)> GetAllAsync(int page, int pageSize)
        {
            var reservations = await _reservationRepository.GetAllAsync(page, pageSize);
            var metadata = _paginationMetadataGenerator.GetGeneratedMetadata(reservations, page, pageSize);
                
            return (reservations, metadata);
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
