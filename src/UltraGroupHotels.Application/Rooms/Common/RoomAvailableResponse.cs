namespace UltraGroupHotels.Application.Rooms.Common;

public record RoomAvailableResponse(Guid Id,
                                    Guid HotelId,
                                    string HotelName,
                                    int RoomNumber,
                                    int QuantityGuests,
                                    string RoomType,
                                    decimal BaseCostAmount,
                                    string BaseCostCurrency,
                                    decimal Taxes,
                                    bool IsActive,
                                    DateTime CreatedAt);
