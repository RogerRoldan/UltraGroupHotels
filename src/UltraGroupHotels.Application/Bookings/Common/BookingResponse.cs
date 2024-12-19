using UltraGroupHotels.Domain.Bookings;

namespace UltraGroupHotels.Application.Bookings.Common;

public record BookingResponse(Guid Id, Guid TitularGuestId, Guid RoomId, DateRangeResponse BookingPeriod, PriceSummaryBookingResponse PriceSummary, DateTime CreatedAt, string StatusBooking, EmergencyContactReponse EmergencyContact);

public record PriceSummaryBookingResponse(string Currency, decimal PriceDuration, decimal TotalTaxes, decimal TotalPrice);

public record EmergencyContactReponse(string FullName, string PhoneNumber);

public record DateRangeResponse(DateOnly Start, DateOnly End, int Days);