namespace RestaurantReservation.Db.Repositorie.interfaces 
{
    public interface IRepository<T> where T : class 
    {
        Task<int> CreateAsync(T entity);
        Task<T> GetByIdAsync(T entity);
        Task<List<T>> GetAllAsync(T entity);
        Task UpdateAsync(T entity);
        Task DeleteAsync(int Id);

        Task<int> GetCountAsync();
    }
}