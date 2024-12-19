using UltraGroupHotels.Domain.CommonValueObjects;
using UltraGroupHotels.Domain.Implementations;

namespace UltraGroupHotels.Domain.Rooms;

public class Room : Entity
{
    public Guid Id { get; private set; }
    public Guid HotelId { get; private set; }
    public int RoomNumber { get; private set; }
    public int QuantityGuests { get; private set; }
    public RoomType RoomType { get; private set; }
    public Money BaseCost { get; private set; }
    public Taxes Taxes { get; private set; }
    public bool IsActive { get; private set; }
    public DateTime CreatedAt { get; private set; }

    public Room(Guid id,
                Guid hotelId, 
                int roomNumber, 
                int quantityGuests, 
                RoomType roomType, 
                Money baseCost, 
                Taxes taxes, 
                bool isActive, 
                DateTime createdAt)
    {
        Id = id;
        HotelId = hotelId;
        RoomNumber = roomNumber;
        QuantityGuests = quantityGuests;
        RoomType = roomType;
        BaseCost = baseCost;
        Taxes = taxes;
        IsActive = isActive;
        CreatedAt = createdAt;
    }

    public Room()
    {
        
    }
}
