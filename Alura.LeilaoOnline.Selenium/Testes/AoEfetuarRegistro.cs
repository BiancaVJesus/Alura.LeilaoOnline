using Alura.LeilaoOnline.Selenium.Fixtures;
using OpenQA.Selenium;
using OpenQA.Selenium.DevTools.V136.Overlay;
using OpenQA.Selenium.Support.UI;
using System;
using static System.Net.Mime.MediaTypeNames;
using static System.Runtime.InteropServices.JavaScript.JSType;

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


            //act - efetuo o registro

            botaoRegistro.Click();

            //assert - devo ser direcionado para uma página de agradecimentos




            // **** CÓDIGO CORRIGIDO ABAIXO ****

            // 1. Crie um objeto de espera, configurado para esperar até 10 segundos.
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));

            // 2. Diga ao 'wait' para esperar ATÉ que a URL contenha "Agradecimento".
            //    Se isso não acontecer em 10 segundos, o teste vai falhar com um erro de Timeout,
            //    o que é mais informativo do que o erro atual.
            //    (OBS: Verifique se a URL da sua página de agradecimento realmente contém essa palavra).
            wait.Until(drv => drv.Url.Contains("Agradecimento"));

            // 3. Somente DEPOIS que a espera for concluída, faça a verificação.
            //    Neste ponto, temos certeza que a página correta carregou.
            Assert.Contains("Obrigado", driver.PageSource);



            //se colocarmos apenas o assert contains

            Assert.Contains("Obrigado", driver.PageSource);

        }

        //utilizando theory que é um teste parâmetrizado e o inline data que é usado para fornecer os valores dos parâmetros do teste. 

        [Theory]

        [InlineData("", "bianca.jesus@gmail.com", "123", "123")]
        [InlineData("Bianca Veronez", "bianca.jesus@gmail.com", "12", "123")]
        [InlineData("Bianca Veronez", "bianca.jesus@gmail.com", "123", "456")]
        [InlineData("", "bianca.jesus@gmail.com", "123", "")]

        public void DadoInfoInvalidasDeveContinuarNaHome(

            string nome,
            string email,
            string senha,
            string confirmaSenha)

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

            inputNome.SendKeys(nome);
            inputEmail.SendKeys(email);
            inputSenha.SendKeys(senha);
            inputConfirmaSenha.SendKeys(confirmaSenha);

            //act - efetuo o registro

            botaoRegistro.Click();

            //assert - devo ser direcionado para uma página de agradecimentos

            Assert.Contains("section-registro", driver.PageSource);

        }

        [Fact]
        public void DadoNomeEmBrancoDeveMostrarMensagemDeErro()
        {
            //arrange
            driver.Navigate().GoToUrl("http://localhost:5000");

            //email
            var botaoRegistro= driver.FindElement(By.Id("btnRegistro"));
           
            //act
            botaoRegistro.Click();

            //assert
            IWebElement elemento = driver.FindElement(By.CssSelector("span#Nome-error"));
            Assert.Equal("The Nome field is required.", elemento.Text);        
        }

        [Fact]
        public void DadoEmailInvalidoDeveMostrarMensagemDeErro()
        {
            //arrange
            driver.Navigate().GoToUrl("http://localhost:5000");

            //email
            var inputEmail = driver.FindElement(By.Id("Email"));
            inputEmail.SendKeys("Bianca");

            //botao de registro 
            var botaoRegistro = driver.FindElement(By.Id("btnRegistro"));

            //act

            botaoRegistro.Click();

            //assert
            IWebElement elemento = driver.FindElement(By.CssSelector("span#Email-error"));
            Assert.Equal("Please enter a valid email address.", elemento.Text);


        }
    }
}






    
    

