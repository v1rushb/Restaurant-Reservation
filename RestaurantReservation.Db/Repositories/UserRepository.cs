using RestaurantReservation.Db.Entities;
using RestaurantReservation.Db.Repositories.interfaces;

namespace RestaurantReservation.Db.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly RestaurantReservationDbContext _context;
        
        public UserRepository(RestaurantReservationDbContext context)
        {
            _context = context;
            _context.Database.EnsureCreatedAsync().Wait();
        }

        Task<int> IRepository<User>.CreateAsync(User entity)
        {
            throw new NotImplementedException();
        }

        Task IRepository<User>.DeleteAsync(int Id)
        {
            throw new NotImplementedException();
        }

        Task<List<User>> IRepository<User>.GetAllAsync(User entity)
        {
            throw new NotImplementedException();
        }

        Task<User> IRepository<User>.GetByIdAsync(User entity)
        {
            throw new NotImplementedException();
        }

        Task<int> IRepository<User>.GetCountAsync()
        {
            throw new NotImplementedException();
        }

        Task IRepository<User>.UpdateAsync(User entity)
        {
            throw new NotImplementedException();
        }
    }
}
