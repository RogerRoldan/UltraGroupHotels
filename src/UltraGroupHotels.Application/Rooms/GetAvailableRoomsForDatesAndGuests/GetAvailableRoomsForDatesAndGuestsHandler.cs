using ErrorOr;
using MediatR;
using UltraGroupHotels.Application.Rooms.Common;
using UltraGroupHotels.Domain.Bookings;
using UltraGroupHotels.Domain.Hotels;
using UltraGroupHotels.Domain.Rooms;

namespace UltraGroupHotels.Application.Rooms.GetAvailableRoomsForDatesAndGuests;

public class GetAvailableRoomsForDatesAndGuestsHandler : IRequestHandler<GetAvailableRoomsForDatesAndGuestsQuery, ErrorOr<List<RoomAvailableResponse>>>
{

    private readonly IRoomRepository _roomRepository;
    private readonly IBookingRepository _bookingRepository;
    private readonly IHotelRepository _hotelRepository;

    public GetAvailableRoomsForDatesAndGuestsHandler(IRoomRepository roomRepository,
                                                     IBookingRepository bookingRepository,
                                                     IHotelRepository hotelRepository)
    {
        _roomRepository = roomRepository;
        _bookingRepository = bookingRepository;
        _hotelRepository = hotelRepository;
    }

    public async Task<ErrorOr<List<RoomAvailableResponse>>> Handle(GetAvailableRoomsForDatesAndGuestsQuery request, CancellationToken cancellationToken)
    {
        var hotel = await _hotelRepository.GetHotelByCityAsync(request.City, cancellationToken);
        var hotelsActiveCity = hotel.Where(hotel => hotel.IsActive).ToList();

        var rooms = await _roomRepository.GetRoomsByCapacityAsync(request.NumberOfGuests, cancellationToken);
        var roomsActive = rooms.Where(room => room.IsActive && hotelsActiveCity.Any(hotel => hotel.Id == room.HotelId)).ToList();

        var bookings = await _bookingRepository.GetOverlappingReservationsAsync(
                                                                                new DateRange(request.StartDate, 
                                                                                              request.EndDate), cancellationToken);


        List<Room> roomsAvailable = roomsActive
                                        .Where(room =>
                                        !bookings.Any(booking => booking.RoomId == room.Id)).ToList();

        var roomsAvailableResponse = roomsAvailable
            .Where(room => hotelsActiveCity.Any(hotel => hotel.Id == room.HotelId))
            .Select(room =>
            {
                var hotelInfo = hotelsActiveCity.First(hotel => hotel.Id == room.HotelId);
                return new RoomAvailableResponse(
                    room.Id,
                    room.HotelId,
                    hotelInfo.Name,
                    room.RoomNumber,
                    room.QuantityGuests,
                    room.RoomType.Value,
                    room.BaseCost.Amount,
                    room.BaseCost.Currency.Code,
                    room.Taxes.Value,
                    room.IsActive,
                    room.CreatedAt
                );
            })
            .ToList();

        return roomsAvailableResponse;
    }
}
