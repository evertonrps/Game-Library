using ExpectedObjects;
using GameLibrary.Domain.Games;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace GameLibrary.Tests.Unit_Tests
{
    public class PlatformTest
    {
        [Fact]
        public void DeveCriarUmaPlataforma()
        {
            var expectedPlatform = new {Description = "Xbox 360", PlatformTypeId =  10};

            var platform = new Platform(expectedPlatform.Description, expectedPlatform.PlatformTypeId);

            expectedPlatform.ToExpectedObject().ShouldMatch(platform);
        }
    }
}
