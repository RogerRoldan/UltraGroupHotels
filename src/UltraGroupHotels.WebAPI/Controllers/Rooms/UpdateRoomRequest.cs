namespace UltraGroupHotels.WebAPI.Controllers.Rooms;

public record UpdateRoomRequest(
    Guid Id,
    Guid HotelId,
    int RoomNumber,
    int QuantityGuests,
    string RoomType,
    decimal BaseCostAmount,
    string BaseCostCurrency,
    decimal Taxes,
    bool IsActive
);
