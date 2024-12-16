using ErrorOr;
using MediatR;
using UltraGroupHotels.Application.Bookings.Common;
using UltraGroupHotels.Domain.Bookings;

namespace UltraGroupHotels.Application.Bookings.GetById
{
    public sealed class GetBookingByIdQueryHandler : IRequestHandler<GetBookingByIdQuery, ErrorOr<BookingResponse>>
    {
        private readonly IBookingRepository _bookingRepository;

        public GetBookingByIdQueryHandler(IBookingRepository bookingRepository)
        {
            _bookingRepository = bookingRepository;
        }

        public async Task<ErrorOr<BookingResponse>> Handle(GetBookingByIdQuery request, CancellationToken cancellationToken)
        {
            var booking = await _bookingRepository.GetBookingByIdAsync(request.Id, cancellationToken); 

            if (booking is null)
            {
                return Error.NotFound("Booking", "Booking not found");
            }

            var bookingResponse = new BookingResponse(
            booking.Id, booking.UserId, booking.RoomId, new DateRangeResponse(booking.Duration.StartDate, booking.Duration.EndDate, booking.Duration.Days), new PriceSummaryBookingResponse(booking.PriceDuration.Currency.ToString(), booking.PriceDuration.Amount, booking.TotalTaxes.Amount, booking.TotalPrice.Amount), booking.CreatedAt, booking.StatusBooking.ToString(), new EmergencyContactReponse(booking.EmergencyContact.FullName, booking.EmergencyContact.PhoneNumber.Value));

            return bookingResponse;
        }
    }
}
