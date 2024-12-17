using FluentValidation;
using UltraGroupHotels.Domain.SharedValueObjects;

namespace UltraGroupHotels.Application.Bookings.ReserveRoom;

public class GuestCommandValidator : AbstractValidator<GuestCommand>
{
    public GuestCommandValidator()
    {
        RuleFor(x => x.FirstName)
            .NotEmpty().WithMessage("FirstName is required.")
            .MaximumLength(50).WithMessage("FirstName must not exceed 50 characters.");

        RuleFor(x => x.LastName)
            .NotEmpty().WithMessage("LastName is required.")
            .MaximumLength(50).WithMessage("LastName must not exceed 50 characters.");

        RuleFor(x => x.DateOfBirth)
            .NotEmpty().WithMessage("DateOfBirth is required.")
            .LessThan(DateOnly.FromDateTime(DateTime.Now)).WithMessage("DateOfBirth must be in the past.");

        RuleFor(x => x.Gender)
            .NotEmpty().WithMessage("Gender is required.")
            .Must(value => value == "Male" || value == "Female" || value == "Other")
            .WithMessage("Gender must be 'Male', 'Female', or 'Other'.");

        RuleFor(x => x.TypeDocument)
            .NotEmpty().WithMessage("TypeDocument is required.")
            .MaximumLength(20).WithMessage("TypeDocument must not exceed 20 characters.");

        RuleFor(x => x.DocumentNumber)
            .NotEmpty().WithMessage("DocumentNumber is required.")
            .MaximumLength(50).WithMessage("DocumentNumber must not exceed 50 characters.");

        RuleFor(x => x.Email)
            .NotEmpty().WithMessage("Email is required.")
            .EmailAddress().WithMessage("Email must be a valid email address.");

        RuleFor(x => x.PhoneNumber)
              .NotEmpty().WithMessage("PhoneNumber is required")
              .MaximumLength(PhoneNumber.DefaultLength).WithMessage($"PhoneNumber must not exceed {PhoneNumber.DefaultLength} characters")
              .Matches(PhoneNumber.Pattern).WithMessage("PhoneNumber must follow the international format starting with '+' and include 7 to 15 digits")
              .WithName("Phone Number");
    }
}
