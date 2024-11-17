using System.Runtime.CompilerServices;
using Microsoft.EntityFrameworkCore;
using RestaurantReservation.Db.Entities;
using RestaurantReservation.Db.Repositories.interfaces;

namespace RestaurantReservation.Db.Repositories
{
    public class OrderRepository : IOrderRepository
    {
        private readonly RestaurantReservationDbContext _context;

        public OrderRepository(RestaurantReservationDbContext context)
        {
            _context = context;
            _context.Database.EnsureCreatedAsync().Wait();
        }

        async Task<int> IRepository<Order>.CreateAsync(Order newOrder)
        {
            var order = await _context.Orders.AddAsync(newOrder);
            return order.Entity.OrderId;
        }

        public async Task DeleteAsync(int Id)
        {
            var order = await GetByIdAsync(Id);
            _context.Orders.Remove(order);
            await _context.SaveChangesAsync();
        }

        public async Task<List<Order>> GetAllAsync()
        {
            return await _context.Orders.ToListAsync();
        }

        public async Task<Order> GetByIdAsync(int Id)
        {
            var order = await _context.Orders
                    .SingleOrDefaultAsync(order => order.OrderId == Id);
            return order;
        }

        Task<int> IRepository<Order>.GetCountAsync()
        {
            throw new NotImplementedException();
        }

        public async Task UpdateAsync(Order updatedOrder)
        {
            _context.Orders.Update(updatedOrder);
            await _context.SaveChangesAsync();
        }
    }
}