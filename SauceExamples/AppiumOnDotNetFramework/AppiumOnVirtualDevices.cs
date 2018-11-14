using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Common;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium.Remote;

namespace AppiumOnDotNetFramework
{
    [TestClass]
    [TestCategory("AppiumTest")]
    public class AppiumOnVirtualDevices
    {
        [TestMethod]
        public void SimpleVirtualDeviceTest()
        {
            DesiredCapabilities caps = new DesiredCapabilities();
            caps.SetCapability("deviceName", "Android Emulator");
            caps.SetCapability("deviceOrientation", "portrait");
            caps.SetCapability("browserName", "Chrome");
            caps.SetCapability("platformVersion", "6.0");
            caps.SetCapability("platformName", "Android");
            caps.SetCapability("username", SauceUser.Name);
            caps.SetCapability("accessKey", SauceUser.AccessKey);
            caps.SetCapability("name", MethodBase.GetCurrentMethod().Name);
            caps.SetCapability("newCommandTimeout", 90);

            var driver = new RemoteWebDriver(new Uri(new SauceLabsData().SauceHubUrl), caps);
            //var logEntries = driver.Manage().Logs.GetLog("driver");
            driver.Navigate().GoToUrl("https://www.ultimateqa.com");
            Console.WriteLine("");
            driver.Quit();
        }
    }
}
