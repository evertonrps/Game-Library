using Bogus;
using GameLibrary.Domain.Games;
using System;
using System.Collections.Generic;
using System.Text;

namespace GameLibrary.Tests.Builders
{
    public class DeveloperBuilder
    {
        private string _name;
        private DateTime _founded;
        private string _webSite;
        public DeveloperBuilder()
        {
            var fake = new Faker();
            _name = fake.Company.CompanyName();
            _founded = fake.Date.Past();
            _webSite = fake.Internet.Url();
        }

        public static DeveloperBuilder Create()
        {
            return new DeveloperBuilder();
        }

        public DeveloperBuilder SetName(string name)
        {
            _name = name;
            return this;
        }

        public DeveloperBuilder SetFounded(DateTime founded)
        {
            _founded = founded;
            return this;
        }


        public DeveloperBuilder SetWebSite(string webSite)
        {
            _webSite = webSite;
            return this;
        }

        public Developer Build()
        {
            return new Developer(_name, _founded, _webSite);
        }
    }
}
