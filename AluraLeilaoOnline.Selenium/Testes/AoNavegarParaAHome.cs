using AluraLeilaoOnline.Selenium.Fixtures;
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

            driver.Navigate().GoToUrl("http://localhost:5000");
            //Assert
            Assert.Contains("Leil�es", driver.Title);

        }

        [Fact]
        public void DadoChromeAbertoDeveMostrarProximosLeiloesNaPagina()
        {

            driver.Navigate().GoToUrl("http://localhost:5000");

            Assert.Contains("Pr�ximos Leil�es", driver.PageSource);

        }
    }
}