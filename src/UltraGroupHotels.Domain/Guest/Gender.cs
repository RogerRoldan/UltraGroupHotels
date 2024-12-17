namespace UltraGroupHotels.Domain.Guest;

public sealed record Gender
{
    public string Value { get; private set; }

    private Gender(string value)
    {
        Value = value;
    }

    public static Gender Create(string value)
    {
        if (string.IsNullOrWhiteSpace(value))
        {
            throw new ArgumentNullException(nameof(value));
        }

        if (!Enum.TryParse<GenderTypes>(value, true, out _))
        {
            throw new ArgumentException("Invalid type gender", nameof(value));
        }

        return new Gender(value);
    }

    public enum GenderTypes
    {
        Male,
        Female,
        Other
    }
}