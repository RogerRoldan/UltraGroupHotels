using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Win32;
using UltraGroupHotels.Application.Bookings.GetAll;
using UltraGroupHotels.Application.Bookings.GetById;
using UltraGroupHotels.Application.Bookings.ReserveRoom;

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

        [HttpGet]
        public async Task<IActionResult> GetAllBookings()
        {
            var result = await _sender.Send(new GetAllBookingsQuery());

            return result.Match(
                bookings => Ok(bookings),
                errors => Problem(errors)
            );
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetBookingById(Guid id)
        {
            var result = await _sender.Send(new GetBookingByIdQuery(id));

            return result.Match(
                booking => Ok(booking),
                errors => Problem(errors)
            );
        }

        [HttpPost]
        public async Task<IActionResult> CreateBooking(ReserveRoomCommand command)
        {
            var result = await _sender.Send(command);

            var jsonId = new { Id = result.Value };
            return result.Match(
                booking => Created(nameof(CreateBooking), jsonId),
                errors => Problem(errors)
            );
        }

    }
}
