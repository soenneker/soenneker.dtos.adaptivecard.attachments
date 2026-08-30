[![](https://img.shields.io/nuget/v/soenneker.dtos.adaptivecard.attachments.svg?style=for-the-badge)](https://www.nuget.org/packages/soenneker.dtos.adaptivecard.attachments/)
[![](https://img.shields.io/github/actions/workflow/status/soenneker/soenneker.dtos.adaptivecard.attachments/publish-package.yml?style=for-the-badge)](https://github.com/soenneker/soenneker.dtos.adaptivecard.attachments/actions/workflows/publish-package.yml)
[![](https://img.shields.io/nuget/dt/soenneker.dtos.adaptivecard.attachments.svg?style=for-the-badge)](https://www.nuget.org/packages/soenneker.dtos.adaptivecard.attachments/)
[![](https://img.shields.io/github/actions/workflow/status/soenneker/soenneker.dtos.adaptivecard.attachments/codeql.yml?label=CodeQL&style=for-the-badge)](https://github.com/soenneker/soenneker.dtos.adaptivecard.attachments/actions/workflows/codeql.yml)

# Soenneker.Dtos.AdaptiveCard.Attachments

Defines the attachment envelope used to embed an Adaptive Card in a Microsoft Teams-compatible message payload.

## Installation

```bash
dotnet add package Soenneker.Dtos.AdaptiveCard.Attachments
```

## Embed a card

```csharp
using AdaptiveCards;
using Soenneker.Dtos.AdaptiveCard.Attachments;

var card = new AdaptiveCard(new AdaptiveSchemaVersion(1, 5));
card.Body.Add(new AdaptiveTextBlock
{
    Text = "Deployment completed",
    Weight = AdaptiveTextWeight.Bolder
});

var attachment = new AdaptiveCardAttachments(card);
```

The card constructor produces this envelope shape:

```json
{
  "contentType": "application/vnd.microsoft.card.adaptive",
  "contentUrl": null,
  "content": {
    "type": "AdaptiveCard",
    "version": "1.5"
  }
}
```

The exact `content` object depends on the card you build. Null properties are included or omitted according to your System.Text.Json or Newtonsoft.Json serializer settings.

## Refer to external content

```csharp
var attachment = new AdaptiveCardAttachments
{
    ContentUrl = "https://example.com/cards/deployment.json"
};
```

The parameterless constructor still initializes `ContentType` to `application/vnd.microsoft.card.adaptive`. When using `ContentUrl`, leave `Content` null unless the receiving API explicitly supports both values.

All three properties remain mutable for serializer compatibility. The DTO does not validate the card schema version, require exactly one content source, fetch external content, or send the Teams message.
