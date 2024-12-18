using FluentValidation;
using RestaurantReservation.API.Constants;

namespace RestaurantReservation.API.Extensions
{
    public static class NameValidationExtensions
    {
        private const int MinimumNameLength = 3;
        private const int MaximumNameLength = 45;

        public static IRuleBuilderOptions<T, string> ValidateName<T>(
            this IRuleBuilder<T, string> rule)
        {
            return rule
                .Matches(RegexPatterns.Name)
                .WithMessage(ErrorMessages.InvalidName)
                .Length(MinimumNameLength, MaximumNameLength);
        }
    }
}