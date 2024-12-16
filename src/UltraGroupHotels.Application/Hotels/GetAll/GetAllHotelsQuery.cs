using ErrorOr;
using MediatR;
using UltraGroupHotels.Application.Hotels.Common;

namespace UltraGroupHotels.Application.Hotels.GetAll;

public record GetAllHotelsQuery() : IRequest<ErrorOr<IEnumerable<HotelResponse>>>;
