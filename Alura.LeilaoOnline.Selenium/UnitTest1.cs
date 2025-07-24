using WebDriverManager;
using WebDriverManager.DriverConfigs.Impl;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using Xunit;


namespace Alura.LeilaoOnline.Selenium
{
    public class UnitTest1
    {

        [Fact]
        public void Test1()
        {
            //arrange 

            //IWebDriver driver = new DriverManager().SetUpDriver(new ChromeConfig());

            new DriverManager().SetUpDriver(new ChromeConfig());
            IWebDriver driver = new ChromeDriver();

            //act
            driver.Navigate().GoToUrl("http://localhost:5000");

            //assert
            Assert.Contains("Leilões", driver.Title);
        }
    }
}
