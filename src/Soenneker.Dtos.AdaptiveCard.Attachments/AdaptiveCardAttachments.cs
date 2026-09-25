using System.Text.Json.Serialization;

namespace Soenneker.Dtos.AdaptiveCard.Attachments;

/// <summary>
/// Represents an Adaptive Card attachment in a Microsoft Teams-compatible message payload.
/// </summary>
[JsonConverter(typeof(AdaptiveCardAttachmentsJsonConverter))]
public class AdaptiveCardAttachments
{
    /// <summary>
    /// MIME type of the attachment. Adaptive Cards use <c>application/vnd.microsoft.card.adaptive</c>.
    /// </summary>
    [JsonPropertyName("contentType")]
    public string ContentType { get; set; }

    /// <summary>
    /// URL from which the attachment content can be retrieved when it is not embedded inline.
    /// </summary>
    [JsonPropertyName("contentUrl")]
    public string? ContentUrl { get; set; }

    /// <summary>
    /// Adaptive Card document embedded directly in the attachment.
    /// </summary>
    [JsonPropertyName("content")]
    public Soenneker.AdaptiveCards.Dtos.Models.AdaptiveCard? Content { get; set; }

    /// <summary>
    /// Creates an empty attachment with the Adaptive Card content type.
    /// </summary>
    public AdaptiveCardAttachments()
    {
        ContentType = "application/vnd.microsoft.card.adaptive";
    }

    /// <summary>
    /// Creates an attachment containing the supplied Adaptive Card.
    /// </summary>
    /// <param name="card">The card to embed as inline content.</param>
    public AdaptiveCardAttachments(Soenneker.AdaptiveCards.Dtos.Models.AdaptiveCard card) : this()
    {
        ContentUrl = null;
        Content = card;
    }
}
