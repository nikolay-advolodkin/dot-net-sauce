using System;
using System.Reflection;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Remote;

namespace SeleniumMsTest
{
    [TestClass]
    [TestCategory("SimpleTest")]
    public class SimpleSauceTest
    {
        IWebDriver _driver;
        private TestContext TestContext { get; set; }
        [TestMethod]
        public void DemoSauceCaps()
        {
            var sauceUserName = Environment.GetEnvironmentVariable(
                "SAUCE_USERNAME", EnvironmentVariableTarget.User);
            var sauceAccessKey = Environment.GetEnvironmentVariable(
                "SAUCE_ACCESS_KEY", EnvironmentVariableTarget.User);

            ChromeOptions options = new ChromeOptions();
            options.AddAdditionalCapability(CapabilityType.Version, "latest", true);
            options.AddAdditionalCapability(CapabilityType.Platform, "Windows 10", true);
            options.AddAdditionalCapability("timeZone", "Los Angeles");
            options.AddAdditionalCapability("username", sauceUserName, true);
            options.AddAdditionalCapability("accessKey", sauceAccessKey, true);
            options.AddAdditionalCapability("name", MethodBase.GetCurrentMethod().Name, true);

            _driver =  new RemoteWebDriver(new Uri("https://ondemand.saucelabs.com/wd/hub"), options.ToCapabilities(),
                TimeSpan.FromSeconds(600));
            _driver.Navigate().GoToUrl("https://www.google.com");
        }

        [TestCleanup]
        public void CleanUpAfterEveryTestMethod()
        {
            var passed = TestContext.CurrentTestOutcome == UnitTestOutcome.Passed;
            ((IJavaScriptExecutor)_driver).ExecuteScript("sauce:job-result=" + (passed ? "passed" : "failed"));
            _driver?.Quit();
        }
    }
}
