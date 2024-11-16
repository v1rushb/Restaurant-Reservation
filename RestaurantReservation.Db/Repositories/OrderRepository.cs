using RestaurantReservation.Db.Entities;
using RestaurantReservation.Db.Repositories.interfaces;

namespace RestaurantReservation.Db.Repositories
{
    public class OrderRepository : IOrderRepository
    {
        Task<int> IRepository<Order>.CreateAsync(Order entity)
        {
            throw new NotImplementedException();
        }

        Task IRepository<Order>.DeleteAsync(int Id)
        {
            throw new NotImplementedException();
        }

        Task<List<Order>> IRepository<Order>.GetAllAsync(Order entity)
        {
            throw new NotImplementedException();
        }

        Task<Order> IRepository<Order>.GetByIdAsync(Order entity)
        {
            throw new NotImplementedException();
        }

        Task<int> IRepository<Order>.GetCountAsync()
        {
            throw new NotImplementedException();
        }

        Task IRepository<Order>.UpdateAsync(Order entity)
        {
            throw new NotImplementedException();
        }
    }
}