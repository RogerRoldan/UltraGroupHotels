using FluentValidation;
using UltraGroupHotels.Domain.Rooms;

namespace UltraGroupHotels.Application.Rooms.Update;

public class UpdateRoomCommandValidator : AbstractValidator<UpdateRoomCommand>
{
    public UpdateRoomCommandValidator()
    {
        RuleFor(x => x.HotelId)
            .NotEmpty().WithMessage("HotelId is required");

        RuleFor(x => x.RoomNumber)
            .NotEmpty().WithMessage("RoomNumber is required")
            .GreaterThan(0).WithMessage("RoomNumber must be greater than 0");

        RuleFor(x => x.QuantityGuests)
            .NotEmpty().WithMessage("QuantityGuestsAdults is required")
            .GreaterThan(0).WithMessage("QuantityGuestsAdults must be greater than 0");

        RuleFor(x => x.RoomType)
            .NotEmpty().WithMessage("RoomType is required.")
            .Must(roomType => BeAValidRoomType(roomType))
            .WithMessage("Invalid RoomType. Allowed values are: " +
                string.Join(", ", Enum.GetNames(typeof(RoomType.RoomTypeEnum))));

        RuleFor(x => x.BaseCostAmount)
            .NotEmpty().WithMessage("BaseCostAmount is required")
            .GreaterThan(0).WithMessage("BaseCostAmount must be greater than 0");

        RuleFor(x => x.BaseCostCurrency)
            .NotEmpty().WithMessage("BaseCostCurrency is required")
            .MaximumLength(3).WithMessage("Currency must not exceed 3 characters");

        RuleFor(x => x.Taxes)
            .NotEmpty().WithMessage("Taxes are required")
            .GreaterThanOrEqualTo(0).WithMessage("Taxes must be greater than or equal to 0");

        RuleFor(x => x.IsActive)
            .NotNull().WithMessage("IsActive must be specified");
    }

    private bool BeAValidRoomType(string roomType)
    {
        var validRoomTypes = Enum.GetNames(typeof(RoomType.RoomTypeEnum));
        return validRoomTypes.Contains(roomType);
    }
}
