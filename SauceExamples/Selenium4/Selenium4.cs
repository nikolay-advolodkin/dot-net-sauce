using System;
using Newtonsoft.Json.Linq;
using NUnit.Framework;
using NUnit.Framework.Interfaces;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Remote;

namespace Selenium4
{
    [TestFixture]
    [Category("SimpleTest")]
    public class Selenium4
    {
        IWebDriver Driver;
        [Test]
        public void SimpleSelenium4Example()
        {

            //TODO please supply your Sauce Labs user name in an environment variable
            var sauceUserName = Environment.GetEnvironmentVariable("SAUCE_USERNAME", EnvironmentVariableTarget.User);
            //TODO please supply your own Sauce Labs access Key in an environment variable
            var sauceAccessKey = Environment.GetEnvironmentVariable("SAUCE_ACCESS_KEY", EnvironmentVariableTarget.User);

            ChromeOptions options = new ChromeOptions
            {
                UseSpecCompliantProtocol = true,
                BrowserVersion = "latest",
                PlatformName = "Windows 10"
            };

            var sauceOptions = new JObject
            {
                ["username"] = sauceUserName,
                ["accessKey"] = sauceAccessKey,
                ["name"] = TestContext.CurrentContext.Test.Name
            };
            options.AddAdditionalCapability("sauce:options", sauceOptions.ToString(), true);

            Driver = new RemoteWebDriver(new Uri("http://ondemand.saucelabs.com:80/wd/hub"), options.ToCapabilities(),
                TimeSpan.FromSeconds(600));
            Driver.Navigate().GoToUrl("https://www.google.com");
            Assert.Pass();
        }

        [TearDown]
        public void CleanUpAfterEveryTestMethod()
        {
            var passed = TestContext.CurrentContext.Result.Outcome.Status == TestStatus.Passed;
            ((IJavaScriptExecutor)Driver)?.ExecuteScript("sauce:job-result=" + (passed ? "passed" : "failed"));
            Driver?.Quit();
        }
    }
}
