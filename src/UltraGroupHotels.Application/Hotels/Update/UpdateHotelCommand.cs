using ErrorOr;
using MediatR;

namespace UltraGroupHotels.Application.Hotels.Update;

public record UpdateHotelCommand(Guid Id, 
                                 string Name, 
                                 string Description, 
                                 string Country, 
                                 string State, 
                                 string City, 
                                 string ZipCode, 
                                 string Street, 
                                 bool IsActive, 
                                 string PhoneNumber) : IRequest<ErrorOr<Unit>>;
