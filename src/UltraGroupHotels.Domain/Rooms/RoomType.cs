namespace UltraGroupHotels.Domain.Rooms
{
    public sealed partial record RoomType
    {
        public string Value { get; private set; }

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
    }
}