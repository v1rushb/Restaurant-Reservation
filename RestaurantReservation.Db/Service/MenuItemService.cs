using RestaurantReservation.Db.Entities;
using RestaurantReservation.Db.Repositories.interfaces;
using RestaurantReservation.Db.Service.Interfaces;
using RestaurantReservation.Db.Utilities;
using RestaurantReservation.Db.Utilities.Models;

namespace RestaurantReservation.Db.Service
{
    public class MenuItemService : IMenuItemService
    {
        private readonly IMenuItemRepository _menuItemRepository;
        private readonly PaginationMetadataGenerator<MenuItem> _paginationMetadataGenerator = new();

        
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

        public async Task<(List<MenuItem>, Meta)> GetAllAsync(int page, int pageSize)
        {
            var menuItems = await _menuItemRepository.GetAllAsync(page, pageSize);
            var metadata = _paginationMetadataGenerator.GetGeneratedMetadata(menuItems, page, pageSize);
                
            return (menuItems, metadata);
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