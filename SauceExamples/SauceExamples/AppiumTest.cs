using System;
using System.Reflection;
using Common;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Appium.Android;
using OpenQA.Selenium.Remote;

namespace AppiumMsTest
{
    [TestClass]
    public class AppiumTest
    {
        [TestMethod]
        public void TestMethod1()
        {
            var capabilities = new DesiredCapabilities();
            capabilities.SetCapability("platformName", "Android");
            capabilities.SetCapability("platformVersion", "7.1.1");
            capabilities.SetCapability("testobject_api_key", "0D6C044F19D0442BA1E11C3FF087F6A6");
            capabilities.SetCapability("deviceName", "Google Pixel");
            capabilities.SetCapability("deviceOrientation", "portrait");
            capabilities.SetCapability("name", MethodBase.GetCurrentMethod().Name);

            var rdcUrl = "https://us1.appium.testobject.com/wd/hub";
            var sauceUser = Environment.GetEnvironmentVariable("SAUCE_USERNAME", EnvironmentVariableTarget.User);
            var sauceKey = Environment.GetEnvironmentVariable("SAUCE_ACCESS_KEY", EnvironmentVariableTarget.User);
            var sauceUlr =
                $"https://{sauceUser}:{sauceKey}@ondemand.saucelabs.com:443/wd/hub";
            var driver = new AndroidDriver<IWebElement>(new Uri(rdcUrl), capabilities);
            driver.Quit();
        }
        [TestMethod]
        public void UsingSameResourcesAsDotNetFramework()
        {
            new SampleTests().TestNativeAndroidApp(MethodBase.GetCurrentMethod().Name);
        }
    }
}
