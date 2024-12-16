using ErrorOr;
using MediatR;
using UltraGroupHotels.Domain.Hotels;
using UltraGroupHotels.Domain.Implementations;

namespace UltraGroupHotels.Application.Hotels.Delete;

public sealed class DeleteHotelCommandHandler : IRequestHandler<DeleteHotelCommand, ErrorOr<Unit>>
{
    private readonly IHotelRepository _hotelRepository;
    private readonly IUnitOfWork _unitOfWork;


    public DeleteHotelCommandHandler(IHotelRepository hotelRepository, IUnitOfWork unitOfWork)
    {
        _hotelRepository = hotelRepository ?? throw new ArgumentNullException(nameof(hotelRepository));
        _unitOfWork = unitOfWork;
    }


    public async Task<ErrorOr<Unit>> Handle(DeleteHotelCommand request, CancellationToken cancellationToken)
    {
        var hotel = await _hotelRepository.GetByIdAsync(request.Id);

        if (hotel is null)
        {
            return Error.NotFound("Hotel.NotFound", "Hotel not found");
        }

        _hotelRepository.Delete(hotel);

        await _unitOfWork.SaveChangesAsync(cancellationToken);

        return Unit.Value;
    }
}
