using MediatR;
using Microsoft.AspNetCore.Mvc;
using UltraGroupHotels.Application.Bookings.GetAll;
using UltraGroupHotels.Application.Bookings.GetById;

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

    }
}
