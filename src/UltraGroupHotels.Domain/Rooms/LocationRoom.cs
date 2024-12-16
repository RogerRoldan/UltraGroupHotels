namespace UltraGroupHotels.Domain.Rooms;

public record LocationRoom 
{ 
    public string Floor { get; init; }
    public string Sector { get; init; }
    public string? Description { get; init; }

    public LocationRoom(string floor, string sector, string? description)
    {
        Floor = floor;
        Sector = sector;
        Description = description ?? string.Empty;
    }
}