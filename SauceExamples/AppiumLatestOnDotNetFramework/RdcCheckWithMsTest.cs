using System;
using System.Reflection;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Appium.Android;
using OpenQA.Selenium.Remote;

namespace AppiumLatestOnDotNetFramework
{
    [TestClass]
    [TestCategory("MsTest")]
    [TestCategory("Rdc")]
    [TestCategory("Android")]

    public class RdcCheckWithMsTest
    {
        [TestMethod]
        public void RunRdcOnAndroid()
        {
            var capabilities = new DesiredCapabilities();
            capabilities.SetCapability("platformName", "Android");
            capabilities.SetCapability("platformVersion", "7.1.1");
            //TODO first you must upload an app to Test Object so that you get your app key
            capabilities.SetCapability("testobject_api_key", "0D6C044F19D0442BA1E11C3FF087F6A6");
            capabilities.SetCapability("name", MethodBase.GetCurrentMethod().Name);
            capabilities.SetCapability("newCommandTimeout", 90);

            var rdcUrl = "https://us1.appium.testobject.com/wd/hub";
            //TODO should be interchangeable to run on Windows/Mac
            var driver = new AndroidDriver<IWebElement>(new Uri(rdcUrl), capabilities);
            //var logEntries = driver.Manage().Logs.GetLog("driver");
            driver.Navigate().GoToUrl("https://www.ultimateqa.com");
            Console.WriteLine("");
            driver.Quit();
        }
    }
}
