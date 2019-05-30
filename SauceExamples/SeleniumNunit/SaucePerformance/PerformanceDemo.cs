using Common;
using NUnit.Framework;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Remote;
using System;
using System.Collections.Generic;

namespace SeleniumNunit.SaucePerformance
{
    [TestFixture]
    [Category("performance")]
    public class PerformanceDemo
    {
        public RemoteWebDriver Driver { get; set; }

        [SetUp]
        public void RunBeforeEveryTest()
        {
            var sauceUserName = Environment.GetEnvironmentVariable("SAUCE_USERNAME", EnvironmentVariableTarget.User);
            var sauceAccessKey = Environment.GetEnvironmentVariable("SAUCE_ACCESS_KEY", EnvironmentVariableTarget.User);

            var chromeOptions = new ChromeOptions()
            {
                BrowserVersion = "latest",
                PlatformName = "Windows 10",
                UseSpecCompliantProtocol = true
            };
            var sauceOptions = new Dictionary<string, object>
            {
                ["username"] = sauceUserName,
                ["accessKey"] = sauceAccessKey,
                ["name"] = TestContext.CurrentContext.Test.Name,
                ["extendedDebugging"] = true,
                ["capturePerformance"] = true,
                ["crmuxdriverVersion"] = "beta"
            };
            chromeOptions.AddAdditionalCapability("sauce:options", sauceOptions, true);

            Driver = new RemoteWebDriver(new Uri("https://ondemand.saucelabs.com/wd/hub"),
                chromeOptions.ToCapabilities(), TimeSpan.FromSeconds(600));
        }

        [TearDown]
        public void CleanUp()
        {
            var isPassed = TestContext.CurrentContext.Result.Outcome.Status == NUnit.Framework.Interfaces.TestStatus.Passed;
            new SauceJavaScriptExecutor(Driver).LogTestStatus(isPassed);
            Driver.Quit();
        }
        [Test]
        [Ignore("Currently not working with Sauce W3c")]

        public void W3CTestForSauceDemo()
        {
            //Login steps here
            Driver.Navigate().GoToUrl("https://www.saucedemo.com");
        }

        [Test]
        [Ignore("Currently not working with Sauce W3c")]
        public void W3CTestForUltimateQA()
        {
            Driver.Navigate().GoToUrl("https://www.ultimateqa.com");
        }
    }
}
