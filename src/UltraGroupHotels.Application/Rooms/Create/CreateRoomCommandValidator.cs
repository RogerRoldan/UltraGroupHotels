using FluentValidation;
using UltraGroupHotels.Domain.CommonValueObjects;
using UltraGroupHotels.Domain.Rooms;

namespace UltraGroupHotels.Application.Rooms.Create;

public class CreateRoomCommandValidator : AbstractValidator<CreateRoomCommand>
{

    public CreateRoomCommandValidator()
    {
        RuleFor(x => x.HotelId)
            .NotEmpty().WithMessage("HotelId is required");

        RuleFor(x => x.RoomNumber)
            .NotEmpty().WithMessage("RoomNumber is required");

        RuleFor(x => x.QuantityGuestsAdults)
            .NotEmpty().WithMessage("QuantityGuests is required")
            .GreaterThan(0).WithMessage("QuantityGuests must be greater than 0");

        RuleFor(x => x.RoomType)
            .NotEmpty().WithMessage("RoomType is required.")
            .Must(roomType => BeAValidRoomType(roomType))
            .WithMessage("Invalid RoomType. Allowed values are: " +
                string.Join(", ", Enum.GetNames(typeof(RoomType.RoomTypeEnum))));

        RuleFor(x => x.BaseCostAmount)
            .NotEmpty().WithMessage("BaseCost is required");

        RuleFor(x => x.BaseCostCurrency)
            .MaximumLength(3).WithMessage("Currency must not exceed 3 characters");



        RuleFor(x => x.Taxes)
            .NotEmpty().WithMessage("Taxes is required");

        RuleFor(x => x.IsActive)
            .NotEmpty().WithMessage("IsActive is required");
    }

    // Método auxiliar para validar que el valor pertenece al enum
    private bool BeAValidRoomType(string roomTypeValue)
    {
        return Enum.TryParse(typeof(RoomType.RoomTypeEnum), roomTypeValue, true, out _);
    }
}
