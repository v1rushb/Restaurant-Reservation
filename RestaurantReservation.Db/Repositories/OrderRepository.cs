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

        public async Task<Order> CreateAsync(Order newOrder)
        {
            var order = await _context.Orders.AddAsync(newOrder);
            await _context.SaveChangesAsync();
            return order.Entity;
        }

        public async Task DeleteAsync(int Id)
        {
            var order = await GetByIdAsync(Id);
            _context.Orders.Remove(order);
            await _context.SaveChangesAsync();
        }

        public async Task<List<Order>> GetAllAsync(int size, int pageSize)
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

        public async Task<int> GetOrdersCount() => await _context.Orders.CountAsync(); 

        public async Task<decimal> CalculateAverageOrderAmountAsync(int EmployeeId)
        {
            var overAllSum = await _context.Orders
                                    .SumAsync(order => order.TotalAmount);
            var employeeOrdersSum = await _context.Orders
                                    .Where(order => order.EmployeeId.Equals(EmployeeId))
                                    .SumAsync(order => order.TotalAmount);
            return employeeOrdersSum / overAllSum;
        }

        public async Task<bool> ExistsAsync(int Id) =>
            await _context.Orders.AnyAsync(order => order.OrderId.Equals(Id));
    }
}