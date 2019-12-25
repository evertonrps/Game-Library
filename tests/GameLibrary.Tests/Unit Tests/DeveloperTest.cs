using ExpectedObjects;
using FluentValidation.Results;
using GameLibrary.Domain.Core.Resources;
using GameLibrary.Domain.Games;
using GameLibrary.Tests.Builders;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Xunit;

namespace GameLibrary.Tests.Unit_Tests
{
    public class DeveloperTest
    {
        private readonly HttpClient client;

        public DeveloperTest()
        {
            client = new HttpClient();
        }

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

        [Fact]
        public async void TesteToken()
        {
            var ret = await Run();
            Assert.NotNull(ret);
        }

        private async Task<Login> Run()
        {
            client.BaseAddress = new Uri("http://localhost:2001/");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));

            try
            {
                var token = new Login { NomeUsuario = "desenvolvimento", Senha = "ti@907090" };

                var autenticacao = await GenerateToken(token);
                Console.WriteLine($"Created at {autenticacao.token}");

                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", autenticacao.token);

                return token;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private async Task<Token> GenerateToken(Login token)
        {
            HttpResponseMessage response = await client.PostAsJsonAsync(
                "api/segurancas/tokens", token);
            response.EnsureSuccessStatusCode();

            // return URI of the created resource.
            string content = await response.Content.ReadAsStringAsync();

            return await Task.Run(() => JsonConvert.DeserializeObject<Token>(content));
        }
    }

    internal class Login
    {
        public string NomeUsuario { get; set; }
        public string Senha { get; set; }
    }

    internal class Token
    {
        public string token { get; set; }
    }
}