using UltraGroupHotels.Domain.CommonValueObjects;

namespace UltraGroupHotels.Domain.Bookings;

public record PriceSummaryBooking(Money PriceDuration, Money TotalTaxes, Money TotalPrice);