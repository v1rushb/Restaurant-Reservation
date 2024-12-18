using Microsoft.EntityFrameworkCore;
using RestaurantReservation.Db.Entities;
using RestaurantReservation.Db.Repositories.interfaces;

namespace RestaurantReservation.Db.Repositories
{
    public class MenuItemRepository : IMenuItemRepository
    {
        private readonly RestaurantReservationDbContext _context;
        public MenuItemRepository(RestaurantReservationDbContext context)
        {
            _context = context;
            _context.Database.EnsureCreatedAsync().Wait();
        }

        public async Task<MenuItem> CreateAsync(MenuItem newMenuItem)
        {
            var menuItem = await _context.MenuItems.AddAsync(newMenuItem);
            return menuItem.Entity;
        }

        public async Task DeleteAsync(int Id)
        {
            var menuItem = await GetByIdAsync(Id);
            _context.MenuItems.Remove(menuItem);
            await _context.SaveChangesAsync();
        }


        async Task<List<MenuItem>> GetAllAsync(int size, int pageSize)
        {
            return await _context.MenuItems.ToListAsync();
        }

        public async Task<MenuItem> GetByIdAsync(int Id)
        {
            var menuItem = await _context.MenuItems
                    .SingleOrDefaultAsync(menuItem => menuItem.MenuItemId == Id);
            return menuItem;
        }

        Task<int> IRepository<MenuItem>.GetCountAsync()
        {
            throw new NotImplementedException();
        }

        public async Task UpdateAsync(MenuItem updatedMenuItem)
        {
            _context.MenuItems.Update(updatedMenuItem);
            await _context.SaveChangesAsync();
        }

        public async Task<bool> ExistsAsync(int Id) =>
            await _context.MenuItems.AnyAsync(menuItems => menuItems.MenuItemId.Equals(Id));

        Task<List<MenuItem>> IRepository<MenuItem>.GetAllAsync(int size, int pageSize)
        {
            throw new NotImplementedException();
        }
    }
}