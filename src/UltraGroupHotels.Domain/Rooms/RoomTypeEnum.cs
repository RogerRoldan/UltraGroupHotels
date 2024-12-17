namespace UltraGroupHotels.Domain.Rooms
{
    public sealed partial record RoomType
    {
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
}