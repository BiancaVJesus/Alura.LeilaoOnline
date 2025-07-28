using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Alura.LeilaoOnline.Selenium.Helpers;
namespace Alura.LeilaoOnline.Selenium.Fixtures
{

    public class TestFixture : IDisposable

    {

        //propriedade para ser utilizada nas classes que utilizarão a fixture
        public IWebDriver Driver { get; private set; }

        //setup
        public TestFixture()
        {
            Driver = new ChromeDriver(TestHelpers.PastaDoExecutavel);
        }

        //teardrown
        public void Dispose()
        {
            Driver.Quit();
        }

    }



}
