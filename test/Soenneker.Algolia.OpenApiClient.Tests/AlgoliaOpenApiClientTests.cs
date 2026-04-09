using Soenneker.Tests.FixturedUnit;
using Xunit;

namespace Soenneker.Algolia.OpenApiClient.Tests;

[Collection("Collection")]
public sealed class AlgoliaOpenApiClientTests : FixturedUnitTest
{
    public AlgoliaOpenApiClientTests(Fixture fixture, ITestOutputHelper output) : base(fixture, output)
    {
    }

    [Fact]
    public void Default()
    {

    }
}
