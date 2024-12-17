﻿using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using UltraGroupHotels.Application.Rooms.Create;
using UltraGroupHotels.Application.Rooms.Delete;
using UltraGroupHotels.Application.Rooms.GetAll;
using UltraGroupHotels.Application.Rooms.Update;
using UltraGroupHotels.WebAPI.Controllers.Common;

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

    [Authorize]
    [HttpPost]
    public async Task<IActionResult> Create(CreateRoomRequest request)
    {
        var command = new CreateRoomCommand(
            request.HotelId,
            request.RoomNumber,
            request.QuantityGuestsAdults,
            request.QuantityGuestsChildren,
            request.RoomType,
            request.BaseCostAmount,
            request.BaseCostCurrency,
            request.Taxes,
            request.IsActive
        );

        var result = await _mediator.Send(command);

        var json = new { Id = result.Value };

        return result.Match(
            success => Created(nameof(Create), json),
            error => Problem(error)
        );
    }

    [Authorize]
    [HttpPut]
    public async Task<IActionResult> Update(UpdateRoomRequest request)
    {
        var command = new UpdateRoomCommand(
            request.Id,
            request.HotelId,
            request.RoomNumber,
            request.QuantityGuestsAdults,
            request.QuantityGuestsChildren,
            request.RoomType,
            request.BaseCostAmount,
            request.BaseCostCurrency,
            request.Taxes,
            request.IsActive
        );

        var result = await _mediator.Send(command);

        return result.Match(
            success => Ok(),
            error => Problem(error)
        );
    }


    [Authorize]
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
