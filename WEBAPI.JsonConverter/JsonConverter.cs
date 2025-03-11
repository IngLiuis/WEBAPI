using System.Text.Json.Serialization;
using System.Text.Json;

namespace WEBAPI.JsonConverter
{
    public class UtcDateTimeJsonConverter : JsonConverter<DateTime>
    {
        private const string DateFormat = "dd/MM/yyyy HH:mm:ss"; // Imposta il formato della data

        public override DateTime Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            string dateString = reader.GetString();
            return DateTime.ParseExact(dateString, DateFormat, null);
        }

        public override void Write(Utf8JsonWriter writer, DateTime value, JsonSerializerOptions options)
        {
            writer.WriteStringValue(value.ToString(DateFormat));
        }
    }
}
