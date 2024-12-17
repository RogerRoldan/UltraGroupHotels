using ErrorOr;
using MediatR;
using UltraGroupHotels.Domain.CommonValueObjects;
using UltraGroupHotels.Domain.Hotels;
using UltraGroupHotels.Domain.Implementations;
using UltraGroupHotels.Domain.SharedValueObjects;

namespace UltraGroupHotels.Application.Hotels.Update;

public sealed class UpdateHotelCommandHandler : IRequestHandler<UpdateHotelCommand, ErrorOr<Unit>>
{
    private readonly IHotelRepository _hotelRepository;
    private readonly IUnitOfWork _unitOfWork;

    public UpdateHotelCommandHandler(IHotelRepository hotelRepository, IUnitOfWork unitOfWork)
    {
        _hotelRepository = hotelRepository ?? throw new ArgumentNullException(nameof(hotelRepository));
        _unitOfWork = unitOfWork;
    }

    public async Task<ErrorOr<Unit>> Handle(UpdateHotelCommand request, CancellationToken cancellationToken)
    {
        var hotel = await _hotelRepository.ExistsAsync(request.Id, cancellationToken);

        if (!hotel) 
        {
            return Error.NotFound("Hotel.NotFound", "Hotel not found");
        }

        if (PhoneNumber.Create(request.PhoneNumber) is not PhoneNumber phoneNumber)
        {
            return Error.Validation("Hotel.PhoneNumber", "Phone number is invalid");
        }

        if (Address.Create(request.Country, request.State, request.City, request.ZipCode, request.Street) is not Address address)
        {
            return Error.Validation("Hotel.Address", "Address is invalid");
        }

        var updatedHotel = new Hotel(
                                    request.Id, 
                                    request.Name, 
                                    request.Description, 
                                    address, 
                                    request.IsActive, 
                                    phoneNumber);

        _hotelRepository.Update(updatedHotel);

        await _unitOfWork.SaveChangesAsync(cancellationToken);

        return Unit.Value;
    }
}
