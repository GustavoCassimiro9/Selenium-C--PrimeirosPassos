using AluraLeilaoOnline.Selenium.Fixtures;
using AluraLeilaoOnline.Selenium.PageObjects;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.Reflection;

namespace AluraLeilaoOnline.Selenium.Testes
{
    [Collection("Chrome Driver")]
    public class AoNavegarParaAHome
    {

        //setup
        private IWebDriver driver;

        public AoNavegarParaAHome(TestFixtures fixture)
        {
            driver = fixture.Driver;
        }

        [Fact]
        public void DadoChromeAbertoDeveMostrarLeiloesNoTitulo()
        {

            var registroPO = new RegistroPO(driver);
            registroPO.Visitar();
            Assert.Contains("Leil�es", driver.Title);

        }

        [Fact]
        public void DadoChromeAbertoDeveMostrarProximosLeiloesNaPagina()
        {

            var registroPO = new RegistroPO(driver);
            registroPO.Visitar();
            Assert.Contains("Pr�ximos Leil�es", driver.PageSource);

        }

        [Fact]
        public void DadoChromeAbertoFormRegistroN�oDeveMostrarMensagensDeErro()
        {

            var registroPO = new RegistroPO(driver);
            registroPO.Visitar();

            var form = driver.FindElement(By.TagName("form"));
            var spans = form.FindElements(By.TagName("span"));
            foreach ( var span in spans )
            {
                Assert.True(string.IsNullOrEmpty(span.Text));

            }

            Assert.Contains("Pr�ximos Leil�es", driver.PageSource);

        }
    }
}