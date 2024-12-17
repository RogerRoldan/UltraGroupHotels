using UltraGroupHotels.Domain.SharedValueObjects;

namespace UltraGroupHotels.Domain.Guest;

public class Guest
{
    public Guid Id { get; private set; }
    public Guid BookingId { get; private set; }
    public string FirstName { get; private set; }
    public string LastName { get; private set; }
    public DateOnly DateOfBirth { get; private set; }
    public Gender Gender { get; private set; }
    public TypeDocument TypeDocument { get; private set; }
    public DocumentNumber DocumentNumber { get; private set; }
    public string Email { get; private set; }
    public PhoneNumber PhoneNumber { get; private set; }

    public Guest(
        Guid id,
        Guid bookingId,
        string firstName,
        string lastName,
        DateOnly dateOfBirth,
        Gender gender,
        TypeDocument typeDocument,
        DocumentNumber documentNumber,
        string email,
        PhoneNumber phoneNumber)
    {
        Id = id;
        BookingId = bookingId;
        FirstName = firstName;
        LastName = lastName;
        DateOfBirth = dateOfBirth;
        Gender = gender;
        TypeDocument = typeDocument;
        DocumentNumber = documentNumber;
        Email = email;
        PhoneNumber = phoneNumber;
    }

    public Guest()
    {        
    }

}