using Alura.LeilaoOnline.Selenium.Fixtures;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alura.LeilaoOnline.Selenium.Testes
{
    [Collection("Chrome Driver")]
    public class AoEfetuarRegistro
    {
        private IWebDriver driver;
        
        public AoEfetuarRegistro(TestFixture fixture)
        {
            driver = fixture.Driver;
        }

        [Fact]
        public void DadoInformacoesValidasDeveIrParaPaginaDeAgradecimento()
        {
            //arrange - dado chrome aberto, página inicial do sistema de leilões, dados de registros válidos informados
            driver.Navigate().GoToUrl("http://localhost:5000");


            //nome
            var inputNome = driver.FindElement(By.Id("Nome"));
            //email
            var inputEmail = driver.FindElement(By.Id("Email"));
            //password
            var inputSenha = driver.FindElement(By.Id("Password"));
            //confirmpassword
            var inputConfirmaSenha = driver.FindElement(By.Id("ConfirmPassword"));

            //botão de registro
            var botaoRegistro = driver.FindElement(By.Id("btnRegistro"));


            inputNome.SendKeys("Bianca Veronez");
            inputEmail.SendKeys("Biancavjrp@gmail.com");
            inputSenha.SendKeys("123");
            inputConfirmaSenha.SendKeys("123");
            //botão de registro
            botaoRegistro.Click();



            //act - efetuo o registro



            //assert - devo ser direcionado para uma página de agradecimentos


            Assert.Contains("Obrigado", driver.PageSource);

        }
        }
    }
