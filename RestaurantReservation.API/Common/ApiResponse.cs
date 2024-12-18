using RestaurantReservation.API.Models;
using RestaurantReservation.Db.Utilities.Models;

namespace RestaurantReservation.API.Common
{
    public class ApiResponse<T>
    {
        public bool Success { get; set; } = false;
        public T Data { get; set; } = default;
        public List<ValidationResultDTO> Errors { get; set; } = new();
        public Meta Metadata { get; set; } = new();
    }
}