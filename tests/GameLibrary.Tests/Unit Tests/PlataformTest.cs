using ExpectedObjects;
using GameLibrary.Domain.Entities.Games;
using Xunit;

namespace GameLibrary.Tests.Unit_Tests
{
    public class PlatformTest
    {
        [Fact]
        public void DeveCriarUmaPlataforma()
        {
            var expectedPlatform = new { Description = "Xbox 360", PlatformTypeId = 10 };

            var platform = Platform.Factory(expectedPlatform.Description, expectedPlatform.PlatformTypeId);

            expectedPlatform.ToExpectedObject().ShouldMatch(platform);
        }
    }
}