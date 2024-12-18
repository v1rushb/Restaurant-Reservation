using RestaurantReservation.Db.Entities;
using RestaurantReservation.Db.Repositories.interfaces;
using RestaurantReservation.Db.Service.Interfaces;
using RestaurantReservation.Db.Utilities;
using RestaurantReservation.Db.Utilities.Models;

namespace RestaurantReservation.Db.Service
{
    public class RestaurantService : IRestaurantService
    {
        private readonly IRestaurantRepository _restaurantRepository;
        private readonly PaginationMetadataGenerator<Restaurant> _paginationMetadataGenerator = new();


        public RestaurantService(IRestaurantRepository restaurantRepository)
        {
            _restaurantRepository = restaurantRepository;
        }
        public async Task<Restaurant> CreateAsync(Restaurant newRestaurant)
        {
            return await _restaurantRepository.CreateAsync(newRestaurant);
        }

        public async Task DeleteAsync(int restaurantId)
        {
            await _restaurantRepository.DeleteAsync(restaurantId);
        }

        public async Task<(List<Restaurant>, Meta)> GetAllAsync(int page, int pageSize)
        {
            var restaurants = await _restaurantRepository.GetAllAsync(page, pageSize);
            var metadata = _paginationMetadataGenerator.GetGeneratedMetadata(restaurants, page, pageSize);
                
            return (restaurants, metadata);
        }

        public async Task<Restaurant> GetByIdAsync(int restaurantId)
        {
            return await _restaurantRepository.GetByIdAsync(restaurantId);
        }

        public async Task UpdateAsync(Restaurant updatedRestaurant)
        {
            await _restaurantRepository.UpdateAsync(updatedRestaurant);
        }
    }
}