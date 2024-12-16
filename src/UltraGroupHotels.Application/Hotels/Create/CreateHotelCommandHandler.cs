using ErrorOr;
using MediatR;
using UltraGroupHotels.Domain.CommonValueObjects;
using UltraGroupHotels.Domain.Hotels;
using UltraGroupHotels.Domain.Implementations;
using UltraGroupHotels.Domain.SharedValueObjects;

namespace UltraGroupHotels.Application.Hotels.Create;

public sealed class CreateHotelCommandHandler : IRequestHandler<CreateHotelCommand, ErrorOr<Guid>>
{
    public readonly IHotelRepository _hotelRepository;
    public readonly IUnitOfWork _unitOfWork;

    public CreateHotelCommandHandler(IHotelRepository hotelRepository, IUnitOfWork unitOfWork)
    {
        _hotelRepository = hotelRepository ?? throw new ArgumentNullException(nameof(hotelRepository));
        _unitOfWork = unitOfWork;
    }


    public async Task<ErrorOr<Guid>> Handle(CreateHotelCommand request, CancellationToken cancellationToken)
    {
        if(PhoneNumber.Create(request.PhoneNumber) is not PhoneNumber phoneNumber)
        {
            return Error.Validation("Hotel.PhoneNumber", "Phone number is invalid");
        }

        if(Address.Create(request.Country, request.State, request.City, request.ZipCode, request.Street) is not Address address)
        {
            return Error.Validation("Hotel.Address", "Address is invalid");
        }

        var hotel = new Hotel(Guid.NewGuid(), request.Name, request.Description, address, request.IsActive, phoneNumber);

        _hotelRepository.Add(hotel);

        await _unitOfWork.SaveChangesAsync(cancellationToken);

        return hotel.Id;
    }
}
