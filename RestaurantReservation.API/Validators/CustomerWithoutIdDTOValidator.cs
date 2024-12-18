using System.Data;
using FluentValidation;
using RestaurantReservation.API.Constants;
using RestaurantReservation.API.Models;

namespace RestaurantReservation.API.Validators
{
    public class CustomerWithoutIdDTOValidator : AbstractValidator<CustomerWithoutIdDTO>
    {
        public CustomerWithoutIdDTOValidator()
        {
            RuleFor(customer => customer.FirstName)
                .NotEmpty().WithMessage("LMAOOO")
                .MaximumLength(45).WithMessage("First name must not exceed 45 characters.");

            RuleFor(customer => customer.LastName)
                .NotEmpty().WithMessage("Last name is required.")
                .MaximumLength(45).WithMessage("Last name must not exceed 45 characters.");

            RuleFor(customer => customer.Email)
                .NotEmpty().WithMessage("Email is required.")
                .EmailAddress().WithMessage("Invalid Email.")
                .MaximumLength(85).WithMessage("Email must not exceed 85 characters.");

            RuleFor(customer => customer.PhoneNumber)
                .NotEmpty().WithMessage("Phone number is required.")
                .Matches(RegexPatterns.PhoneNumber).WithMessage("yoink"); // make a regex later.
        }
    }
}

