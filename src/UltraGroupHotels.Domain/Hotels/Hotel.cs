using UltraGroupHotels.Domain.CommonValueObjects;
using UltraGroupHotels.Domain.Implementations;
using UltraGroupHotels.Domain.SharedValueObjects;

namespace UltraGroupHotels.Domain.Hotels;

public class Hotel : Entity
{
    public Guid Id { get; private set; }
    public string Name { get; private set; }
    public string Description { get; private set; }
    public Address Address { get; private set; }
    public bool IsActive { get; private set; }
    public DateTime CreatedAt { get; private set; }
    public PhoneNumber PhoneNumber { get; private set; }

    public Hotel(Guid id, 
                 string name, 
                 string description, 
                 Address address, 
                 bool isActive, 
                 PhoneNumber phoneNumber)
    {
        Id = id;
        Name = name;
        Description = description;
        Address = address;
        IsActive = isActive;
        CreatedAt = DateTime.UtcNow;
        PhoneNumber = phoneNumber;
    }

    public Hotel(){}

}
