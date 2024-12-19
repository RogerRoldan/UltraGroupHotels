using ErrorOr;
using MediatR;
using UltraGroupHotels.Domain.CommonValueObjects;
using UltraGroupHotels.Domain.Implementations;
using UltraGroupHotels.Domain.Rooms;

namespace UltraGroupHotels.Application.Rooms.Update;

public sealed class UpdateRoomCommandHandler : IRequestHandler<UpdateRoomCommand, ErrorOr<Unit>>
{
    private readonly IRoomRepository _roomRepository;
    private readonly IUnitOfWork _unitOfWork;

    public UpdateRoomCommandHandler(IRoomRepository roomRepository, IUnitOfWork unitOfWork)
    {
        _roomRepository = roomRepository ?? throw new ArgumentNullException(nameof(roomRepository));
        _unitOfWork = unitOfWork;
    }

    public async Task<ErrorOr<Unit>> Handle(UpdateRoomCommand request, CancellationToken cancellationToken)
    {
        var room = await _roomRepository.GetByIdAsync(request.Id, cancellationToken);

        if (room is null)
        {
            return Error.NotFound("Room", "Room not found");
        }

        var updatedRoom = new Room(
            request.Id,
            request.HotelId,
            request.RoomNumber,
            request.QuantityGuests,
            RoomType.Create(request.RoomType),
            new Money(request.BaseCostAmount, Currency.FromCode(request.BaseCostCurrency)),
            Taxes.FromValue(request.Taxes),
            request.IsActive,
            room.CreatedAt);

         _roomRepository.Update(updatedRoom);

        await _unitOfWork.SaveChangesAsync(cancellationToken);


        return Unit.Value;
    }
}
