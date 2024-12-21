using RestaurantReservation.Db.Entities;

namespace RestaurantReservation.Db.Service.Interfaces
{
    public interface IUserService : IService<User>
    {
        Task<User> Authenticate(string username, string password);
    }
}