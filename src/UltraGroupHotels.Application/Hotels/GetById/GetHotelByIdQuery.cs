using ErrorOr;
using MediatR;
using UltraGroupHotels.Application.Hotels.Common;

namespace UltraGroupHotels.Application.Hotels.GetById;

public record GetHotelByIdQuery(Guid Id) : IRequest<ErrorOr<HotelResponse>>;
