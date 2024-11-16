using RestaurantReservation.Db.Repositories.interfaces;

namespace RestaurantReservation.Db.Repositories
{
    public class User : IUserRepository
    {
        Task<int> IRepository<User>.CreateAsync(User entity)
        {
            throw new NotImplementedException();
        }

        Task IRepository<User>.DeleteAsync(int Id)
        {
            throw new NotImplementedException();
        }

        Task<List<User>> IRepository<User>.GetAllAsync(User entity)
        {
            throw new NotImplementedException();
        }

        Task<User> IRepository<User>.GetByIdAsync(User entity)
        {
            throw new NotImplementedException();
        }

        Task<int> IRepository<User>.GetCountAsync()
        {
            throw new NotImplementedException();
        }

        Task IRepository<User>.UpdateAsync(User entity)
        {
            throw new NotImplementedException();
        }
    }
}