﻿using FluentValidation;

namespace UltraGroupHotels.Application.Rooms.GetAvailableRoomsForDatesAndGuests;

public class GetAvailableRoomsForDatesAndGuestsQueryValidator : AbstractValidator<GetAvailableRoomsForDatesAndGuestsQuery>
{
    public GetAvailableRoomsForDatesAndGuestsQueryValidator()
    {
        RuleFor(x => x.StartDate)
            .NotNull()
            .WithMessage("The start date must be provided.")
            .GreaterThanOrEqualTo(DateOnly.FromDateTime(DateTime.Now))
            .WithMessage("The start date must be greater than or equal to the current date.")
            .LessThanOrEqualTo(x => x.EndDate)
            .WithMessage("The start date must be less than or equal to the end date.");

        RuleFor(x => x.NumberOfGuests)
            .GreaterThan(0)
            .WithMessage("The number of guests must be greater than 0.");

        RuleFor(x => x.City)
            .NotEmpty()
            .WithMessage("The city must not be empty.")
            .MaximumLength(100).WithMessage("The city must not exceed 100 characters.");
    }
}
