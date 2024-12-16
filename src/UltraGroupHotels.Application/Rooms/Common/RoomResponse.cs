﻿namespace UltraGroupHotels.Application.Rooms.Common;

public record RoomResponse(Guid Id, Guid HotelId, int RoomNumber, int QuantityGuestsAdults, int QuantityGuestsChildren, string RoomType, decimal BaseCostAmount, string BaseCostCurrency, decimal TaxesValue, bool IsActive, DateTime CreatedAt);