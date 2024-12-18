using RestaurantReservation.Db.Entities;
using RestaurantReservation.Db.Repositories.interfaces;
using RestaurantReservation.Db.Service.Interfaces;

namespace RestaurantReservation.Db.Service
{
    public class MenuItemService : IMenuItemService
    {
        private readonly IMenuItemRepository _menuItemRepository;
        
        public MenuItemService(IMenuItemRepository menuItemRepository)
        {
            _menuItemRepository = menuItemRepository;
        }
        public async Task<int> CreateAsync(MenuItem newMenuItem)
        {
            return await _menuItemRepository.CreateAsync(newMenuItem);
        }

        public async Task DeleteAsync(int menuItemId)
        {
            await _menuItemRepository.DeleteAsync(menuItemId);
        }

        public async Task<List<MenuItem>> GetAllAsync(int size, int pageSize)
        {
            return await _menuItemRepository.GetAllAsync(size, pageSize);
        }

        public async Task<MenuItem> GetByIdAsync(int menuItemId)
        {
            return await _menuItemRepository.GetByIdAsync(menuItemId);
        }

        public async Task UpdateAsync(MenuItem updatedMenuItem)
        {
            await _menuItemRepository.UpdateAsync(updatedMenuItem);
        }
    }
}