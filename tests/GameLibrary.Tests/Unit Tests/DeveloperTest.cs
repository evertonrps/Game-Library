using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using GameLibrary.Domain;
using GameLibrary.Domain.Games;
using ExpectedObjects;
using GameLibrary.Tests.Builders;
using FluentValidation.Results;
using System.Linq;
using GameLibrary.Domain.Core.Resources;

namespace GameLibrary.Tests.Unit_Tests
{
    public class DeveloperTest
    {
        [Fact]
        public void Developer_CreateDeveloper_Success()
        {
            var expectedDeveloper = new { Name = "Nintendo", Founded = DateTime.Now.Date, WebSite = "www.nintendo.com" };

            var Developer = new Developer(expectedDeveloper.Name, expectedDeveloper.Founded, expectedDeveloper.WebSite);

            expectedDeveloper.ToExpectedObject().ShouldMatch(Developer);
        }

        [Fact]
        public void Developer_CreateDeveloperWithoutName_Fail()
        {            
            //Arrange                        
            var ret = DeveloperBuilder.Create().SetName(null).Build();

            //Act
            var x = ret.IsValid();
            IList<ValidationFailure> failures = ret.ValidationResult.Errors;

            //Assert
            Assert.Contains(Messages.DeveloperNameInvalid, failures.Select(y => y.ErrorMessage).ToList());
        }

        [Theory]
        [InlineData("2020-01-01")]        
        [InlineData("0001-01-01")]
        public void Developer_CreateDeveloperWithInvalidFouded_Fail(string dateTime)
        {
            var data = Convert.ToDateTime(dateTime);
            //Arrange                        
            var ret = DeveloperBuilder.Create().SetFounded(data).Build();

            //Act
            var x = ret.IsValid();
            IList<ValidationFailure> failures = ret.ValidationResult.Errors;

            //Assert
            Assert.Contains(Messages.DeveloperFoundedInvalid, failures.Select(y => y.ErrorMessage).ToList());
        }
    }
}
