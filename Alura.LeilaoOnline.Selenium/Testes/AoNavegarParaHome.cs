using WebDriverManager;
using WebDriverManager.DriverConfigs.Impl;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using Xunit;
using Alura.LeilaoOnline.Selenium.Helpers;
using Alura.LeilaoOnline.Selenium.Fixtures;


namespace Alura.LeilaoOnline.Selenium.Testes
{
    public class AoNavegarParaHome : IClassFixture<TestFixture>
    {

        private IWebDriver driver;

        // setup

        public AoNavegarParaHome(TestFixture fixture)
        {
            driver = fixture.Driver;
        }


        //Em C#, [Fact] é um atributo usado no framework de testes xUnit. Ele serve para marcar um método como um teste unitário que não recebe parâmetros.

        [Fact]
        public void DadoChromeAbertoDeveMostrarLeiloesNoTitulo()
        {
            //arrange 


            //obs: mudou-se o arrange de local, tornando - o SETUP para que não seja necessário inicializarmos em todos os testes de uma só vez


            //act
            driver.Navigate().GoToUrl("http://localhost:5000");

            //assert
            Assert.Contains("Leilões", driver.Title);
        }


        [Fact]
        public void DadoChromeAbertoDeveMostrarProximosLeiloesNaPagina()
        {
            //arrange 


            //obs: mudou-se o arrange de local, tornando - o SETUP para que não seja necessário inicializarmos em todos os testes de uma só vez


            //act
            driver.Navigate().GoToUrl("http://localhost:5000");

            //assert
            Assert.Contains("Próximos Leilões", driver.PageSource);
        }
    }
}
