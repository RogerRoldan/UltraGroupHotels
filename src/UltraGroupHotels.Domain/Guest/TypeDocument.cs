namespace UltraGroupHotels.Domain.Guest;

public sealed record TypeDocument
{
    public string Value { get; private set; }

    private TypeDocument(string value)
    {
        Value = value;
    }

    public static TypeDocument Create(string value)
    {
        if (string.IsNullOrWhiteSpace(value))
        {
            throw new ArgumentNullException(nameof(value));
        }

        if (!Enum.TryParse<TypeDocumentValids>(value, true, out _))
        {
            throw new ArgumentException("Invalid type document", nameof(value));
        }

        return new TypeDocument(value);
    }
}
