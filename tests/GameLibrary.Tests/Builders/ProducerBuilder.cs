using Bogus;
using GameLibrary.Domain.Games;
using System;
using System.Collections.Generic;
using System.Text;

namespace GameLibrary.Tests.Builders
{
    public class ProducerBuilder
    {
        private string _name;
        private DateTime _founded;
        private string _webSite;
        public ProducerBuilder()
        {
            var fake = new Faker();
            _name = fake.Company.CompanyName();
            _founded = fake.Date.Past();
            _webSite = fake.Internet.Url();
        }

        public static ProducerBuilder Create()
        {
            return new ProducerBuilder();
        }

        public ProducerBuilder SetName(string name)
        {
            _name = name;
            return this;
        }

        public ProducerBuilder SetFounded(DateTime founded)
        {
            _founded = founded;
            return this;
        }


        public ProducerBuilder SetWebSite(string webSite)
        {
            _webSite = webSite;
            return this;
        }

        public Producer Build()
        {
            return new Producer(_name, _founded, _webSite);
        }
    }
}
