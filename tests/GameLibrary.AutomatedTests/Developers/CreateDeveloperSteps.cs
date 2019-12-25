using GameLibrary.AutomatedTests.Utils;
using TechTalk.SpecFlow;
using Xunit;

[assembly: CollectionBehavior(DisableTestParallelization = true)]

namespace GameLibrary.AutomatedTests.Developers
{
    [Binding]
    public class CreateDeveloperSteps
    {
        private SeleniumHelper Browser = new SeleniumHelper();

        [Given(@"clica no link da area de developer")]
        public void DadoClicaNoLinkDaAreaDeDeveloper()
        {
            var lista = Browser.ObterListaPorPath("/html/body/app-root/app-menu-superior/div/div/div/div[2]/ul/li");
            Browser.ClicarLinkPorTexto("Developer");

            //var obj = lista.ToList().Where(c => c.Text == "Register").FirstOrDefault();
            //obj.Click();
            //foreach (var item in lista)
            //{
            //}
            //Browser.ClicarLinkPorTexto("Register");
            //Browser.ClicarBotaoPorPath("/html/body/app-root/app-menu-superior/div/div/div/div[2]/ul/li[5]/ul/li[1]/a");
            // ScenarioContext.Current.Pending();
        }

        [Given(@"Acessa a tela de cadastro")]
        public void DadoAcessaATelaDeCadastro()
        {
            Browser.ClicarLinkPorTexto("Register");
        }

        [Given(@"Preenche os dados do formulario")]
        public void DadoPreencheOsDadosDoFormulario(Table table)
        {
            Browser.PreencherTextBoxPorId(table.Rows[0][0], table.Rows[0][1]);//Name
            Browser.PreencherTextBoxPorId(table.Rows[1][0], table.Rows[1][1]);//Founded
            Browser.PreencherTextBoxPorId(table.Rows[2][0], table.Rows[2][1]);//Website
        }

        [When(@"Clica no botao Cadastrar")]
        public void QuandoClicaNoBotaoCadastrar()
        {
            Browser.ClicarBotaoPorId("register");
        }

        [Then(@"Recebe uma mensagem de developer cadastrado  com sucesso")]
        public void EntaoRecebeUmaMensagemDeDeveloperCadastradoComSucesso()
        {
            string text = Browser.ObterTextoElementoPorClasse("toast-message");
            var ret = Browser.ObterListaPorPath("//*[@id='divErro']/ul/li");

            Assert.Equal("Developer Registrado com Sucesso!", text);
        }

        [Then(@"Recebe uma mensagem de nome obrigatorio")]
        public void EntaoRecebeUmaMensagemDeNomeObrigatorio()
        {
            var e = Browser.ObterElementoPorPath("//*[@id='qryform']/div[1]/div/span/p");
            Assert.Equal("O Nome é requerido.", e.Text);
        }

        [Then(@"Recebe uma mensagem de data de fundacao invalida")]
        public void EntaoRecebeUmaMensagemDeDataDeFundacaoInvalida()
        {
            string text = Browser.ObterTextoElementoPorClasse("toast-message");
            var ret = Browser.ObterListaPorPath("//*[@id='divErro']/ul/li");

            Assert.Equal("Falha ao inserir", text);
        }

        [Then(@"exclui o developer cadastrado")]
        public void EntaoExcluiODeveloperCadastrado()
        {
            // ScenarioContext.Current.Pending();
        }
    }
}