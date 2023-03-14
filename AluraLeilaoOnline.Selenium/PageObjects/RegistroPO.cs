using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AluraLeilaoOnline.Selenium.PageObjects
{

    public class RegistroPO
    {
        private IWebDriver driver;
        private By  byFormRegistro;
        private By  byInputNome;
        private By  byInputEmail;
        private By  byInputSenha;
        private By  byInputConfirmSenha;
        private By  byBtnRegistro;
        private By  bySpanErroNome;
        private By  bySpanErroEmail;
        private By  bySpan;
        public string NomeMensagemErro => driver.FindElement(bySpanErroNome).Text;
        public string EmailMensagemErro => driver.FindElement(bySpanErroEmail).Text;
      

        public RegistroPO(IWebDriver driver)
        {
            this.driver = driver;
            byFormRegistro = By.TagName("form");
            byInputNome = By.Id("Nome");
            byInputEmail = By.Id("Email");
            byInputSenha = By.Id("Password");
            byInputConfirmSenha = By.Id("ConfirmPassword");
            byBtnRegistro = By.Id("btnRegistro");
            bySpanErroNome = By.CssSelector("span.msg-erro[data-valmsg-for=Nome]");
            bySpanErroEmail = By.CssSelector("span.msg-erro[data-valmsg-for=Email]");
            bySpan = By.TagName("span");
        }

        public void Visitar()
        {
            driver.Navigate().GoToUrl("http://localhost:5000");
        }

        public void PreencheFormulario(
            string nome, 
            string email, 
            string senha, 
            string confirmSenha)
        {
            driver.FindElement(byInputNome).SendKeys(nome);
            driver.FindElement(byInputEmail).SendKeys(email);
            driver.FindElement(byInputSenha).SendKeys(senha);
            driver.FindElement(byInputConfirmSenha).SendKeys(confirmSenha);
            driver.FindElement(byBtnRegistro).Click();  

        }
    }
}
