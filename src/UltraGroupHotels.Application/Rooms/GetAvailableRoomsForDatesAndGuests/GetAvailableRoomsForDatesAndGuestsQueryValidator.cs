using FluentValidation;

namespace UltraGroupHotels.Application.Rooms.GetAvailableRoomsForDatesAndGuests;

public class GetAvailableRoomsForDatesAndGuestsQueryValidator : AbstractValidator<GetAvailableRoomsForDatesAndGuestsQuery>
{
    public GetAvailableRoomsForDatesAndGuestsQueryValidator()
    {
        RuleFor(x => x.StartDate)
            .LessThanOrEqualTo(x => x.EndDate)
            .WithMessage("The start date must be less than or equal to the end date.");

        RuleFor(x => x.NumberOfGuests)
            .GreaterThan(0)
            .WithMessage("The number of guests must be greater than 0.");
    }
}
