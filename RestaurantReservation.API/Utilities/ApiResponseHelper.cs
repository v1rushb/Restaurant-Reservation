using RestaurantReservation.API.Common;
using RestaurantReservation.API.Models;
using RestaurantReservation.Db.Utilities.Models;

namespace RestaurantReservation.API.Utilities
{
    public static class ApiResponseHelper
    {
        public static ApiResponse<T> CreateSuccessResponse<T>(T data, Meta? meta = null)
        {
            return new ApiResponse<T>
            {
                Success = true,
                Data = data,
                Metadata = meta ?? new Meta(),
                Errors = new List<ValidationResultDTO>()
            };
        }

        public static ApiResponse<T> CreateErrorResponse<T>(List<ValidationResultDTO> errors)
        {
            return new ApiResponse<T>
            {
                Success = false,
                Data = default!,
                Metadata = new Meta(),
                Errors = errors
            };
        }
    }
}
