using ErrorOr;
using MediatR;

namespace UltraGroupHotels.Application.Rooms.Delete;

public record DeleteRoomCommand(Guid Id) : IRequest<ErrorOr<Unit>>;
