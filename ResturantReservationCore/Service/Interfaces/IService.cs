namespace RestaurantReservationCore.Service.Interfaces
{
    public interface IService<T> where T : class
    {
        Task<int> CreateAsync(T entity);
        Task<T> GetByIdAsync(int Id);
        Task<List<T>> GetAllAsync();
        Task UpdateAsync(T entity);
        Task DeleteAsync(int Id);
    }
}
