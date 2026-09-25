using System;
using System.Text.Json;
using System.Text.Json.Serialization;
using Soenneker.AdaptiveCards.Dtos;

namespace Soenneker.Dtos.AdaptiveCard.Attachments;

/// <summary>Serializes Teams attachments using generated metadata for the embedded Adaptive Card.</summary>
public sealed class AdaptiveCardAttachmentsJsonConverter : JsonConverter<AdaptiveCardAttachments>
{
    public override AdaptiveCardAttachments Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        using JsonDocument document = JsonDocument.ParseValue(ref reader);
        if (document.RootElement.ValueKind != JsonValueKind.Object)
            throw new JsonException("An Adaptive Card attachment must be an object.");

        var attachment = new AdaptiveCardAttachments();
        foreach (JsonProperty property in document.RootElement.EnumerateObject())
        {
            StringComparison comparison = options.PropertyNameCaseInsensitive ? StringComparison.OrdinalIgnoreCase : StringComparison.Ordinal;
            if (property.Name.Equals("contentType", comparison))
                attachment.ContentType = property.Value.GetString() ?? throw new JsonException("contentType cannot be null.");
            else if (property.Name.Equals("contentUrl", comparison))
                attachment.ContentUrl = property.Value.GetString();
            else if (property.Name.Equals("content", comparison))
                attachment.Content = property.Value.Deserialize(SchemaJsonContext.Default.AdaptiveCard);
        }

        return attachment;
    }

    public override void Write(Utf8JsonWriter writer, AdaptiveCardAttachments value, JsonSerializerOptions options)
    {
        writer.WriteStartObject();
        writer.WriteString("contentType", value.ContentType);
        bool omitNulls = options.DefaultIgnoreCondition is JsonIgnoreCondition.WhenWritingNull or JsonIgnoreCondition.WhenWritingDefault;
        if (value.ContentUrl is not null || !omitNulls)
            writer.WriteString("contentUrl", value.ContentUrl);
        if (value.Content is not null || !omitNulls)
        {
            writer.WritePropertyName("content");
            JsonSerializer.Serialize(writer, value.Content, SchemaJsonContext.Default.AdaptiveCard);
        }
        writer.WriteEndObject();
    }
}
