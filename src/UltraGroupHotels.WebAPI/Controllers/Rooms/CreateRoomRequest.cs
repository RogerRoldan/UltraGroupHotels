namespace UltraGroupHotels.WebAPI.Controllers.Rooms;

public record CreateRoomRequest(
    Guid HotelId,
    int RoomNumber,
    int QuantityGuests,
    string RoomType,
    decimal BaseCostAmount,
    string BaseCostCurrency,
    decimal Taxes,
    bool IsActive);

