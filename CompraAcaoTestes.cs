using Microsoft.Extensions.Configuration;
using System.Globalization;
using System.IO;
using TesteSafra.PageObjects;
using TesteSafra.Utils;
using Xunit;

namespace TesteSafra
{
    public class CompraAcaoTestes
    {
        private IConfiguration _configuration;

        public CompraAcaoTestes()
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile($"appsetings.json");

            _configuration = builder.Build();

            var padroesBR = new CultureInfo("pt-BR");
            CultureInfo.DefaultThreadCurrentCulture = padroesBR;
            CultureInfo.DefaultThreadCurrentUICulture = padroesBR;

        }
        [Theory]
        [InlineData(Browser.Chrome, "10", "error")]
        public void TesteComprarAcoes(Browser browser, string valor, string simbol)
        {
            TelaComprarAcoes tela = new TelaComprarAcoes(_configuration, browser);

            tela.CarregarPagina();
            tela.PreencherComprarAcoes(valor,simbol);
            tela.Processar();
            
            string item = tela.ObterRetorno();

            tela.fechar();
            

            Assert.Equal(simbol, item);


        }


    }
}

