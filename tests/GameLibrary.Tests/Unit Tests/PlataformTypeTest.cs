using ExpectedObjects;
using GameLibrary.Domain.Games;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace GameLibrary.Tests.Unit_Tests
{
    public class PlataformTypeTest
    {
        [Fact]
        public void DeveCriarUmaPlataforma()
        {
            var expectedPlataformType = new {Description = "Console / PC"};

            var plataformType = new PlatformType(expectedPlataformType.Description);

            expectedPlataformType.ToExpectedObject().ShouldMatch(plataformType);
        }
    }
}
