using Microsoft.Extensions.Configuration;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Threading;
using TesteSafra.Utils;



namespace TesteSafra.PageObjects
{
    public class TelaComprarAcoes
    {
        private IConfiguration _configuration;
        private Browser _browser;
        private IWebDriver _driver;

        public TelaComprarAcoes(IConfiguration configuration, Browser browser)
        {
            _configuration = configuration;
            _browser = browser;

            string caminhoDriver = null;
            if (browser == Browser.Firefox)
            {
                caminhoDriver = _configuration.GetSection("Selenium:CaminhoDriverFirefox").Value;
            }
            else if (browser == Browser.Chrome)
            {
                caminhoDriver = _configuration.GetSection("Selenium:CaminhoDriverChrome").Value;
            }

            _driver = WebDriverFactory.CreateWebDriver(
                browser, caminhoDriver, true);


        }

      
        public void CarregarPagina()
        {
            _driver.LoadPages(
                TimeSpan.FromSeconds(Convert.ToInt32(
                    _configuration.GetSection("Selenium:Timeout").Value)),
                _configuration.GetSection("Selenium:UrlCompraAcoes").Value);

            //_driver.Manage().Timeouts().ImplicitWait.TotalSeconds.Equals(5);

        }
        public void PreencherComprarAcoes(string valor, string simbol)
        {
            _driver.SetText(
                By.Name("ddlComprar"),
                valor.ToString());
            //_driver.SetText(
            //    By.Id("btnComprar"),
            //    simbol.ToString());

        }

        public void Processar()
        {
            _driver.Submit(By.Id("btnComprar"));

            WebDriverWait wait = new WebDriverWait(
                _driver, TimeSpan.FromSeconds(10));

            this._driver.Manage().Timeouts().ImplicitWait.TotalSeconds.Equals(5);

            wait.Until((d) => d.FindElement(By.Id("textOK")) != null);

        }

        public string ObterRetorno()
        {
            Thread.Sleep(5000);
            //string result1 = _driver.GetText(By.Id("textOK"));
            string result = _driver.FindElement(By.Id("textOK")).GetAttribute("value");
           

               return result;
        }

        public void fechar()
        {
            //_driver.Quit();
            //_driver = null;
        }

       
    }
}
