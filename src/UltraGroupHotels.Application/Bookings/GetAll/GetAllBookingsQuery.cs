using ErrorOr;
using MediatR;
using UltraGroupHotels.Application.Bookings.Common;

namespace UltraGroupHotels.Application.Bookings.GetAll
{
    public record GetAllBookingsQuery() : IRequest<ErrorOr<IEnumerable<BookingResponse>>>;

}
