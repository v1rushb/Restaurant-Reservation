using RestaurantReservation.Db.Utilities.Models;

namespace RestaurantReservation.Db.Service.Interfaces
{
    public interface IService<T> where T : class
    {
        Task<T> CreateAsync(T entity);
        Task<T> GetByIdAsync(int Id);
        Task<(List<T>, Meta)> GetAllAsync(int page, int pageSize);
        Task UpdateAsync(T entity);
        Task DeleteAsync(int Id);
    }
}
