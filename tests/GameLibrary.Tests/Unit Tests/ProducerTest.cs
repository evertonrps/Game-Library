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

namespace GameLibrary.Tests.Unit_Tests
{
    public class ProducerTest
    {
        [Fact]
        public void Producer_CreateProducer_Success()
        {
            var expectedProducer = new { Name = "Nintendo", Founded = DateTime.Now.Date, WebSite = "www.nintendo.com" };

            var Producer = new Producer(expectedProducer.Name, expectedProducer.Founded, expectedProducer.WebSite);

            expectedProducer.ToExpectedObject().ShouldMatch(Producer);
        }

        [Fact]
        public void Producer_CreateProducerWithoutName_Fail()
        {            
            //Arrange                        
            var ret = ProducerBuilder.Create().SetName(null).Build();

            //Act
            var x = ret.IsValid();
            IList<ValidationFailure> failures = ret.ValidationResult.Errors;

            //Assert
            Assert.Contains("Producer name must be provided and must be between 2 and 150 characters", failures.Select(y => y.ErrorMessage).ToList());
        }
    }
}
