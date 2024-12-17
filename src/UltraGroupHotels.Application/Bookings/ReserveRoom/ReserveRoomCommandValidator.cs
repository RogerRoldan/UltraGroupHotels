using FluentValidation;
using UltraGroupHotels.Domain.SharedValueObjects;

namespace UltraGroupHotels.Application.Bookings.ReserveRoom;

public class ReserveRoomCommandValidator : AbstractValidator<ReserveRoomCommand>
{
    public ReserveRoomCommandValidator()
    {
        RuleFor(x => x.RoomId)
              .NotEmpty().WithMessage("RoomId is required.");

        RuleFor(x => x.CustomerId)
            .NotEmpty().WithMessage("CustomerId is required.");

        RuleFor(x => x.StartDate)
            .NotEmpty().WithMessage("StartDate is required.")
            .LessThan(x => x.EndDate).WithMessage("StartDate must be earlier than EndDate.");

        RuleFor(x => x.EndDate)
            .NotEmpty().WithMessage("EndDate is required.")
            .GreaterThan(x => x.StartDate).WithMessage("EndDate must be later than StartDate.");

        RuleFor(x => x.EmergencyContactFullName)
            .NotEmpty().WithMessage("EmergencyContactFullName is required.")
            .MaximumLength(100).WithMessage("EmergencyContactFullName must not exceed 100 characters.");

        RuleFor(x => x.EmergencyContactPhoneNumber)
            .NotEmpty().WithMessage("PhoneNumber is required")
            .MaximumLength(PhoneNumber.DefaultLength).WithMessage($"PhoneNumber must not exceed {PhoneNumber.DefaultLength} characters")
            .Matches(PhoneNumber.Pattern).WithMessage("PhoneNumber must follow the international format starting with '+' and include 7 to 15 digits")
            .WithName("Phone Number");

        RuleForEach(x => x.Guests)
            .SetValidator(new GuestCommandValidator());
    }
}
