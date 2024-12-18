using FluentValidation;
using RestaurantReservation.API.Extensions;
using RestaurantReservation.API.Models;

namespace RestaurantReservation.API.Validators
{
    public class EmployeeWithoutIdDTOValidator : AbstractValidator<EmployeeWithoutIdDTO>
    {
        public EmployeeWithoutIdDTOValidator()
        {
            RuleFor(customer => customer.FirstName)
                .ValidateName();

            RuleFor(customer => customer.LastName)
                .ValidateName();

            RuleFor(employee => employee.Position)
                .NotEmpty();
        }
    }
}