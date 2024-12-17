using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using UltraGroupHotels.Application.Bookings.GetAll;
using UltraGroupHotels.Application.Bookings.GetById;
using UltraGroupHotels.Application.Bookings.ReserveRoom;
using UltraGroupHotels.WebAPI.Controllers.Bookings.ReservationRoom;
using UltraGroupHotels.WebAPI.Controllers.Common;

namespace UltraGroupHotels.WebAPI.Controllers.Bookings
{
    [ApiController]
    [Route("api/bookings")]
    public class BookingController : ApiController
    {
        private readonly ISender _sender;

        public BookingController(ISender sender)
        {
            _sender = sender ?? throw new ArgumentNullException(nameof(sender));
        }

        [Authorize]
        [HttpGet]
        public async Task<IActionResult> GetAllBookings()
        {
            var result = await _sender.Send(new GetAllBookingsQuery());

            return result.Match(
                bookings => Ok(bookings),
                errors => Problem(errors)
            );
        }

        [Authorize]
        [HttpGet("details/{id}")]
        public async Task<IActionResult> GetBookingById(Guid id)
        {
            var result = await _sender.Send(new GetBookingByIdQuery(id));

            return result.Match(
                booking => Ok(booking),
                errors => Problem(errors)
            );
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> CreateBooking(ReserveRoomRequest request)
        {
            var guestCommands = request.Guests.Select(g => new GuestCommand(
                g.FirstName,
                g.LastName,
                g.DateOfBirth,
                g.Gender,
                g.TypeDocument,
                g.DocumentNumber,
                g.Email,
                g.PhoneNumber
            )).ToList();

            var command = new ReserveRoomCommand(
                request.RoomId,
                request.CustomerId,
                request.StartDate,
                request.EndDate,
                request.EmergencyContactFullName,
                request.EmergencyContactPhoneNumber,
                guestCommands
            );

            var result = await _sender.Send(command);

            var jsonId = new { Id = result.Value };
            return result.Match(
                booking => Created(nameof(CreateBooking), jsonId),
                errors => Problem(errors)
            );
        }



    }
}
