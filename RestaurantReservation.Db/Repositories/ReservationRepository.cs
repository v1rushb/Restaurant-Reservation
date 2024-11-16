using RestaurantReservation.Db.Entities;
using RestaurantReservation.Db.Repositories.interfaces;

namespace RestaurantReservation.Db.Repositories
{
    public class ReservationRepository : IReservationRepository
    {
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

        Task<Reservation> IRepository<Reservation>.GetByIdAsync(Reservation entity)
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