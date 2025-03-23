using System.Text.Json.Serialization;
using Newtonsoft.Json;

namespace Soenneker.Dtos.AdaptiveCard.Attachments;

/// <summary>
/// A DTO for AdaptiveCard (de)serialization
/// </summary>
public class AdaptiveCardAttachments
{
    [JsonProperty("contentType")]
    [JsonPropertyName("contentType")]
    public string ContentType { get; set; }

    [JsonProperty("contentUrl")]
    [JsonPropertyName("contentUrl")]
    public string? ContentUrl { get; set; }

    [JsonProperty("content")]
    [JsonPropertyName("content")]
    public AdaptiveCards.AdaptiveCard? Content { get; set; }

    public AdaptiveCardAttachments()
    {
        ContentType = "application/vnd.microsoft.card.adaptive";
    }

    public AdaptiveCardAttachments(AdaptiveCards.AdaptiveCard card) : this()
    {
        ContentUrl = null;
        Content = card;
    }
}