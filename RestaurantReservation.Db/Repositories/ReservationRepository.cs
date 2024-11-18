using Microsoft.EntityFrameworkCore;
using RestaurantReservation.Db.Entities;
using RestaurantReservation.Db.Repositories.interfaces;

namespace RestaurantReservation.Db.Repositories
{
    public class ReservationRepository : IReservationRepository
    {
        private readonly RestaurantReservationDbContext _context;

        public ReservationRepository(RestaurantReservationDbContext context)
        {
            _context = context;
            _context.Database.EnsureCreatedAsync().Wait();
        }

        public async Task<int> CreateAsync(Reservation newReservation)
        {
            var reservation = await _context.Reservations.AddAsync(newReservation);
            return reservation.Entity.ReservationId;
        }

        public async Task DeleteAsync(int Id)
        {
            var reservation = await GetByIdAsync(Id);
            _context.Reservations.Remove(reservation);
            await _context.SaveChangesAsync();
        }

        public async Task<List<Reservation>> GetAllAsync()
        {
            return await _context.Reservations.ToListAsync();
        }

        public async Task<Reservation> GetByIdAsync(int Id)
        {
            var reservation = await _context.Reservations
                    .SingleOrDefaultAsync(reservation => reservation.ReservationId == Id);
            return reservation;
        }

        Task<int> IRepository<Reservation>.GetCountAsync()
        {
            throw new NotImplementedException();
        }

        public async Task UpdateAsync(Reservation updatedReservation)
        {
            _context.Reservations.Update(updatedReservation);
            await _context.SaveChangesAsync();
        }

        public async Task<List<Reservation>> GetReservationsByCustomerAsync(int CustomerId)
        {
            return await _context.Reservations
                    .Where(reservation => reservation.CustomerId.Equals(CustomerId))
                    .OrderBy(reservation => reservation.ReservationDate)
                    .ToListAsync();
        }

        public async Task<List<Order>> ListOrdersAndMenuItemsByReservationAsync(int ReservationId)
        {
            return await _context.Reservations
                    .Where(reservation => reservation.ReservationId == ReservationId)
                    .SelectMany(reservation => reservation.Orders)
                    .Include(order => order.OrderItems)
                    .ThenInclude(orderItem => orderItem.MenuItem)
                    .ToListAsync();
        }

        public async Task<List<MenuItem>> ListOrderedMenuItemsAsync(int ReservationId)
        {
            return await _context.Reservations
                    .Where(reservation => reservation.ReservationId == ReservationId)
                    .SelectMany(reservation => reservation.Orders)
                    .SelectMany(order => order.OrderItems)
                    .Select(orderItem => orderItem.MenuItem)
                    .ToListAsync();
        }
    } 
}