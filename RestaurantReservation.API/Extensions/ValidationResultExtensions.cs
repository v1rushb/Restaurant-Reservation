using FluentValidation.Results;
using RestaurantReservation.API.Models;

namespace RestaurantReservation.API.Extensions
{
    public static class ValidationResultExtensions
    {
        public static List<ValidationResultDTO> GetErrorDetails(
            this ValidationResult validationResult)
        {
            return validationResult.Errors.Select(err => new ValidationResultDTO
            {
                ErrorMessage = err.ErrorMessage,
                PropertyName = err.PropertyName,
                AttemptedValue = err.AttemptedValue?.ToString()
            }).ToList();
        }
    }
}