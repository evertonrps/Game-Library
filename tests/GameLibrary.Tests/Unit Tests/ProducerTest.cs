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
            Assert.Contains(Messages.ProducerNameInvalid, failures.Select(y => y.ErrorMessage).ToList());
        }

        [Fact]
        public void Producer_CreateProducerWithInvalidFouded_Fail()
        {
            //Arrange                        
            var ret = ProducerBuilder.Create().SetFounded(DateTime.MinValue).Build();

            //Act
            var x = ret.IsValid();
            IList<ValidationFailure> failures = ret.ValidationResult.Errors;

            //Assert
            Assert.Contains(Messages.ProducerFoundedInvalid, failures.Select(y => y.ErrorMessage).ToList());
        }
    }
}
