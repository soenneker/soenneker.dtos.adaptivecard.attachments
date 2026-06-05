using System.Text.Json.Serialization;
using Newtonsoft.Json;

namespace Soenneker.Dtos.AdaptiveCard.Attachments;

/// <summary>
/// A DTO for AdaptiveCard (de)serialization
/// </summary>
public class AdaptiveCardAttachments
{
    /// <summary>
    /// Gets or sets content type.
    /// </summary>
    [JsonProperty("contentType")]
    [JsonPropertyName("contentType")]
    public string ContentType { get; set; }

    /// <summary>
    /// Gets or sets content url.
    /// </summary>
    [JsonProperty("contentUrl")]
    [JsonPropertyName("contentUrl")]
    public string? ContentUrl { get; set; }

    /// <summary>
    /// Gets or sets content.
    /// </summary>
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