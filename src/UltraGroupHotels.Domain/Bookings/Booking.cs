using UltraGroupHotels.Domain.CommonValueObjects;
using UltraGroupHotels.Domain.Implementations;
using UltraGroupHotels.Domain.Rooms;

namespace UltraGroupHotels.Domain.Bookings;

public class Booking : Entity
{
    public Guid Id { get; private set; }
    public Guid TitularGuest { get; private set; }
    public Guid RoomId { get; private set; }
    public DateRange Duration { get; private set; }
    public Taxes TaxesPercentage { get; private set; }
    public Money TotalTaxes { get; private set; }
    public Money PriceDuration { get; private set; }
    public Money TotalPrice { get; private set; }
    public StatusBooking StatusBooking { get; private set; }
    public EmergencyContact EmergencyContact { get; private set; }
    public DateTime CreatedAt { get; private set; }

    private Booking(
                   Guid id,
                   Guid titularGuest,
                   Guid roomId, 
                   DateRange duration, 
                   Taxes taxesPercentage, 
                   Money priceDuration, 
                   Money totalTaxes, 
                   Money totalPrice, 
                   EmergencyContact emergencyContact)
    {
        Id = id;    
        TitularGuest = titularGuest;
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

    public static Booking MakeReservation(
                                    Guid userId, 
                                    Room room, 
                                    DateRange duration, 
                                    EmergencyContact emergencyContact)

    {
        PriceSummaryBooking  priceSummaryBooking = PriceSummaryBookingService.CalculatePriceSummary(room, duration);

        var booking = new Booking(
                                  Guid.NewGuid(),
                                  userId,
                                  room.Id, 
                                  duration, 
                                  room.Taxes, 
                                  priceSummaryBooking.PriceDuration, 
                                  priceSummaryBooking.TotalTaxes, 
                                  priceSummaryBooking.TotalPrice, 
                                  emergencyContact);

        return booking;
    }

    private Booking()
    {
        
    }
}
