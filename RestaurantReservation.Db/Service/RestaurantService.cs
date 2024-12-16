using RestaurantReservation.Db.Entities;
using RestaurantReservation.Db.Repositories.interfaces;
using RestaurantReservation.Db.Service.Interfaces;

namespace RestaurantReservation.Db.Service
{
    public class RestaurantService : IRestaurantService
    {
        private readonly IRestaurantRepository _restaurantRepository;

        public RestaurantService(IRestaurantRepository restaurantRepository)
        {
            _restaurantRepository = restaurantRepository;
        }
        public async Task<int> CreateAsync(Restaurant newRestaurant)
        {
            return await _restaurantRepository.CreateAsync(newRestaurant);
        }

        public async Task DeleteAsync(int restaurantId)
        {
            await _restaurantRepository.DeleteAsync(restaurantId);
        }

        public async Task<List<Restaurant>> GetAllAsync()
        {
            return await _restaurantRepository.GetAllAsync();
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