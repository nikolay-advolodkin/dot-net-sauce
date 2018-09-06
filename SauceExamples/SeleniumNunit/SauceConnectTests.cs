using NUnit.Framework;
using NUnit.Framework.Interfaces;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Remote;
using System;

namespace SeleniumNunit
{
    [TestFixture]
    public class SauceConnectTests
    {
        IWebDriver _driver;

        [Test]
        public void SampleSauceTestWithDesiredCaps()
        {
            //TODO please supply your Sauce Labs user name in an environment variable
            var sauceUserName = Environment.GetEnvironmentVariable("SAUCE_USERNAME", EnvironmentVariableTarget.User);
            //TODO please supply your own Sauce Labs access Key in an environment variable
            var sauceAccessKey = Environment.GetEnvironmentVariable("SAUCE_ACCESS_KEY", EnvironmentVariableTarget.User);

            var desiredCaps = new DesiredCapabilities();
            desiredCaps.SetCapability(CapabilityType.Version, "latest");
            desiredCaps.SetCapability(CapabilityType.Platform, "Windows 10");
            desiredCaps.SetCapability(CapabilityType.BrowserName, "chrome");

            desiredCaps.SetCapability("username", sauceUserName);
            desiredCaps.SetCapability("accessKey", sauceAccessKey);
            desiredCaps.SetCapability("name", TestContext.CurrentContext.Test.Name);
            desiredCaps.SetCapability("extendedDebugging", true);
            desiredCaps.SetCapability("tunnelIdentifier", "NikolaysTunnel");
            //How long is a test allowed to run?
            desiredCaps.SetCapability("maxDuration", 3600);
            //Selenium crash might hang a command, this is the max time allowed to wait for a Selenium command
            desiredCaps.SetCapability("commandTimeout", 600);
            //How long can the browser wait before a new command?
            desiredCaps.SetCapability("idleTimeout", 1000);
            _driver = new RemoteWebDriver(new Uri("http://ondemand.saucelabs.com:80/wd/hub"), desiredCaps, TimeSpan.FromSeconds(600));
            _driver.Navigate().GoToUrl("https://www.google.com");
            Assert.Pass();
        }

        [Test]
        public void SampleSauceTestWithChromeOptions()
        {
            //TODO please supply your Sauce Labs user name in an environment variable
            var sauceUserName = Environment.GetEnvironmentVariable("SAUCE_USERNAME", EnvironmentVariableTarget.User);
            //TODO please supply your own Sauce Labs access Key in an environment variable
            var sauceAccessKey = Environment.GetEnvironmentVariable("SAUCE_ACCESS_KEY", EnvironmentVariableTarget.User);

            ChromeOptions options = new ChromeOptions();
            options.AddAdditionalCapability(CapabilityType.Version, "latest", true);
            options.AddAdditionalCapability(CapabilityType.Platform, "Windows 10", true);
            options.AddAdditionalCapability("username", sauceUserName, true);
            options.AddAdditionalCapability("accessKey", sauceAccessKey, true);
            options.AddAdditionalCapability("name", TestContext.CurrentContext.Test.Name, true);
            options.AddAdditionalCapability("tunnelIdentifier", "NikolaysTunnel");
            _driver = new RemoteWebDriver(new Uri("http://ondemand.saucelabs.com:80/wd/hub"), options.ToCapabilities(),
                TimeSpan.FromSeconds(600));

            _driver.Navigate().GoToUrl("https://www.google.com");
            Assert.Pass();
        }
        [TearDown]
        public void CleanUpAfterEveryTestMethod()
        {
            var passed = TestContext.CurrentContext.Result.Outcome.Status == TestStatus.Passed;
            ((IJavaScriptExecutor)_driver).ExecuteScript("sauce:job-result=" + (passed ? "passed" : "failed"));
            _driver?.Quit();
        }
    }
}
