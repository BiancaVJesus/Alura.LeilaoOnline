using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebDriverManager;
using WebDriverManager.DriverConfigs.Impl;

namespace Alura.LeilaoOnline.Selenium.Helpers
{
    public static class TestHelpers
    {
        public static string PastaDoExecutavel => new DriverManager().SetUpDriver(new ChromeConfig());
       
    }
}
