using System;
using Common;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Android;
using OpenQA.Selenium.Appium.Enums;

namespace AppiumBetaMSTest
{
    [TestClass]
    [TestCategory("AppiumTest")]

    public class Rdc
    {
        [TestMethod]
        [TestCategory("UsingAppiumOptions")]
        public void SimpleTest()
        {
            var appiumOptions = new AppiumOptions();
            appiumOptions.AddAdditionalCapability(MobileCapabilityType.PlatformName, "Android");
            appiumOptions.AddAdditionalCapability(MobileCapabilityType.PlatformVersion, "7.1.1");

            appiumOptions.AddAdditionalCapability(MobileCapabilityType.FullReset, true);
            appiumOptions.AddAdditionalCapability(MobileCapabilityType.NewCommandTimeout, 60);

            appiumOptions.AddAdditionalCapability("testobject_api_key", "0D6C044F19D0442BA1E11C3FF087F6A6");
            appiumOptions.AddAdditionalCapability("username", SauceUser.Name);
            appiumOptions.AddAdditionalCapability("accessKey", SauceUser.AccessKey);
            //TODO first you must upload an app to Test Object so that you get your app key

            var rdcUrl = "https://us1.appium.testobject.com/wd/hub";
            var driver = new AndroidDriver<IWebElement>(new Uri(rdcUrl), appiumOptions);
            driver.Navigate().GoToUrl("https://www.ultimateqa.com");
            Console.WriteLine("");
            driver.Quit();
        }
    }
}
