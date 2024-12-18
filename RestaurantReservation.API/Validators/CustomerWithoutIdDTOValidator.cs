using FluentValidation;
using RestaurantReservation.API.Constants;
using RestaurantReservation.API.Extensions;
using RestaurantReservation.API.Models;

namespace RestaurantReservation.API.Validators
{
    public class CustomerWithoutIdDTOValidator : AbstractValidator<CustomerWithoutIdDTO>
    {
        public CustomerWithoutIdDTOValidator()
        {
            RuleFor(customer => customer.FirstName)
                .ValidateName();

            RuleFor(customer => customer.LastName)
                .ValidateName();

            RuleFor(customer => customer.Email)
                .EmailAddress();

            RuleFor(customer => customer.PhoneNumber)
                .Matches(RegexPatterns.PhoneNumber)
                .WithMessage(ErrorMessages.InvalidPhoneNumber);
        }
    }
}