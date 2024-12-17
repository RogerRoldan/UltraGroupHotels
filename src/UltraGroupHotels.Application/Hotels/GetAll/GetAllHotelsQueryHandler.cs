using ErrorOr;
using MediatR;
using UltraGroupHotels.Application.Hotels.Common;
using UltraGroupHotels.Domain.Hotels;

namespace UltraGroupHotels.Application.Hotels.GetAll;

public sealed class GetAllHotelsQueryHandler : IRequestHandler<GetAllHotelsQuery, ErrorOr<IEnumerable<HotelResponse>>>
{
    private readonly IHotelRepository _hotelRepository;

    public GetAllHotelsQueryHandler(IHotelRepository hotelRepository)
    {
        _hotelRepository = hotelRepository ?? throw new ArgumentNullException(nameof(hotelRepository));
    }

    public async Task<ErrorOr<IEnumerable<HotelResponse>>> Handle(GetAllHotelsQuery request, CancellationToken cancellationToken)
    {
        var hotels = await _hotelRepository.GetAllAsync();

        var hotelResponses = hotels.Select(hotel => 
                                                new HotelResponse(
                                                                   hotel.Id, 
                                                                   hotel.Name, 
                                                                   hotel.Description,
                                                                        new AddressResponse(hotel.Address.Country, 
                                                                                            hotel.Address.State, 
                                                                                            hotel.Address.City, 
                                                                                            hotel.Address.ZipCode, 
                                                                                            hotel.Address.Street), 
                                                                   hotel.IsActive, 
                                                                   hotel.PhoneNumber.Value)).ToList();

        return hotelResponses;
    }
}
