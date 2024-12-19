using ErrorOr;
using MediatR;
using UltraGroupHotels.Application.Rooms.Common;
using UltraGroupHotels.Domain.Bookings;
using UltraGroupHotels.Domain.Rooms;

namespace UltraGroupHotels.Application.Rooms.GetAvailableRoomsForDatesAndGuests;

public class GetAvailableRoomsForDatesAndGuestsHandler : IRequestHandler<GetAvailableRoomsForDatesAndGuestsQuery, ErrorOr<List<RoomResponse>>>
{

    private readonly IRoomRepository _roomRepository;
    private readonly IBookingRepository _bookingRepository;

    public GetAvailableRoomsForDatesAndGuestsHandler(IRoomRepository roomRepository,
                                                     IBookingRepository bookingRepository)
    {
        _roomRepository = roomRepository;
        _bookingRepository = bookingRepository;
    }

    public async Task<ErrorOr<List<RoomResponse>>> Handle(GetAvailableRoomsForDatesAndGuestsQuery request, CancellationToken cancellationToken)
    {
        var rooms = await _roomRepository.GetRoomsByCapacityAsync(request.NumberOfGuests, cancellationToken);
        var roomsActive = rooms.Where(room => room.IsActive).ToList();

        var bookings = await _bookingRepository.GetOverlappingReservationsAsync(
                                                                                new DateRange(request.StartDate, 
                                                                                              request.EndDate), cancellationToken);


        List<Room> roomsAvailable = roomsActive
                                        .Where(room =>
                                        !bookings.Any(booking => booking.RoomId == room.Id)).ToList();

        var roomsAvailableResponse = roomsAvailable.Select(
                                                    room => new RoomResponse(room.Id,
                                                                             room.HotelId,
                                                                             room.RoomNumber,
                                                                             room.QuantityGuests,
                                                                             room.RoomType.Value,
                                                                             room.BaseCost.Amount, room.BaseCost.Currency.Code,
                                                                             room.Taxes.Value,
                                                                             room.IsActive,
                                                                             room.CreatedAt)).ToList();

        return roomsAvailableResponse;
    }
}
