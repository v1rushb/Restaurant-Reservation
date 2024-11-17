using RestaurantReservation.Db.Entities;
using RestaurantReservation.Db.Repositories.interfaces;

namespace RestaurantReservation.Db.Repositories
{
    public class RestaurantRepository : IRestaurantRepository
    {
        private readonly RestaurantReservationDbContext _context;

        public RestaurantRepository(RestaurantReservationDbContext context)
        {
            _context = context;
            _context.Database.EnsureCreatedAsync().Wait();
        }

        Task<int> IRepository<Restaurant>.CreateAsync(Restaurant entity)
        {
            throw new NotImplementedException();
        }

        Task IRepository<Restaurant>.DeleteAsync(int Id)
        {
            throw new NotImplementedException();
        }

        Task<List<Restaurant>> IRepository<Restaurant>.GetAllAsync(Restaurant entity)
        {
            throw new NotImplementedException();
        }

        Task<Restaurant> IRepository<Restaurant>.GetByIdAsync(int Id)
        {
            throw new NotImplementedException();
        }

        Task<int> IRepository<Restaurant>.GetCountAsync()
        {
            throw new NotImplementedException();
        }

        Task IRepository<Restaurant>.UpdateAsync(Restaurant entity)
        {
            throw new NotImplementedException();
        }
    }
}