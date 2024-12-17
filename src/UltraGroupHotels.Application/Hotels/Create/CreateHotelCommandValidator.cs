using FluentValidation;
using UltraGroupHotels.Domain.SharedValueObjects;

namespace UltraGroupHotels.Application.Hotels.Create;

public class CreateHotelCommandValidator : AbstractValidator<CreateHotelCommand>
{

    public CreateHotelCommandValidator()
    {
        RuleFor(x => x.Name)
            .NotEmpty().WithMessage("Name is required")
            .MaximumLength(100).WithMessage("Name must not exceed 100 characters");

        RuleFor(x => x.Description)
            .NotEmpty().WithMessage("Description is required")
            .MaximumLength(500).WithMessage("Description must not exceed 500 characters");

        RuleFor(x => x.Country)
            .NotEmpty().WithMessage("Country is required")
            .MaximumLength(100).WithMessage("Country must not exceed 100 characters");

        RuleFor(x => x.State)
            .NotEmpty().WithMessage("State is required")
            .MaximumLength(100).WithMessage("State must not exceed 100 characters");

        RuleFor(x => x.City)
            .NotEmpty().WithMessage("City is required")
            .MaximumLength(100).WithMessage("City must not exceed 100 characters");

        RuleFor(x => x.ZipCode)
            .NotEmpty().WithMessage("ZipCode is required")
            .MaximumLength(100).WithMessage("ZipCode must not exceed 100 characters")
            .WithName("Zip Code");

        RuleFor(x => x.Street)
            .NotEmpty().WithMessage("Street is required")
            .MaximumLength(100).WithMessage("Street must not exceed 100 characters");

        RuleFor(x => x.PhoneNumber)
            .NotEmpty().WithMessage("PhoneNumber is required")
            .MaximumLength(PhoneNumber.DefaultLength).WithMessage($"PhoneNumber must not exceed {PhoneNumber.DefaultLength} characters")
            .Matches(PhoneNumber.Pattern).WithMessage("PhoneNumber must follow the international format starting with '+' and include 7 to 15 digits")
            .WithName("Phone Number");

    }
}
