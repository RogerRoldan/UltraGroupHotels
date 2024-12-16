using UltraGroupHotels.Domain.SharedValueObjects;

namespace UltraGroupHotels.Domain.Bookings;

public class EmergencyContact
{
    public string FullName { get; private set; }
    public PhoneNumber PhoneNumber { get; private set; }

    public EmergencyContact(string fullName, PhoneNumber phoneNumber)
    {
        FullName = fullName;
        PhoneNumber = phoneNumber;
    }


}