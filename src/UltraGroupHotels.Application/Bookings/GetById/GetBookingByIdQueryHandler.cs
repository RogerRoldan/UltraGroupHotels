using ErrorOr;
using MediatR;
using UltraGroupHotels.Application.Bookings.Common;
using UltraGroupHotels.Domain.Bookings;
using UltraGroupHotels.Infrastructure.Persistence.Repositories;

namespace UltraGroupHotels.Application.Bookings.GetById
{
    public sealed class GetBookingByIdQueryHandler : IRequestHandler<GetBookingByIdQuery, ErrorOr<BookingResponse>>
    {
        private readonly IBookingRepository _bookingRepository;
        private readonly IGuestRepository _guestRepository;

        public GetBookingByIdQueryHandler(IBookingRepository bookingRepository, IGuestRepository guestRepository)
        {
            _bookingRepository = bookingRepository;
            _guestRepository = guestRepository;
        }


        public async Task<ErrorOr<BookingResponse>> Handle(GetBookingByIdQuery request, CancellationToken cancellationToken)
        {
            var booking = await _bookingRepository.GetBookingByIdAsync(request.Id, cancellationToken); 

            if (booking is null)
            {
                return Error.NotFound("Booking", "Booking not found");
            }

            var guests =  _guestRepository.GetGuestsByBookingId(booking.Id);


            var bookingResponse = new BookingDetailsResponse(
                                                      booking.Id, 
                                                      booking.UserId, 
                                                      booking.RoomId, 
                                                      new DateRangeResponse(
                                                          booking.Duration.StartDate, 
                                                          booking.Duration.EndDate, 
                                                          booking.Duration.Days), 
                                                      new PriceSummaryBookingResponse(
                                                          booking.PriceDuration.Currency.ToString(), 
                                                          booking.PriceDuration.Amount, 
                                                          booking.TotalTaxes.Amount, 
                                                          booking.TotalPrice.Amount), 
                                                      booking.CreatedAt, 
                                                      booking.StatusBooking.ToString(), 
                                                      new EmergencyContactReponse(
                                                          booking.EmergencyContact.FullName, 
                                                          booking.EmergencyContact.PhoneNumber.Value),
                                                      guests.Select(g => new GuestResponse(g.FirstName, 
                                                                                           g.LastName, 
                                                                                           g.DateOfBirth, 
                                                                                           g.Gender.Value, 
                                                                                           g.TypeDocument.Value, 
                                                                                           g.DocumentNumber.Value, 
                                                                                           g.Email, 
                                                                                           g.PhoneNumber.Value)).ToList());

            return bookingResponse;
        }
    }
}
