using System.Text.Json;
using System.Text.Json.Serialization;

namespace UltraGroupHotels.WebAPI.Common.DateConverter;

public class JsonDateOnlyConverter : JsonConverter<DateOnly>
{
    private const string Format = "yyyy-MM-dd";

    public override DateOnly Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        var stringValue = reader.GetString();

        if (string.IsNullOrWhiteSpace(stringValue))
        {
            return default;
        }


        return DateOnly.TryParseExact(stringValue, Format, out var dateOnlyValue)
            ? dateOnlyValue
            : default;
    }

    public override void Write(Utf8JsonWriter writer, DateOnly value, JsonSerializerOptions options)
    {
        writer.WriteStringValue(value.ToString(Format));
    }
}