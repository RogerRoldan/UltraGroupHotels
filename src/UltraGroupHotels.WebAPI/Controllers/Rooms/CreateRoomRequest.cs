namespace UltraGroupHotels.WebAPI.Controllers.Rooms;

public record CreateRoomRequest(
    Guid HotelId,
    int RoomNumber,
    int QuantityGuestsAdults,
    int QuantityGuestsChildren,
    string RoomType,
    decimal BaseCostAmount,
    string BaseCostCurrency,
    decimal Taxes,
    bool IsActive);

