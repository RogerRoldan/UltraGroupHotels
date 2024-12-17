namespace UltraGroupHotels.WebAPI.Controllers.Rooms;

public record UpdateRoomRequest(
    Guid Id,
    Guid HotelId,
    int RoomNumber,
    int QuantityGuestsAdults,
    int QuantityGuestsChildren,
    string RoomType,
    decimal BaseCostAmount,
    string BaseCostCurrency,
    decimal Taxes,
    bool IsActive
);
