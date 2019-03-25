using Common;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Remote;
using System;
using System.Collections.Generic;

namespace SeleniumNunit.SaucePerformance
{
    [TestFixture]
    public class PerformanceDemo
    {
        [Test]
        [Repeat(5)]
        public void PerformanceTest()
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
                ["capturePerformance"] = true
            };
            chromeOptions.AddAdditionalCapability("sauce:options", sauceOptions, true);

            var driver = new RemoteWebDriver(new Uri("https://ondemand.saucelabs.com/wd/hub"),
                chromeOptions.ToCapabilities(), TimeSpan.FromSeconds(600));
            driver.Navigate().GoToUrl("https://www.saucedemo.com");

            var isPassed = TestContext.CurrentContext.Result.Outcome.Status == NUnit.Framework.Interfaces.TestStatus.Passed;
            new SauceJavaScriptExecutor(driver).LogTestStatus(isPassed);

            //var logType = new Dictionary<string, object>();
            //logType.Add("type", "sauce:performance");

            //var performanceMetrics = ((IJavaScriptExecutor) driver).ExecuteScript("sauce:performance", logType);
            driver.Quit();
        }
    }
}
