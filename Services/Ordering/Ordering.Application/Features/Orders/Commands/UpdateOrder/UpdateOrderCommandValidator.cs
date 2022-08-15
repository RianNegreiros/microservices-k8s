using FluentValidation;
using Ordering.Application.Features.Orders.Commands.CheckoutOrder;

namespace Ordering.Application.Features.Orders.Commands.UpdateOrder;

public class UpdateOrderCommandValidator : AbstractValidator<CheckoutOrderCommand>
{
    public UpdateOrderCommandValidator()
    {
        RuleFor(p => p.Username)
            .NotEmpty().WithMessage("{Username} is required")
            .NotNull()
            .MaximumLength(50).WithMessage("{Username} must not exceed 50 characters");

        RuleFor(p => p.Email)
            .NotEmpty().WithMessage("{Email} is required");

        RuleFor(p => p.TotalPrice)
            .NotEmpty().WithMessage("{TotalPrice} is required")
            .GreaterThan(0).WithMessage("{TotalPrice} should be greater than zero.");
    }
}