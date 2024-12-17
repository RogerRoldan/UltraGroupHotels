namespace UltraGroupHotels.Domain.Bookings;

public class StatusBookingsActive
{
    public static List<StatusBooking> StatusBookingActive = new()
    {
        StatusBooking.Reserved,
        StatusBooking.Confirmed,
        StatusBooking.Completed
    };
}
