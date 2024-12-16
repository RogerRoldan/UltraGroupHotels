using UltraGroupHotels.Domain.CommonValueObjects;
using UltraGroupHotels.Domain.Implementations;
using UltraGroupHotels.Domain.Rooms;

namespace UltraGroupHotels.Domain.Bookings;

public class Booking : Entity
{
    public Guid Id { get; private set; }
    public Guid UserId { get; private set; }
    public Guid RoomId { get; private set; }
    public DateRange Duration { get; private set; }
    public Taxes TaxesPercentage { get; private set; }
    public Money TotalTaxes { get; private set; }
    public Money PriceDuration { get; private set; }
    public Money TotalPrice { get; private set; }
    public StatusBooking StatusBooking { get; private set; }
    public EmergencyContact EmergencyContact { get; private set; }
    public DateTime CreatedAt { get; private set; }

    public Booking(Guid userId, Guid roomId, DateRange duration, Taxes taxesPercentage, Money priceDuration, Money totalTaxes, Money totalPrice, EmergencyContact emergencyContact)
    {
        UserId = userId;
        RoomId = roomId;
        Duration = duration;
        TaxesPercentage = taxesPercentage;
        PriceDuration = priceDuration;
        TotalTaxes = totalTaxes;
        TotalPrice = totalPrice;
        StatusBooking = StatusBooking.Confirmed;
        EmergencyContact = emergencyContact;
        CreatedAt = DateTime.UtcNow;
    }

    public Booking  MakeReservation(Room room, Guid userId, DateRange dateRange, EmergencyContact emergencyContact)
    {
        PriceSummaryBooking  priceSummaryBooking = PriceSummaryBookingService.CalculatePriceSummary(room, dateRange);

        var booking = new Booking(userId, room.Id, dateRange, room.Taxes, priceSummaryBooking.PriceDuration, priceSummaryBooking.TotalTaxes, priceSummaryBooking.TotalPrice, emergencyContact);

        //booking.Raise(new BookingMakeReservationDomainEvent(booking.Id));

        return booking;
    }

    private Booking()
    {
        
    }
}
