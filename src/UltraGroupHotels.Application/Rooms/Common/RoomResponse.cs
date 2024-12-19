namespace UltraGroupHotels.Application.Rooms.Common;

public record RoomResponse(Guid Id, 
                           Guid HotelId, 
                           int RoomNumber, 
                           int QuantityGuests, 
                           string RoomType, 
                           decimal BaseCostAmount, 
                           string BaseCostCurrency, 
                           decimal Taxes, 
                           bool IsActive, 
                           DateTime CreatedAt);
