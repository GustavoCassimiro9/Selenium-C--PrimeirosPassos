using AluraLeilaoOnline.Selenium.Fixtures;
using AluraLeilaoOnline.Selenium.PageObjects;
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
            var registroPO = new RegistroPO(driver);
            registroPO.Visitar();

            registroPO.PreencheFormulario(
                nome: "Testando",
                email: "Daniel@gmail.com",
                senha: "123",
                confirmSenha: "123"

                );
                
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

            var registroPO = new RegistroPO(driver);
            registroPO.Visitar();

            registroPO.PreencheFormulario(
                nome: nome,
                email: email,
                senha: password,
                confirmSenha: confirmPassword

            );

            Assert.Contains("section-registro", driver.PageSource);
        }
        [Fact]
        public void DadoNomeEmBrancoDeveAparecerMsgDeErro()
        {
   
            var registroPO = new RegistroPO(driver);
            registroPO.Visitar();

            registroPO.PreencheFormulario(
                nome: "",
                email: "Gustavo@gmail.com",
                senha: "123",
                confirmSenha: "123"

            );

            Assert.Equal("The Nome field is required.", registroPO.NomeMensagemErro);
        }
        [Fact]
        public void DadoEmailInvalidoDeveAparecerMsgDeErro()
        {
            var registroPO = new RegistroPO(driver);
            registroPO.Visitar();

            registroPO.PreencheFormulario(
                nome: "Gustavo",
                email: "Gustavo.com",
                senha: "123",
                confirmSenha: "123"

            );            
            Assert.Equal("Please enter a valid email address.", registroPO.EmailMensagemErro);
        }


    }
}
