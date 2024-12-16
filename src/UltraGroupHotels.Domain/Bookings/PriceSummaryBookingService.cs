using UltraGroupHotels.Domain.CommonValueObjects;
using UltraGroupHotels.Domain.Rooms;

namespace UltraGroupHotels.Domain.Bookings;

public class PriceSummaryBookingService
{
    public static PriceSummaryBooking CalculatePriceSummary(Room room, DateRange dateRange)
    {
        Money priceDuration = new Money(room.BaseCost.Amount * dateRange.Days, room.BaseCost.Currency);

        decimal priceTaxes = (priceDuration.Amount * room.Taxes.Value) / 100;

        Money totalTaxes = new Money(priceTaxes, room.BaseCost.Currency);

        Money totalPrice = new Money(priceDuration.Amount + totalTaxes.Amount, room.BaseCost.Currency);

        return new PriceSummaryBooking(priceDuration, totalTaxes, totalPrice);
    }
}