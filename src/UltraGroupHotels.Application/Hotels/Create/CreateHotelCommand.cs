using ErrorOr;
using MediatR;

namespace UltraGroupHotels.Application.Hotels.Create;

public record CreateHotelCommand(string Name, string Description, string Country, string State, string City, string ZipCode, string Street, bool IsActive, string PhoneNumber) : IRequest<ErrorOr<Guid>>;
