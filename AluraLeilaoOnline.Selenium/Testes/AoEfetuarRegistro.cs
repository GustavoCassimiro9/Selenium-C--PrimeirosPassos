using AluraLeilaoOnline.Selenium.Fixtures;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using Xunit;

namespace AluraLeilaoOnline.Selenium.Testes
{
    [Collection("Chrome Driver")]
    public class AoEfetuarRegistro
    {
        private IWebDriver driver;
        public AoEfetuarRegistro(TestFixtures fixtures)
        {
            driver = fixtures.Driver;
        }
        [Fact]
        public void DadoInfoValidasDeveIrParaPaginaDeAgradecimento()
        {
            //arrange
            driver.Navigate().GoToUrl("http://localhost:5000");

            //Nome
            var inputNome = driver.FindElement(By.Id("Nome"));
            //Email
            var inputEmail = driver.FindElement(By.Id("Email"));
            //Senha
            var inputSenha = driver.FindElement(By.Id("Password"));
            //Confirma senha
            var inputConfirmSenha = driver.FindElement(By.Id("ConfirmPassword"));
            //Button registro
            var botaoRegistro = driver.FindElement(By.Id("btnRegistro"));

            inputNome.SendKeys("Gustavo");
            inputEmail.SendKeys("gustavo@gmail.com");
            inputSenha.SendKeys("123");
            inputConfirmSenha.SendKeys("123");

            //act - efetuo o registro
            botaoRegistro.Click();

            //assert - devo ser redirecionado para uma pagina de agradecimento
            Assert.Contains("Obrigado", driver.PageSource);
        }


        [Theory]
        [InlineData("", "", "", "")]
        [InlineData("Gusta", "gusta.com", "123", "123")]
        [InlineData("", "gusta@gmail.com", "123", "123")]
        [InlineData("gusta", "gusta@gmail.com", "123", "321")]
        public void DadoInfoInvalidasDeveContinuarNaHome(string nome, string email, string password, string confirmPassword)
        {
            //arrange
            driver.Navigate().GoToUrl("http://localhost:5000");

            //Nome
            var inputNome = driver.FindElement(By.Id("Nome"));
            //Email
            var inputEmail = driver.FindElement(By.Id("Email"));
            //Senha
            var inputSenha = driver.FindElement(By.Id("Password"));
            //Confirma senha
            var inputConfirmSenha = driver.FindElement(By.Id("ConfirmPassword"));
            //Button registro
            var botaoRegistro = driver.FindElement(By.Id("btnRegistro"));

            inputNome.SendKeys(nome);
            inputEmail.SendKeys(email);
            inputSenha.SendKeys(password);
            inputConfirmSenha.SendKeys(confirmPassword);

            //act - efetuo o registro
            botaoRegistro.Click();

            //assert - devo ser redirecionado para uma pagina de agradecimento
            Assert.Contains("section-registro", driver.PageSource);
        }

        public void DadoNomeEmBrancoDeveAparecerMsgDeErro()
        {
            //arrange
            var botaoRegistro = driver.FindElement(By.Id("btnRegistro"));
            //act
            botaoRegistro.Click();
            //assert
       
            Assert.Contains("The Nome field is required.", driver.PageSource);
        }


    }
}
