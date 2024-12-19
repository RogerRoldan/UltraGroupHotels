namespace UltraGroupHotels.WebAPI.Controllers.Rooms;

public record GetAvailableRoomsRequest(DateOnly StartDate, DateOnly EndDate, int NumberOfGuests);