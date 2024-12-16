using ErrorOr;
using MediatR;
using UltraGroupHotels.Application.Rooms.Common;

namespace UltraGroupHotels.Application.Rooms.GetAll;

public record GetAllRoomsQuery() : IRequest<ErrorOr<IEnumerable<RoomResponse>>>;
