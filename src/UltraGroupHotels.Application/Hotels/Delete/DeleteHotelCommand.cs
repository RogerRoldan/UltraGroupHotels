using ErrorOr;
using MediatR;

namespace UltraGroupHotels.Application.Hotels.Delete;

public record DeleteHotelCommand(Guid Id) : IRequest<ErrorOr<Unit>>;
