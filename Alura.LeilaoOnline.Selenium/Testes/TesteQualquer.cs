using Alura.LeilaoOnline.Selenium.Fixtures;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


// teste qualquer para testar a collection fixture

namespace Alura.LeilaoOnline.Selenium.Testes
{

    [Collection("Chrome Driver")]
    public class TesteQualquer
    {
        private IWebDriver driver;

        public TesteQualquer(TestFixture fixture)
        {
            driver = fixture.Driver;
        }


        [Fact]
        public void DadoChromeAbertoDeveMostrarProximosLeiloesNaPagina()
        {
            //arrange 

            //act
            driver.Navigate().GoToUrl("http://localhost:5000");

            //assert
            Assert.Contains("Próximos Leilões", driver.PageSource);
        }
    }
}
