using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AluraLeilaoOnline.Selenium.Fixtures
{
    public class TestFixtures: IDisposable
    {
        public IWebDriver Driver { get; private set; }

        //Setup
        public TestFixtures()
        {
            Driver = new ChromeDriver();
        }

        //TearDown
        public void Dispose()
        {
            Driver.Quit();
        }
    }
}
