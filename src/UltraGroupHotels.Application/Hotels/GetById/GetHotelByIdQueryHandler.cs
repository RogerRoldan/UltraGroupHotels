using ErrorOr;
using MediatR;
using UltraGroupHotels.Application.Hotels.Common;
using UltraGroupHotels.Domain.Hotels;

namespace UltraGroupHotels.Application.Hotels.GetById;


public sealed class GetHotelByIdQueryHandler : IRequestHandler<GetHotelByIdQuery, ErrorOr<HotelResponse>>
{
    private readonly IHotelRepository _hotelRepository;

    public GetHotelByIdQueryHandler(IHotelRepository hotelRepository)
    {
        _hotelRepository = hotelRepository ?? throw new ArgumentNullException(nameof(hotelRepository));
    }

    public async Task<ErrorOr<HotelResponse>> Handle(GetHotelByIdQuery request, CancellationToken cancellationToken)
    {
        var hotel = await _hotelRepository.GetByIdAsync(request.Id);

        if(hotel is null)
        {
            return Error.NotFound("Hotel.NotFound", "The hotel was not found");
        }

        var hotelResponse = new HotelResponse(
                                              hotel.Id, hotel.Name, 
                                              hotel.Description,
                                                new AddressResponse(
                                                    hotel.Address.Country, 
                                                    hotel.Address.State, 
                                                    hotel.Address.City, 
                                                    hotel.Address.ZipCode, 
                                                    hotel.Address.Street), 
                                                hotel.IsActive, 
                                                hotel.PhoneNumber.Value
        );

        return hotelResponse;
    }
}
