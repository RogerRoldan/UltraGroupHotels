using UltraGroupHotels.Application.Bookings.Common;

namespace UltraGroupHotels.Application.Bookings.GetById;

using System.Text.Json.Serialization;

public record BookingDetailsResponse(
    Guid Id,
    Guid UserId,
    Guid RoomId,
    DateRangeResponse BookingPeriod,
    PriceSummaryBookingResponse PriceSummary,
    DateTime CreatedAt,
    string StatusBooking,
    EmergencyContactReponse EmergencyContact,
    [property: JsonPropertyOrder(9)] List<GuestResponse> Guests
) : BookingResponse(Id, UserId, RoomId, BookingPeriod, PriceSummary, CreatedAt, StatusBooking, EmergencyContact);

