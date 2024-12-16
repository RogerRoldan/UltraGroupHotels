public class RoomType
{
    public string Value { get; }

    private RoomType(string value)
    {
        Value = value;
    }

    public static RoomType Create(string value) 
    {
        if (string.IsNullOrWhiteSpace(value))
        {
            throw new ArgumentNullException(nameof(value));
        }

        if (!Enum.TryParse<RoomTypeEnum>(value, true, out _))
        {
            throw new ArgumentException("Invalid room type", nameof(value));
        }

        return new RoomType(value);
    }

    public enum RoomTypeEnum
    {
        Single,
        Double,
        Triple,
        Quad,
        Queen,
        King,
        Twin,
        Studio,
        Suite,
        MasterSuite,
        PresidentialSuite
    }
}
