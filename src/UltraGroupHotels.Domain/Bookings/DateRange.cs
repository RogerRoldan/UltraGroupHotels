namespace UltraGroupHotels.Domain.Bookings;

public sealed record DateRange
{
    public DateOnly StartDate { get; init; }
    public DateOnly EndDate { get; init; }

    public int Days => EndDate.DayNumber - StartDate.DayNumber;

    public DateRange(DateOnly startDate, DateOnly endDate)
    {
        StartDate = startDate;
        EndDate = endDate;
    }

    public DateRange CreateRange(DateOnly startDate, DateOnly endDate)
    {
        if (startDate > endDate)
        {
            throw new ArgumentException("Start date must be less than end date");
        }

        return new DateRange(startDate, endDate);
    }

}