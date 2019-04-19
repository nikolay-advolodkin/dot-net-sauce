using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.Collections.Generic;
using System.IO;
using System.Reflection;


namespace Selenium4DotNetFramework
{
    [TestClass]
    [TestCategory("WebDriver 4 tests on Sauce")]
    public class Selenium4Tests
    {
        IWebDriver _driver;

        public TestContext TestContext { get; set; }

        [TestMethod]
        public void ChromeTest()
        {
            var driverLocation = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            var driver = new ChromeDriver(driverLocation + @"\Drivers");
            driver.Navigate().GoToUrl("https://the-internet.herokuapp.com/windows");
            driver.FindElement(By.LinkText("Click Here")).Click();
            driver.SwitchTo().NewWindow(WindowType.Window);
        }
        [TestCleanup]
        public void CleanUpAfterEveryTestMethod()
        {
            _driver?.Quit();
        }
    }
}
