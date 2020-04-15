using System;
using System.Text.Json;
using System.Text.Json.Serialization;
using static System.Boolean;
using static System.String;

namespace ProjetoBase.Domain.ValueObjects.JsonConverters
{
    public abstract class BooleanConverter<T> : JsonConverter<T> where T : class
    {
        public override bool CanConvert(Type objectType)
        {
            return objectType == typeof(T);
        }

        public override void Write(Utf8JsonWriter writer, T value, JsonSerializerOptions options)
        {
            var converted = ConvertFromModel(value as T);
            if (converted.HasValue)
                writer.WriteBooleanValue(converted.Value);
        }

        public override T Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            var value = reader.GetString();
            var booleanValue = ParseString(value);
            return ConvertToModel(booleanValue);
        }

        protected abstract T ConvertToModel(bool? value);
        protected abstract bool? ConvertFromModel(T value);

        private static bool? ParseString(string value)
        {
            if (IsNullOrEmpty(value))
            {
                return null;
            }
            return TryParse(value, out var status) ? status : (bool?)null;
        }
    }
}
