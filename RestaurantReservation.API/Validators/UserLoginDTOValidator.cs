using FluentValidation;
using RestaurantReservation.API.Constants;
using RestaurantReservation.API.Models;

namespace RestaurantReservation.API.Validators
{
    public class UserLoginDTOValidator : AbstractValidator<UserLoginDTO>
    {
        public UserLoginDTOValidator()
        {
            RuleFor(user => user.Username)
                .Matches(RegexPatterns.Username)
                .WithMessage(ErrorMessages.InvalidUsername)
                .Length(Username.MinimumLength, Username.MaximumLength);

            RuleFor(user => user.Password)
                .Length(Password.MinimumLength, Password.MaximumLength);
        }
    }
}