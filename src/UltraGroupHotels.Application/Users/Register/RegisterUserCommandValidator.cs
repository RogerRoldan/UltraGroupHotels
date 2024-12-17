using FluentValidation;
using UltraGroupHotels.Domain.Users;

namespace UltraGroupHotels.Application.Users.Register;

public class RegisterUserCommandValidator : AbstractValidator<RegisterUserCommand>
{
    public RegisterUserCommandValidator()
    {
        RuleFor(user => user.FullName)
            .NotEmpty()
            .WithMessage("Full name is required.")
            .MaximumLength(200)
            .WithMessage("Full name must not exceed 200 characters.");

        RuleFor(user => user.Email)
            .NotEmpty()
            .WithMessage("Email is required.")
            .EmailAddress()
            .WithMessage("Invalid email format.")
            .MaximumLength(100)
            .WithMessage("Email must not exceed 100 characters.");

        RuleFor(user => user.Password)
            .NotEmpty()
            .WithMessage("Password is required.")
            .MaximumLength(100)
            .WithMessage("Password must not exceed 100 characters.");

        RuleFor(command => command.Role)
            .NotEmpty()
            .WithMessage("Role is required.")
            .Must(role => Role.All.Select(r => r.Value).Contains(role))
            .WithMessage($"Invalid role. Allowed roles are: {string.Join(", ", Role.All.Select(r => r.Value))}.");
    }
}

