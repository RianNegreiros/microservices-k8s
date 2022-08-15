using FluentValidation;

namespace Ordering.Application.Features.Orders.Commands.CheckoutOrder;

public class CheckoutOrderCommandValidator : AbstractValidator<CheckoutOrderCommand>
{
    public CheckoutOrderCommandValidator()
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