using Alura.LeilaoOnline.Selenium.Fixtures;
using Alura.LeilaoOnline.Selenium.PageObjects;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alura.LeilaoOnline.Selenium.Testes
{
    [Collection("Chrome Driver")]
    
    public class AoEfetuarLogin
    {
        private IWebDriver driver;
        public AoEfetuarLogin(TestFixture fixture) 

        {
            driver = fixture.Driver;

        }

        [Fact]
        public void DadoCredenciaisValidasDeveIrParaDashboard()
        {

            //arrange
            var loginPO = new LoginPO(driver);
            loginPO.Visitar();
            loginPO.PreencheFormulario("fulano@example.org", "123");

            //act
            loginPO.SubmeteFormulario();

            //assert
            Assert.Contains("Dashboard", driver.Title);


        }

        [Fact]
        public void DadoCredenciaisInvalidasDeveContinuarLogin()
        {
            //arrange
            var loginPO = new LoginPO(driver);
            loginPO.Visitar();
            loginPO.PreencheFormulario("bianca", "123");

            //act
            loginPO.SubmeteFormulario();

            //assert
            Assert.Contains("Login", driver.PageSource);

        }
    }
}
