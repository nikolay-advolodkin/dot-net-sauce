using System.Reflection;
using Common;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Appium.Android;

namespace AppiumMsTest
{
    [TestClass]
    [TestCategory("MsTest")]
    [TestCategory("Emusim")]
    [TestCategory("Android")]

    public class Emusim
    {
        [TestMethod]
        public void Android71()
        {
            var capabilities = new SauceLabs().GetDesiredCapabilities();
            capabilities.SetCapability("appiumVersion", "1.9.1");
            capabilities.SetCapability("deviceName", "Samsung Galaxy Tab A 10 GoogleAPI Emulator");
            capabilities.SetCapability("deviceOrientation", "portrait");
            capabilities.SetCapability("browserName", "Chrome");
            capabilities.SetCapability("platformVersion", "7.1");
            capabilities.SetCapability("platformName", "Android");
            capabilities.SetCapability("name", MethodBase.GetCurrentMethod().Name);
            capabilities.SetCapability("newCommandTimeout", 90);

            var driver = new AndroidDriver<IWebElement>(new SauceLabsEndpoint().SauceHubUri, capabilities);
            driver.Navigate().GoToUrl("https://www.saucedemo.com");
            Assert.IsTrue(true);
            driver.Quit();
        }
    }
}
