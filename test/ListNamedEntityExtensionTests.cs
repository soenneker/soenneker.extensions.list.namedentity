using Soenneker.Tests.FixturedUnit;
using Xunit;
using Xunit.Abstractions;

namespace Soenneker.Extensions.List.NamedEntity.Tests;

[Collection("Collection")]
public class ListNamedEntityExtensionTests : FixturedUnitTest
{
    public ListNamedEntityExtensionTests(Fixture fixture, ITestOutputHelper output) : base(fixture, output)
    {
    }
}
