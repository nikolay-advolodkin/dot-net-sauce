using System;
using System.Collections.Generic;
using NUnit.Framework;
using NUnit.Framework.Interfaces;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Remote;
using OpenQA.Selenium.Safari;

namespace SeleniumNunit.SimpleExamples
{
    [TestFixture]
    [Category("Selenium 4 tests")]
    public class Selenium4
    {
        IWebDriver _driver;
        private string sauceUserName;
        private string sauceAccessKey;
        private Dictionary<string, object> sauceOptions;

        [Test]
        public void W3CEdge()
        {
            var options = new EdgeOptions()
            {
                BrowserVersion = "latest",
                PlatformName = "Windows 10",
                AcceptInsecureCertificates = true
            };

            sauceOptions.Add("name", TestContext.CurrentContext.Test.Name);
            //sauceOptions.Add("avoidProxy", true);

            options.AddAdditionalCapability("sauce:options", sauceOptions);

            _driver = new RemoteWebDriver(new Uri("https://ondemand.saucelabs.com/wd/hub"), options.ToCapabilities(),
                TimeSpan.FromSeconds(600));
            _driver.Navigate().GoToUrl("https://www.google.com");
            Assert.Pass();
        }

        [Test]
        public void W3CChrome()
        {
            var chromeOptions = new ChromeOptions()
            {
                BrowserVersion = "latest",
                PlatformName = "Windows 10",
                UseSpecCompliantProtocol = true
            };
            sauceOptions.Add("name", TestContext.CurrentContext.Test.Name);
            chromeOptions.AddAdditionalCapability("sauce:options", sauceOptions, true);

            _driver = new RemoteWebDriver(new Uri("https://ondemand.saucelabs.com/wd/hub"), 
                chromeOptions.ToCapabilities(), TimeSpan.FromSeconds(600));
            _driver.Navigate().GoToUrl("https://www.google.com");
            Assert.Pass();
        }
        [Test]
        public void W3CSafari()
        {
            SafariOptions safariOptions = new SafariOptions
            {
                BrowserVersion = "12.0",
                PlatformName = "macOS 10.13"                
                //AcceptInsecureCertificates = true Don't use this as Safari doesn't support Insecure certs
            };
            sauceOptions.Add("name", TestContext.CurrentContext.Test.Name);

            safariOptions.AddAdditionalCapability("sauce:options", sauceOptions);

            _driver = new RemoteWebDriver(new Uri("https://ondemand.saucelabs.com/wd/hub"),
                safariOptions.ToCapabilities(), TimeSpan.FromSeconds(600));
            _driver.Navigate().GoToUrl("https://www.saucedemo.com");
            Assert.Pass();
        }
        [SetUp]
        public void SetupTests()
        {
            //TODO please supply your Sauce Labs user name in an environment variable
            sauceUserName = Environment.GetEnvironmentVariable("SAUCE_USERNAME", EnvironmentVariableTarget.User);
            //TODO please supply your own Sauce Labs access Key in an environment variable
            sauceAccessKey = Environment.GetEnvironmentVariable("SAUCE_ACCESS_KEY", EnvironmentVariableTarget.User);
            sauceOptions = new Dictionary<string, object>
            {
                ["username"] = sauceUserName,
                ["accessKey"] = sauceAccessKey
            };
        }
        [TearDown]
        public void CleanUpAfterEveryTestMethod()
        {
            var passed = TestContext.CurrentContext.Result.Outcome.Status == TestStatus.Passed;
            if(_driver != null)
                ((IJavaScriptExecutor)_driver).ExecuteScript("sauce:job-result=" + (passed ? "passed" : "failed"));
            _driver?.Quit();
        }
    }
}
