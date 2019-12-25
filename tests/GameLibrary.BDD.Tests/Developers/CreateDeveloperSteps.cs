using GameLibrary.BDD.Tests.Utils;
using TechTalk.SpecFlow;
using Xunit;

namespace GameLibrary.BDD.Tests.Developers
{
    [Binding]
    public class CreateDeveloperSteps
    {
        private SeleniumHelper Browser = new SeleniumHelper();

        [Given(@"clica no link da area de developer")]
        public void DadoClicaNoLinkDaAreaDeDeveloper()
        {
            Browser.ClicarBotaoPorId("button-basic-desenvolvedoras");
            Browser.ClicarLinkPorTexto("Cadastrar");
            Browser.EsperaTelaCarregar(5000);
        }

        [Given(@"Acessa a tela de cadastro")]
        public void DadoAcessaATelaDeCadastro()
        {
            var result = Browser.ValidarConteudoUrl("/developers/new");
            Assert.True(result);
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
            Browser.ClicarBotaoPorId("btnSalvar");
        }

        [Then(@"Recebe uma mensagem de developer cadastrado  com sucesso")]
        public void EntaoRecebeUmaMensagemDeDeveloperCadastradoComSucesso()
        {
            string text = Browser.ObterTextoElementoPorClasse("toast-message");
            var ret = Browser.ObterListaPorPath("//*[@id='divErro']/ul/li");

            Assert.Equal("Developer Registrado com Sucesso!", text);
        }

        [Then(@"exclui o developer cadastrado")]
        public void EntaoExcluiODeveloperCadastrado()
        {
            ScenarioContext.Current.Pending();
        }

        [Then(@"Recebe uma mensagem de nome obrigatorio")]
        public void EntaoRecebeUmaMensagemDeNomeObrigatorio()
        {
            ScenarioContext.Current.Pending();
        }

        [Then(@"Recebe uma mensagem de data de fundacao invalida")]
        public void EntaoRecebeUmaMensagemDeDataDeFundacaoInvalida()
        {
            ScenarioContext.Current.Pending();
        }
    }
}