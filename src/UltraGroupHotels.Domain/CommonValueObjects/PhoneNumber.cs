using System.Text.RegularExpressions;

namespace UltraGroupHotels.Domain.SharedValueObjects
{
    public partial record PhoneNumber
    {
        private const int DefaultLength = 15;
        public const string Pattern = @"^\+[1-9]{1}[0-9]{6,14}$";

        public string Value { get; }

        private PhoneNumber(string value)
        {
            Value = value;
        }

        public static PhoneNumber? Create(string value)
        {
            if (string.IsNullOrWhiteSpace(value) || !PhoneNumberRegex().IsMatch(value) || value.Length != DefaultLength)
            {
                return null;
            }

            return new PhoneNumber(value);
        }

        [GeneratedRegex(Pattern)]
        private static partial Regex PhoneNumberRegex();
    }
}
