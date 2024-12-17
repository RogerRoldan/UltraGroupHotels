using ErrorOr;
using MediatR;

namespace UltraGroupHotels.Application.Rooms.Create;

public record CreateRoomCommand(Guid HotelId, 
                                int RoomNumber, 
                                int QuantityGuestsAdults, 
                                int QuantityGuestsChildren, 
                                string RoomType, 
                                decimal BaseCostAmount, 
                                string BaseCostCurrency, 
                                decimal Taxes, 
                                bool IsActive) : IRequest<ErrorOr<Guid>>;
