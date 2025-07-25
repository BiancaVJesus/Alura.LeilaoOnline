using WebDriverManager;
using WebDriverManager.DriverConfigs.Impl;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using Xunit;
using Alura.LeilaoOnline.Selenium.Helpers;


namespace Alura.LeilaoOnline.Selenium
{
    public class AoNavegarParaHome
    {
        //Em C#, [Fact] é um atributo usado no framework de testes xUnit. Ele serve para marcar um método como um teste unitário que não recebe parâmetros.

        [Fact]
        public void DadoChromeAbertoDeveMostrarLeiloesNoTitulo()
        {
            //arrange 

            //IWebDriver driver = new DriverManager().SetUpDriver(new ChromeConfig());

            IWebDriver driver = new ChromeDriver(TestHelpers.PastaDoExecutavel);

            //act
            driver.Navigate().GoToUrl("http://localhost:5000");

            //assert
            Assert.Contains("Leilões", driver.Title);
        }




        public void DadoChromeAbertoDeveMostrarProximosLeiloesNaPagina()
        {
            //arrange 

            //IWebDriver driver = new ChromeDriver(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location));.SetUpDriver(new ChromeConfig());

            IWebDriver driver = new ChromeDriver(TestHelpers.PastaDoExecutavel);

            //act
            driver.Navigate().GoToUrl("http://localhost:5000");

            //assert
            Assert.Contains("Próximos Leilões", driver.PageSource);
        }
    }
}
