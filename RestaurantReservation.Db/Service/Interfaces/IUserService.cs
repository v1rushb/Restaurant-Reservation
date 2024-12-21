using RestaurantReservation.Db.Entities;

namespace RestaurantReservation.Db.Service.Interfaces
{
    public interface IUserService : IService<User>
    {
        Task<User> AuthenticateUserAsync(string username, string password);
    }
}