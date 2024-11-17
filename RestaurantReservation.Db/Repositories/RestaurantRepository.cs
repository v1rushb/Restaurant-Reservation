using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Migrations.Operations;
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

        public async Task<int> CreateAsync(Restaurant newRestaurant)
        {
            var restaruant = await _context.Restaurants.AddAsync(newRestaurant);
            return restaruant.Entity.RestaurantId;
        }

        Task IRepository<Restaurant>.DeleteAsync(int Id)
        {
            throw new NotImplementedException();
        }

        public async Task<List<Restaurant>> GetAllAsync()
        {
            return await _context.Restaurants.ToListAsync();
        }

        public async Task<Restaurant> GetByIdAsync(int Id)
        {
            var restaurant = await _context.Restaurants
                    .SingleOrDefaultAsync(restaurant => restaurant.RestaurantId == Id);
            return restaurant;
        }

        Task<int> IRepository<Restaurant>.GetCountAsync()
        {
            throw new NotImplementedException();
        }

        public async Task UpdateAsync(Restaurant newRestaurant)
        {
            _context.Restaurants.Update(newRestaurant);
            await _context.SaveChangesAsync();
        }
    }
}