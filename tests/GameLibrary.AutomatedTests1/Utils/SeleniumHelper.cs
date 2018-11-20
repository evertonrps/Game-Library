using System;
using System.Collections.Generic;
using System.Threading;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using Xunit.Abstractions;
using Xunit;

namespace GameLibrary.AutomatedTests.Utils
{
    [Binding]
    public class SeleniumHelper
    {
        public static IWebDriver CD;
        public static WebDriverWait Wait;



        [Before]
        public void Setup()
        {
            IniciaDriver();
            NavegarParaUrl(ConfigurationHelper.PortalUrl);
        }

        private static void IniciaDriver()
        {
            ChromeOptions options = new ChromeOptions();
            options.AddArguments("start-maximized");
            options.AddArguments("--disable-popup-blocking");
            CD = new ChromeDriver(ConfigurationHelper.ChromeDrive, options);
            Wait = new WebDriverWait(CD, TimeSpan.FromSeconds(5));
        }

        [After]
        public void Fechar()
        {
            CD.Quit();
        }

        public bool ValidarConteudoUrl(string conteudo)
        {
            return Wait.Until(c => c.Url.Contains(conteudo));
        }

        public void NavegarParaUrl(string url)
        {
            CD.Navigate().GoToUrl(url);
        }

        public void ClicarLinkPorTexto(string linkText)
        {
            var link = Wait.Until(c => c.FindElement(By.LinkText(linkText)));
            link.Click();
        }

        public void ClicarBotaoPorId(string botaoId)
        {
            CD.FindElement(By.Id(botaoId)).Click();
        }

        public IWebElement ObterElementoPorId(string elementoId)
        {
            return Wait.Until(c => c.FindElement(By.Id(elementoId)));
        }

        public void PreencherTextBoxPorId(string idCampo, string valorCampo)
        {
            CD.FindElement(By.Id(idCampo)).SendKeys(valorCampo);
        }

        public void PreencherTextBoxPorXPath(string xpath, string valorCampo)
        {
            var campo = Wait.Until(c => c.FindElement(By.XPath(xpath)));
            campo.SendKeys(valorCampo);
        }

        public void PreencherDropDownPorId(string idCampo, string valorCampo)
        {
            var campo = Wait.Until(c => c.FindElement(By.Id(idCampo)));
            var selectElement = new SelectElement(campo);
            selectElement.SelectByValue(valorCampo);
        }

        public string ObterTextoElementoPorClasse(string className)
        {
            return Wait.Until(c => c.FindElement(By.ClassName(className))).Text;
        }

        public string ObterTextoElementoPorId(string id)
        {
            return Wait.Until(c => c.FindElement(By.Id(id))).Text;
        }

        public IEnumerable<IWebElement> ObterListaPorClasse(string className)
        {
            return Wait.Until(c => c.FindElements(By.ClassName(className)));
        }

        public IEnumerable<IWebElement> ObterListaPorPath(string path)
        {
            return Wait.Until(c => c.FindElements(By.XPath(path)));
        }

        public IWebElement ObterElementoPorPath(string path)
        {
            return Wait.Until(c => c.FindElement(By.XPath(path)));
        }

        private static void SalvarScreenShot(Screenshot screenshot, string fileName)
        {
            screenshot.SaveAsFile(string.Format("{0}{1}", ConfigurationHelper.FolderPicture, fileName),
                ScreenshotImageFormat.Png);
        }

        public void ClicarBotaoPorPath(string path)
        {
            CD.FindElement(By.XPath(path)).Click();
        }

        public void ClicarBotaoOKDialogJS()
        {
            Wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.AlertIsPresent());
            CD.SwitchTo().Alert().Accept();
        }

        public void RolarTelaAteElementoAparecer(IWebElement elemento)
        {
            IJavaScriptExecutor js = (IJavaScriptExecutor)CD;
            js.ExecuteScript("arguments[0].scrollIntoView();", elemento);
        }

        public void EsperaTelaCarregar(int tempo)
        {
            Thread.Sleep(tempo);
        }

    }
}
