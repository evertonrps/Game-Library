using Bogus;
using ExpectedObjects;
using FluentValidation.Results;
using GameLibrary.Domain.Core.Resources;
using GameLibrary.Domain.Entities.Games;
using GameLibrary.Tests.Builders;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace GameLibrary.Tests.Unit_Tests
{
    public class GameTest
    {
        private readonly string _title;
        private readonly string _description;
        private readonly int _DeveloperId;

        public GameTest()
        {
            var fake = new Faker();
            _title = fake.Lorem.Text();
            _description = fake.Lorem.Paragraphs(2);
            _DeveloperId = fake.Random.Int(1, 10000);
        }

        [Fact]
        public void Game_CreateGame_ReturnSuccess()
        {
            var expectedGame = new
            {
                Title = _title,
                Description = _description,
                DeveloperId = _DeveloperId
            };

            var game = Game.Factory(expectedGame.Title, expectedGame.Description, expectedGame.DeveloperId);

            expectedGame.ToExpectedObject().ShouldMatch(game);
        }

        [Theory]
        [InlineData("")]
        [InlineData(null)]
        [InlineData("E")]
        public void Game_CreateGameWithoutTitle_ReturnFail(string p)
        {
            //Arrange
            var ret = GameBuilder.Create().SetTitle(p).Build();

            //Act
            var x = ret.IsValid();
            IList<ValidationFailure> failures = ret.Erros;

            //Assert
            Assert.Contains(Messages.GameTitleInvalid, failures.Select(y => y.ErrorMessage).ToList());
        }
    }
}