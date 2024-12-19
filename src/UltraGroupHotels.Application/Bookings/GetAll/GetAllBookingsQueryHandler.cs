using ErrorOr;
using MediatR;
using UltraGroupHotels.Application.Bookings.Common;
using UltraGroupHotels.Domain.Bookings;

namespace UltraGroupHotels.Application.Bookings.GetAll;

public sealed class GetAllBookingsQueryHandler : IRequestHandler<GetAllBookingsQuery, ErrorOr<IEnumerable<BookingResponse>>>
{
    private readonly IBookingRepository _bookingRepository;

    public GetAllBookingsQueryHandler(IBookingRepository bookingRepository)
    {
        _bookingRepository = bookingRepository;
    }

    public async Task<ErrorOr<IEnumerable<BookingResponse>>> Handle(GetAllBookingsQuery request, CancellationToken cancellationToken)
    {
        var bookings = await _bookingRepository.GetAllBookingsAsync(cancellationToken);

        var bookingResponses = bookings.Select(booking => 
                                    new BookingResponse(
                                                        booking.Id, booking.TitularGuest, 
                                                        booking.RoomId, 
                                                        new DateRangeResponse(booking.Duration.StartDate, 
                                                        booking.Duration.EndDate, booking.Duration.Days), 
                                                        new PriceSummaryBookingResponse(
                                                            booking.PriceDuration.Currency.Code,
                                                            booking.PriceDuration.Amount,booking.TotalTaxes.Amount, 
                                                            booking.TotalPrice.Amount),
                                                        booking.CreatedAt, 
                                                        booking.StatusBooking.ToString(), 
                                                        new EmergencyContactReponse(
                                                            booking.EmergencyContact.FullName, 
                                                            booking.EmergencyContact.PhoneNumber.Value))).ToList();

        return bookingResponses;
    }
}
