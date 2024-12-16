using MediatR;
using Microsoft.AspNetCore.Mvc;
using UltraGroupHotels.Application.Hotels.Create;
using UltraGroupHotels.Application.Hotels.Delete;
using UltraGroupHotels.Application.Hotels.GetAll;
using UltraGroupHotels.Application.Hotels.GetById;
using UltraGroupHotels.Application.Hotels.Update;

namespace UltraGroupHotels.WebAPI.Controllers.Hotels
{
    [ApiController]
    [Route("api/hotels")]
    public class HotelController : ApiController
    {
        private ISender _mediator;

        public HotelController(ISender mediator)
        {
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }

        [HttpGet]
        public async Task<IActionResult> GetAllHotels()
        {
            var result = await _mediator.Send(new GetAllHotelsQuery());

            return result.Match(
                hotels => Ok(hotels),
                errors => Problem(errors)
            );
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetHotelById(Guid id)
        {
            var result = await _mediator.Send(new GetHotelByIdQuery(id));

            return result.Match(
                hotel => Ok(hotel),
                errors => Problem(errors)
            );
        }

        [HttpPost]
        public async Task<IActionResult> CreateHotel(CreateHotelCommand command)
        {

            var result = await _mediator.Send(command);

            return result.Match(
                success => Ok(),
                errors => Problem(errors)
            );
        }

        [HttpPut]
        public async Task<IActionResult> UpdateHotel(UpdateHotelCommand command)
        {

            var result = await _mediator.Send(command);

            return result.Match(
                success => Ok(),
                errors => Problem(errors)
            );
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteHotel(Guid id)
        {
            var result = await _mediator.Send(new DeleteHotelCommand(id));

            return result.Match(
                success => Ok(),
                errors => Problem(errors)
            );
        }
    }
}
