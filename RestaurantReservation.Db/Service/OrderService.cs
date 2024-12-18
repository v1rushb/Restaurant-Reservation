using System.Formats.Asn1;
using RestaurantReservation.Db.Entities;
using RestaurantReservation.Db.Repositories.interfaces;
using RestaurantReservation.Db.Service.Interfaces;
using RestaurantReservation.Db.Utilities;
using RestaurantReservation.Db.Utilities.Models;

namespace RestaurantReservation.Db.Service
{
    public class OrderService : IOrderService
    {
        private readonly IOrderRepository _orderRepository;
        private readonly PaginationMetadataGenerator<Order> _paginationMetadataGenerator = new();


        public OrderService(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }
        public async Task<Order> CreateAsync(Order newOrder)
        {
            return await _orderRepository.CreateAsync(newOrder);
        }

        public async Task DeleteAsync(int orderId)
        {
            await _orderRepository.DeleteAsync(orderId);
        }

        public async Task<(List<Order>, Meta)> GetAllAsync(int page, int pageSize)
        {
            var orders = await _orderRepository.GetAllAsync(page, pageSize);
            var metadata = _paginationMetadataGenerator.GetGeneratedMetadata(orders, page, pageSize);
                
            return (orders, metadata);
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