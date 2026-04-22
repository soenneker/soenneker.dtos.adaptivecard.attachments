using Soenneker.Tests.HostedUnit;

namespace Soenneker.Dtos.AdaptiveCard.Attachments.Tests;

[ClassDataSource<Host>(Shared = SharedType.PerTestSession)]
public class AdaptiveCardAttachmentsTests : HostedUnitTest
{
    public AdaptiveCardAttachmentsTests(Host host) : base(host)
    {
    }

    [Test]
    public void Default()
    {

    }
}
