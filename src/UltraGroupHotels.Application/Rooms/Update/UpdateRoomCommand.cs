using ErrorOr;
using MediatR;

namespace UltraGroupHotels.Application.Rooms.Update;

public record UpdateRoomCommand(Guid Id, 
                                Guid HotelId, 
                                int RoomNumber, 
                                int QuantityGuests,  
                                string RoomType, 
                                decimal BaseCostAmount, 
                                string BaseCostCurrency, 
                                decimal Taxes, 
                                bool IsActive) : IRequest<ErrorOr<Unit>>;
