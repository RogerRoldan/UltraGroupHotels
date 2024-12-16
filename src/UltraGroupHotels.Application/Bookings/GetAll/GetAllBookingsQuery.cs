using ErrorOr;
using MediatR;
using UltraGroupHotels.Application.Bookings.Common;
using UltraGroupHotels.Domain.Bookings;

namespace UltraGroupHotels.Application.Bookings.GetAll
{
    public record GetAllBookingsQuery() : IRequest<ErrorOr<IEnumerable<BookingResponse>>>;

}
