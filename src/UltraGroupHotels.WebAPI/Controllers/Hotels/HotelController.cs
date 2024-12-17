using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using UltraGroupHotels.Application.Hotels.Create;
using UltraGroupHotels.Application.Hotels.Delete;
using UltraGroupHotels.Application.Hotels.GetAll;
using UltraGroupHotels.Application.Hotels.GetById;
using UltraGroupHotels.Application.Hotels.Update;
using UltraGroupHotels.WebAPI.Controllers.Common;

namespace UltraGroupHotels.WebAPI.Controllers.Hotels;


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

    [Authorize]
    [HttpPost]
    public async Task<IActionResult> CreateHotel(CreateHotelRequest request)
    {
        var command = new CreateHotelCommand(
            request.Name,
            request.Description,
            request.Country,
            request.State,
            request.City,
            request.ZipCode,
            request.Street,
            request.IsActive,
            request.PhoneNumber
        );

        var result = await _mediator.Send(command);

        var jsonId = new { Id = result.Value };

        return result.Match(
            success => Created(nameof(CreateHotel), jsonId),
            errors => Problem(errors)
        );
    }


    [Authorize]
    [HttpPut]
    public async Task<IActionResult> UpdateHotel(UpdateHotelRequest request)
    {
        var command = new UpdateHotelCommand(
            request.Id,
            request.Name,
            request.Description,
            request.Country,
            request.State,
            request.City,
            request.ZipCode,
            request.Street,
            request.IsActive,
            request.PhoneNumber
        );

        var result = await _mediator.Send(command);

        return result.Match(
            success => Ok(),
            errors => Problem(errors)
        );
    }


    [Authorize]
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
