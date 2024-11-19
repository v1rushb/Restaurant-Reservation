using System.Formats.Asn1;
using RestaurantReservation.Db.Entities;
using RestaurantReservation.Db.Repositories.interfaces;
using RestaurantReservationCore.Service.Interfaces;

namespace RestaurantReservationCore.Service
{
    public class OrderService : IOrderService
    {
        private readonly IOrderRepository _orderRepository;

        public OrderService(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }
        public async Task<int> CreateAsync(Order newOrder)
        {
            return await _orderRepository.CreateAsync(newOrder);
        }

        public async Task DeleteAsync(int orderId)
        {
            await _orderRepository.DeleteAsync(orderId);
        }

        public async Task<List<Order>> GetAllAsync()
        {
            return await _orderRepository.GetAllAsync();
        }

        public async Task<Order> GetByIdAsync(int orderId)
        {
            return await _orderRepository.GetByIdAsync(orderId);
        }

        public async Task UpdateAsync(Order updatedOrder)
        {
            await _orderRepository.UpdateAsync(updatedOrder);
        }
    }
}