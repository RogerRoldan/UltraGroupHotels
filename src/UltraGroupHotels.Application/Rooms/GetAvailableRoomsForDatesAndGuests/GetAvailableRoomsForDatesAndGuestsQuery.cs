using ErrorOr;
using MediatR;
using UltraGroupHotels.Application.Rooms.Common;

namespace UltraGroupHotels.Application.Rooms.GetAvailableRoomsForDatesAndGuests;

public record GetAvailableRoomsForDatesAndGuestsQuery(DateOnly StartDate,
                                                      DateOnly EndDate,
                                                      int NumberOfGuests) :                                                                          IRequest<ErrorOr<List<RoomResponse>>>;
