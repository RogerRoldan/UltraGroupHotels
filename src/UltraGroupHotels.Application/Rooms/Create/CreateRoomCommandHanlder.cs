using ErrorOr;
using MediatR;
using UltraGroupHotels.Domain.CommonValueObjects;
using UltraGroupHotels.Domain.Hotels;
using UltraGroupHotels.Domain.Implementations;
using UltraGroupHotels.Domain.Rooms;

namespace UltraGroupHotels.Application.Rooms.Create;

public sealed class CreateRoomCommandHanlder : IRequestHandler<CreateRoomCommand, ErrorOr<Guid>>
{
    private readonly IRoomRepository _roomRepository;
    private readonly IHotelRepository _hotelRepository;
    private readonly IUnitOfWork _unitOfWork;

    public CreateRoomCommandHanlder(IRoomRepository roomRepository, IHotelRepository hotelRepository, IUnitOfWork unitOfWork)
    {
        _roomRepository = roomRepository ?? throw new ArgumentNullException(nameof(roomRepository));
        _hotelRepository = hotelRepository ?? throw new ArgumentNullException(nameof(hotelRepository));
        _unitOfWork = unitOfWork;
    }

    public async Task<ErrorOr<Guid>> Handle(CreateRoomCommand request, CancellationToken cancellationToken)
    {

        if( await _hotelRepository.ExistsAsync(request.HotelId) is false)
        {
            return Error.NotFound("Hotel", "Hotel not found");
        }

        var room = new Room(
            Guid.NewGuid(),
            request.HotelId,
            request.RoomNumber,
            new QuantityGuests(request.QuantityGuestsAdults, request.QuantityGuestsChildren),
            RoomType.Create(request.RoomType),
            new Money(request.BaseCostAmount, Currency.FromCode(request.BaseCostCurrency)), 
            Taxes.FromValue(request.Taxes), request.IsActive, 
            DateTime.UtcNow);

        _roomRepository.Add(room);

        await _unitOfWork.SaveChangesAsync(cancellationToken);

        return room.Id;
    }
}
