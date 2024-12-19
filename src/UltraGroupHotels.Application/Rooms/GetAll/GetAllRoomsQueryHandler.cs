using ErrorOr;
using MediatR;
using UltraGroupHotels.Application.Rooms.Common;
using UltraGroupHotels.Domain.Rooms;

namespace UltraGroupHotels.Application.Rooms.GetAll;

public sealed class GetAllRoomsQueryHandler : IRequestHandler<GetAllRoomsQuery, ErrorOr<IEnumerable<RoomResponse>>>
{
    private readonly IRoomRepository _roomRepository;

    public GetAllRoomsQueryHandler(IRoomRepository roomRepository)
    {
        _roomRepository = roomRepository ?? throw new ArgumentNullException(nameof(roomRepository));
    }

    public async Task<ErrorOr<IEnumerable<RoomResponse>>> Handle(GetAllRoomsQuery request, CancellationToken cancellationToken)
    {
        var rooms = await _roomRepository.GetAllAsync(cancellationToken);

        var roomResponses = rooms.Select(room => new RoomResponse(
                                                                  room.Id, 
                                                                  room.HotelId, 
                                                                  room.RoomNumber, 
                                                                  room.QuantityGuests,  
                                                                  room.RoomType.Value, 
                                                                  room.BaseCost.Amount, 
                                                                  room.BaseCost.Currency.Code, 
                                                                  room.Taxes.Value, 
                                                                  room.IsActive, 
                                                                  room.CreatedAt)).ToList();

        return roomResponses;
    }
}
