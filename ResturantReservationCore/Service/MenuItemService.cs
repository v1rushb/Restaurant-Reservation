using RestaurantReservation.Db.Entities;
using RestaurantReservation.Db.Repositories.interfaces;
using RestaurantReservationCore.Service.Interfaces;

namespace RestaurantReservationCore.Service
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

        public async Task<List<MenuItem>> GetAllAsync()
        {
            return await _menuItemRepository.GetAllAsync();
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