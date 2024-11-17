using System.Collections.ObjectModel;
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
        
        Task<int> IRepository<Reservation>.CreateAsync(Reservation entity)
        {
            throw new NotImplementedException();
        }

        Task IRepository<Reservation>.DeleteAsync(int Id)
        {
            throw new NotImplementedException();
        }

        Task<List<Reservation>> IRepository<Reservation>.GetAllAsync(Reservation entity)
        {
            throw new NotImplementedException();
        }

        Task<Reservation> IRepository<Reservation>.GetByIdAsync(int Id)
        {
            throw new NotImplementedException();
        }

        Task<int> IRepository<Reservation>.GetCountAsync()
        {
            throw new NotImplementedException();
        }

        Task IRepository<Reservation>.UpdateAsync(Reservation entity)
        {
            throw new NotImplementedException();
        }
    }
}