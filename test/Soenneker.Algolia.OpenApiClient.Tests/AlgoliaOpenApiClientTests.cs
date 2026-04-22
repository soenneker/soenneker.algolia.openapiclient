using Soenneker.Tests.HostedUnit;

namespace Soenneker.Algolia.OpenApiClient.Tests;

[ClassDataSource<Host>(Shared = SharedType.PerTestSession)]
public sealed class AlgoliaOpenApiClientTests : HostedUnitTest
{
    public AlgoliaOpenApiClientTests(Host host) : base(host)
    {
    }

    [Test]
    public void Default()
    {

    }
}
