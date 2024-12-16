using ErrorOr;
using MediatR;
using UltraGroupHotels.Application.Bookings.Common;

namespace UltraGroupHotels.Application.Bookings.GetById;

public record GetBookingByIdQuery(Guid Id) : IRequest<ErrorOr<BookingResponse>>;
