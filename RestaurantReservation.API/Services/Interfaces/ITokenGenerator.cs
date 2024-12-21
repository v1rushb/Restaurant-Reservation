using RestaurantReservation.API.Models;

namespace RestaurantReservation.API.Services.Interfaces
{
    public interface ITokenGenerator
    {
        string GenerateToken(UserWithoutPasswordDTO user);
        bool ValidateToken(string token);
    }
}