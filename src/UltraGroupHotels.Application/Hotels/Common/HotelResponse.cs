namespace UltraGroupHotels.Application.Hotels.Common;

public record HotelResponse(Guid Id, 
                            string Name, 
                            string Description, 
                            AddressResponse Address, 
                            bool IsActive, 
                            string PhoneNumber);

public record AddressResponse(string Country, 
                              string State, 
                              string City, 
                              string ZipCode, 
                              string Street);

