using System;
using System.Threading;
using NUnit.Framework;
using NUnit.Framework.Interfaces;
using OpenQA.Selenium;
using OpenQA.Selenium.Remote;

namespace Web.Tests
{
    /*
     * These scripts are simply for demonstration purposes.
     * They should not be used as an example of good practices for how to do test automation.
     */
    [TestFixture]
    [Category("InstantSauceTest"), Category("NUnit"), Category("Instant")]
    [Parallelizable]
    public class InstantSauceTest4
    {
        private IWebDriver _driver;
        [Test]
        public void ShouldOpenOnDifferentBrowser()
        {
            var sauceUserName =
                Environment.GetEnvironmentVariable("SAUCE_USERNAME", EnvironmentVariableTarget.User);       
            var sauceAccessKey = 
                Environment.GetEnvironmentVariable("SAUCE_ACCESS_KEY", EnvironmentVariableTarget.User);

            DesiredCapabilities caps = new DesiredCapabilities();
            caps.SetCapability("browserName", "MicrosoftEdge");
            caps.SetCapability("platform", "Windows 10");
            caps.SetCapability("version", "16.16299");
            caps.SetCapability("username", sauceUserName);
            caps.SetCapability("accessKey", sauceAccessKey);
            caps.SetCapability("name", TestContext.CurrentContext.Test.Name);
            _driver = new RemoteWebDriver(new Uri("http://ondemand.saucelabs.com:80/wd/hub"),
                caps, TimeSpan.FromSeconds(600));
            
            //TODO Please supply your publicly available web url in place of saucedemo.com
            //In the future, you will learn how to access private URLs
            _driver.Navigate().GoToUrl("https://www.saucedemo.com");
            
            Thread.Sleep(10000);
            Assert.IsTrue(true);
        }

        [TearDown]
        public void CleanUpAfterEveryTestMethod()
        {
            var passed = TestContext.CurrentContext.Result.Outcome.Status == TestStatus.Passed;
            ((IJavaScriptExecutor)_driver).ExecuteScript("sauce:job-result=" + (passed ? "passed" : "failed"));
            _driver?.Quit();
        }
    }

    [TestFixture]
    [Category("InstantSauceTest"), Category("NUnit"), Category("Instant")]
    [Parallelizable]
    public class InstantSauceTest5
    {
        private IWebDriver _driver;
        [Test]
        public void ShouldOpenOnDifferentBrowser()
        {
            var sauceUserName =
                Environment.GetEnvironmentVariable("SAUCE_USERNAME", EnvironmentVariableTarget.User);
            var sauceAccessKey =
                Environment.GetEnvironmentVariable("SAUCE_ACCESS_KEY", EnvironmentVariableTarget.User);

            DesiredCapabilities caps = new DesiredCapabilities();
            caps.SetCapability("browserName", "Safari");
            caps.SetCapability("platform", "macOS 10.13");
            caps.SetCapability("version", "11.1");
            caps.SetCapability("username", sauceUserName);
            caps.SetCapability("accessKey", sauceAccessKey);
            caps.SetCapability("name", TestContext.CurrentContext.Test.Name);
            _driver = new RemoteWebDriver(new Uri("http://ondemand.saucelabs.com:80/wd/hub"),
                caps, TimeSpan.FromSeconds(600));

            //TODO Please supply your publicly available web url in place of saucedemo.com
            //In the future, you will learn how to access private URLs
            _driver.Navigate().GoToUrl("https://www.saucedemo.com");

            Thread.Sleep(10000);
            Assert.IsTrue(true);
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
