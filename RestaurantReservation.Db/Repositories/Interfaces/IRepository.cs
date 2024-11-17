namespace RestaurantReservation.Db.Repositories.interfaces 
{
    public interface IRepository<T> where T : class 
    {
        Task<int> CreateAsync(T entity);
        Task<T> GetByIdAsync(int Id);
        Task<List<T>> GetAllAsync(T entity);
        Task UpdateAsync(T entity);
        Task DeleteAsync(int Id);
        Task<int> GetCountAsync();
    }
}