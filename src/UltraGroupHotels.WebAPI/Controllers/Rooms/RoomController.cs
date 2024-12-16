using MediatR;
using Microsoft.AspNetCore.Mvc;
using UltraGroupHotels.Application.Rooms.Create;
using UltraGroupHotels.Application.Rooms.Delete;
using UltraGroupHotels.Application.Rooms.GetAll;
using UltraGroupHotels.Application.Rooms.Update;

namespace UltraGroupHotels.WebAPI.Controllers.Rooms;

[ApiController]
[Route("api/rooms")]
public class RoomController : ApiController
{
    private readonly IMediator _mediator;

    public RoomController(IMediator mediator)
    {
        _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var result = await _mediator.Send(new GetAllRoomsQuery());

        return result.Match(
            hotels => Ok(hotels),
            error => Problem(error)
        );
    }

    [HttpPost]
    public async Task<IActionResult> Create(CreateRoomCommand command)
    {
        var result = await _mediator.Send(command);

        return result.Match(
            success => Ok(),
            error => Problem(error)
        );
    }

    [HttpPut]
    public async Task<IActionResult> Update(UpdateRoomCommand command)
    {
        var result = await _mediator.Send(command);

        return result.Match(
            success => Ok(),
            error => Problem(error)
        );
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(Guid id)
    {
        var result = await _mediator.Send(new DeleteRoomCommand(id));

        return result.Match(
            success => Ok(),
            error => Problem(error)
        );
    }
}
