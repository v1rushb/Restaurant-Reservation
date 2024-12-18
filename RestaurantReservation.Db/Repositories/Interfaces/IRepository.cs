namespace RestaurantReservation.Db.Repositories.interfaces 
{
    public interface IRepository<T> where T : class 
    {
        Task<T> CreateAsync(T entity);
        Task<T> GetByIdAsync(int Id);
        Task<List<T>> GetAllAsync(int size, int pageSize);
        Task UpdateAsync(T entity);
        Task DeleteAsync(int Id);
        Task<int> GetCountAsync();
        Task<bool> ExistsAsync(int Id);
    }
}