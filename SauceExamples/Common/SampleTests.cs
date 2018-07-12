using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Appium.Android;
using OpenQA.Selenium.Remote;

namespace Common
{
    public class SampleTests
    {
        public void TestNativeAndroidApp(string testName)
        {
            var capabilities = new DesiredCapabilities();
            capabilities.SetCapability("platformName", "Android");
            capabilities.SetCapability("platformVersion", "7.1.1");
            //TODO first you must upload an app to Test Object so that you get your app key
            capabilities.SetCapability("testobject_api_key", "0D6C044F19D0442BA1E11C3FF087F6A6");
            capabilities.SetCapability("deviceName", "Google Pixel");
            capabilities.SetCapability("deviceOrientation", "portrait");
            capabilities.SetCapability("name", testName);

            var rdcUrl = "https://us1.appium.testobject.com/wd/hub";
            //TODO should be interchangeable to run on Windows/Mac
            var sauceUser = Environment.GetEnvironmentVariable("SAUCE_USERNAME", EnvironmentVariableTarget.User);
            var sauceKey = Environment.GetEnvironmentVariable("SAUCE_ACCESS_KEY", EnvironmentVariableTarget.User);
            var sauceUlr =
                $"https://{sauceUser}:{sauceKey}@ondemand.saucelabs.com:443/wd/hub";
            var driver = new AndroidDriver<IWebElement>(new Uri(rdcUrl), capabilities);
            var logEntries = driver.Manage().Logs.GetLog("driver");
            Console.WriteLine(logEntries);
            driver.Quit();
        }
    }
}
