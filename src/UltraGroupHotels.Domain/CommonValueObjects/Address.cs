namespace UltraGroupHotels.Domain.CommonValueObjects;

public sealed record Address
{
    public string Country { get; init; }
    public string State { get; init; }
    public string City { get; init; }
    public string ZipCode { get; init; }
    public string Street { get; init; }

    private Address(string country, string state, string city, string zipCode, string street)
    {
        Country = country;
        State = state;
        City = city;
        ZipCode = zipCode;
        Street = street;
    }

    public static Address? Create(string country, string state, string city, string zipCode, string street)
    {
        if (string.IsNullOrWhiteSpace(country) || string.IsNullOrWhiteSpace(state) || string.IsNullOrWhiteSpace(city) || string.IsNullOrWhiteSpace(zipCode) || string.IsNullOrWhiteSpace(street))
        {
            return null;
        }

        return new Address(country, state, city, zipCode, street);
    }


}
