using eCommerce.Core.DTO;
using FluentValidation;

namespace eCommerce.Core.Validators;

public class RegisterRequestValidator : AbstractValidator<RegisterRequest>
{
    public RegisterRequestValidator()
    {
        RuleFor(x => x.Email)
            .NotEmpty()
            .WithMessage("Email is required")
            .EmailAddress()
            .WithMessage("Email is invalid");

        RuleFor(x => x.Password)
            .NotEmpty()
            .WithMessage("Password is required")
            .MinimumLength(4)
            .WithMessage("Password must be at least 4 characters long");

        RuleFor(x => x.PersonName)
            .NotEmpty()
            .WithMessage("Person name cant be empty");
        
        RuleFor(x => x.Gender)
            .NotEmpty()
            .WithMessage("Gender is required")
            .IsInEnum()
            .WithMessage("Gender is invalid");
    }
}