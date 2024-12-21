using FluentValidation;
using RestaurantReservation.API.Constants;
using RestaurantReservation.API.Models;
using RestaurantReservation.Db.Entities;

namespace RestaurantReservation.API.Validators
{
    public class UserWithoutDTOValidator : AbstractValidator<UserWithoutIdDTO>
    {
        public UserWithoutDTOValidator()
        {

            RuleFor(user => user.Username)
                .Matches(RegexPatterns.Username)
                .WithMessage(ErrorMessages.InvalidUsername)
                .Length(Username.MinimumLength, Username.MaximumLength);

            RuleFor(user => user.Password)
                .NotEmpty()
                .Length(Password.MinimumLength, Password.MaximumLength);

            RuleFor(user => user.FirstName)
                .NotEmpty().WithMessage("First name is required.")
                .MaximumLength(45).WithMessage("First name must not exceed 45 characters.");

            RuleFor(user => user.LastName)
                .NotEmpty().WithMessage("Last name is required.")
                .MaximumLength(45).WithMessage("Last name must not exceed 45 characters.");
        }
    }
}