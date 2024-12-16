namespace UltraGroupHotels.Domain.CommonValueObjects;

public sealed record Taxes
{
    public decimal Value { get; }

    private Taxes(decimal value)
    {
        Value = value;
    }

    public static Taxes Create(decimal value)
    {
        if (value < 0)
        {
            throw new ArgumentException("Taxes value must be greater than or equal to zero.");
        }

        if (value > 100)
        {
            throw new ArgumentException("Taxes value must be less than or equal to 100.");
        }

        return new Taxes(value);
    }

    public static Taxes FromValue(decimal value)
    {
        return new Taxes(value);
    }
}