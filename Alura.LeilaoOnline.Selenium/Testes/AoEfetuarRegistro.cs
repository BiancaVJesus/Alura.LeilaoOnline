using Alura.LeilaoOnline.Selenium.Fixtures;
using OpenQA.Selenium;
using OpenQA.Selenium.DevTools.V136.Overlay;

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

            //utilizando theory que é um teste parâmetrizado e o inline data que é usado para fornecer os valores dos parâmetros do teste. 

            [Theory]

            [InlineData("", "bianca.jesus@gmail.com", "123", "123")]
            [InlineData("Bianca Veronez", "bianca.jesus@gmail.com", "123", "123")]
            [InlineData("Bianca Veronez", "bianca.jesus@gmail.com", "123", "456")]
            [InlineData("", "bianca.jesus@gmail.com", "123", "")]

            public void DadoInfoInvalidasDeveContinuarNaHome (
                string nome,
                string email,
                string senha,
                string confirmaSenha )

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
                ////////////botão de registro
                botaoRegistro.Click();

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

            //botão de registro
            var botaoRegistro = driver.FindElement(By.Id("btnRegistro"));

            //act
            botaoRegistro.Click();

            //assert
            Assert.Contains("The Nome field is required.", driver.PageSource);


        }


    }
    }

