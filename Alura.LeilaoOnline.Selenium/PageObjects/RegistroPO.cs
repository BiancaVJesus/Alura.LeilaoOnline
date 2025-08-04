using OpenQA.Selenium;
using OpenQA.Selenium.DevTools.V136.Network;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit.Sdk;

namespace Alura.LeilaoOnline.Selenium.PageObjects
{
    public class RegistroPO
    {

        private IWebDriver driver;

        private By byFormRegistro;
        private By byInputNome;
        private By byinputEmail;
        private By byinputSenha;
        private By byinputConfirmaSenha;
        private By byBotaoRegistro;
        private By bySpanErroEmail;

        public String EmailMensagemErro => driver.FindElement(bySpanErroEmail).Text;


        public RegistroPO(IWebDriver driver)

        {
            this.driver = driver;

            byFormRegistro = By.TagName("form");
            byInputNome = By.Id("Nome");
            byinputEmail = By.Id("Email");
            byinputSenha = By.Id("Password");
            byinputConfirmaSenha = By.Id("ConfirmPassword");
            byBotaoRegistro = By.Id("btnRegistro");
            bySpanErroEmail = By.CssSelector("span#Email-error");


        }

        public void Visitar()
        {
            driver.Navigate().GoToUrl("http://localhost:5000");
        }


        public void SubmeteFormulario()
        {
            driver.FindElement(byBotaoRegistro).Click();
        }

        public void PreencheFormulario(
            string nome,
            string email,
            string senha,
            string confirmaSenha)
        {
           driver.FindElement(byInputNome).SendKeys(nome);  
           driver.FindElement(byinputEmail).SendKeys(email);
           driver.FindElement(byinputSenha).SendKeys(senha);
           driver.FindElement(byinputConfirmaSenha).SendKeys(confirmaSenha);


        }


     

    }

}


