using ErrorOr;
using MediatR;
using UltraGroupHotels.Domain.Implementations;
using UltraGroupHotels.Domain.Rooms;

namespace UltraGroupHotels.Application.Rooms.Delete
{
    public sealed class DeleteRoomCommandHandler : IRequestHandler<DeleteRoomCommand, ErrorOr<Unit>>
    {
        private readonly IRoomRepository _roomRepository;
        private readonly IUnitOfWork _unitOfWork;

        public DeleteRoomCommandHandler(IRoomRepository roomRepository, IUnitOfWork unitOfWork)
        {
            _roomRepository = roomRepository ?? throw new ArgumentNullException(nameof(roomRepository));
            _unitOfWork = unitOfWork;
        }

        public async Task<ErrorOr<Unit>> Handle(DeleteRoomCommand request, CancellationToken cancellationToken)
        {
            var room = await _roomRepository.GetByIdAsync(request.Id);

            if (room is null)
            {
                return Error.NotFound("Room", "Room not found");
            }

            _roomRepository.Delete(room);

            await _unitOfWork.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
