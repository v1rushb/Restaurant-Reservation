using RestaurantReservation.Db.Repositories.interfaces;

namespace RestaurantReservation.Db.Repositories
{
    public class MenuItem : IMenuItemRepository
    {
        private readonly RestaurantReservationDbContext _context;
        public MenuItem(RestaurantReservationDbContext context)
        {
            _context = context;
            _context.Database.EnsureCreatedAsync().Wait();
        }

        Task<int> IRepository<MenuItem>.CreateAsync(MenuItem entity)
        {
            throw new NotImplementedException();
        }

        Task IRepository<MenuItem>.DeleteAsync(int Id)
        {
            throw new NotImplementedException();
        }

        Task<List<MenuItem>> IRepository<MenuItem>.GetAllAsync(MenuItem entity)
        {
            throw new NotImplementedException();
        }

        Task<MenuItem> IRepository<MenuItem>.GetByIdAsync(MenuItem entity)
        {
            throw new NotImplementedException();
        }

        Task<int> IRepository<MenuItem>.GetCountAsync()
        {
            throw new NotImplementedException();
        }

        Task IRepository<MenuItem>.UpdateAsync(MenuItem entity)
        {
            throw new NotImplementedException();
        }
    }
}