using Bogus;
using GameLibrary.Domain.Games;

namespace GameLibrary.Tests.Builders
{
    public class GameBuilder
    {
        private string _title;
        private string _description;
        private int _DeveloperId;

        private GameBuilder()
        {
            Faker faker = new Faker();
            _title = faker.Person.FullName;
            _description = faker.Lorem.Paragraphs(2);
            _DeveloperId = faker.Random.Int(1, 1000);
        }

        public static GameBuilder Create()
        {
            return new GameBuilder();
        }

        public GameBuilder SetTitle(string title)
        {
            _title = title;
            return this;
        }

        public GameBuilder SetDescription(string description)
        {
            _description = description;
            return this;
        }

        public GameBuilder SetDeveloperId(int DeveloperId)
        {
            _DeveloperId = DeveloperId;
            return this;
        }

        public Game Build()
        {
            return new Game(_title, _description, _DeveloperId);
        }
    }
}