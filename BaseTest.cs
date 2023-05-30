using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CSharpFrameWork
{
    public class BaseTest
    {
        public IWebDriver driver;

        [TestInitialize]
        public void OpenApplication()
        {
            driver = new ChromeDriver();
            driver.Navigate().GoToUrl("http://adactinhotelapp.com/");
        }

        [TestCleanup]
        public void CleanSession()
        {
            driver.Quit();
        }

    }
}
