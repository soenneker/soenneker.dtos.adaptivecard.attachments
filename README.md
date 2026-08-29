[![](https://img.shields.io/nuget/v/soenneker.dtos.adaptivecard.attachments.svg?style=for-the-badge)](https://www.nuget.org/packages/soenneker.dtos.adaptivecard.attachments/)
[![](https://img.shields.io/github/actions/workflow/status/soenneker/soenneker.dtos.adaptivecard.attachments/publish-package.yml?style=for-the-badge)](https://github.com/soenneker/soenneker.dtos.adaptivecard.attachments/actions/workflows/publish-package.yml)
[![](https://img.shields.io/nuget/dt/soenneker.dtos.adaptivecard.attachments.svg?style=for-the-badge)](https://www.nuget.org/packages/soenneker.dtos.adaptivecard.attachments/)
[![](https://img.shields.io/github/actions/workflow/status/soenneker/soenneker.dtos.adaptivecard.attachments/codeql.yml?label=CodeQL&style=for-the-badge)](https://github.com/soenneker/soenneker.dtos.adaptivecard.attachments/actions/workflows/codeql.yml)

# Soenneker.Dtos.AdaptiveCard.Attachments

Represents an Adaptive Card attachment in a Microsoft Teams-compatible message payload.

## Install

```bash
dotnet add package Soenneker.Dtos.AdaptiveCard.Attachments
```

## What you get

- `AdaptiveCardAttachments` — Represents an Adaptive Card attachment in a Microsoft Teams-compatible message payload.

## API at a glance

| API | What it does | Result / important behavior |
| --- | --- | --- |
| `AdaptiveCardAttachments.ContentType` | MIME type of the attachment. Adaptive Cards use `application/vnd.microsoft.card.adaptive`. | MIME type of the attachment. Adaptive Cards use `application/vnd.microsoft.card.adaptive`. |
| `AdaptiveCardAttachments.ContentUrl` | URL from which the attachment content can be retrieved when it is not embedded inline. | URL from which the attachment content can be retrieved when it is not embedded inline. |
| `AdaptiveCardAttachments.Content` | Adaptive Card document embedded directly in the attachment. | Adaptive Card document embedded directly in the attachment. |
