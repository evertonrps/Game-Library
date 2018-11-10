﻿using Bogus;
using GameLibrary.Domain;
using GameLibrary.Domain.Games;
using System;
using System.Collections.Generic;
using System.Text;

namespace GameLibrary.Tests.Builders
{
    public class GameBuilder
    {
        private string _title;
        private string _description;
        private int _producerId;

        private GameBuilder()
        {
            Faker faker = new Faker();
            _title = faker.Person.FullName;
            _description = faker.Lorem.Paragraphs(2);
            _producerId = faker.Random.Int(1, 1000);
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

        public GameBuilder SetProducerId(int producerId)
        {
            _producerId = producerId;
            return this;
        }

        public Game Build()
        {
            return new Game(_title, _description, _producerId);
        }
    }
}
