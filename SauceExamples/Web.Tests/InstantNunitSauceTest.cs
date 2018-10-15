using System;
using Common;
using NUnit.Framework;
using NUnit.Framework.Interfaces;
using OpenQA.Selenium;
using OpenQA.Selenium.Remote;
using OpenQA.Selenium.Support.UI;
using ExpectedConditions = SeleniumExtras.WaitHelpers.ExpectedConditions;

namespace Web.Tests
{
    [TestFixture]
    [Category("InstantNunitSauceTest"), Category("NUnit"), Category("Instant")]
    public class InstantNunitSauceTest
    {
        private IWebDriver _driver;
        [Test]
        public void ShouldOpenOnSafari()
        {
            //TODO You can find your Sauce Labs username and access key in the
            // User Profile > User Settings section of your Sauce Labs dashboard
            //const string sauceUserName = "YOUR SAUCE USER NAME HERE";
            //const string sauceAccessKey = "YOUR SAUCE API KEY HERE";
            var sauceUserName = SauceUser.Name;
            var sauceAccessKey = SauceUser.AccessKey;

            /*
             * In this section, we will configure our test to run on some specific
             * browser/os combination in Sauce Labs
             */
            var capabilities = new DesiredCapabilities();
            //set browser to Safari
            capabilities.SetCapability("browserName", "Safari");
            //set operating system to macOS version 10.13
            capabilities.SetCapability("platform", "macOS 10.13");
            //set the browser version to 11.1
            capabilities.SetCapability("version", "11.1");
            //set your test case name so that it shows up in Sauce Labs
            capabilities.SetCapability("name", TestContext.CurrentContext.Test.Name);
            //set your user name and access key to run tests in Sauce
            capabilities.SetCapability("username", sauceUserName);
            capabilities.SetCapability("accessKey", sauceAccessKey);

            //create a new Remote driver that will allow your test to send
            //commands to the Sauce Labs grid so that Sauce can execute your tests
            _driver = new RemoteWebDriver(new Uri("http://ondemand.saucelabs.com:80/wd/hub"),
                capabilities, TimeSpan.FromSeconds(600));
            //navigate to the url of the Sauce Labs Sample app
            _driver.Navigate().GoToUrl("https://dhaarfdu80ouz.cloudfront.net/index.html");

            //Create an instance of a Selenium explicit wait so that we can dynamically wait for an element
            var wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(5));
            //wait for the user name field to be visible and store that element into a variable
            var userNameField = wait.Until(ExpectedConditions.ElementIsVisible(By.CssSelector("[type='text']")));
            //type the user name string into the user name field
            userNameField.SendKeys("standard_user");
            //type the password into the password field
            _driver.FindElement(By.CssSelector("[type='password']")).SendKeys("secret_sauce");
            //hit Login button
            _driver.FindElement(By.CssSelector("[type='submit']")).Click();

            //Synchronize on the next page and make sure it loads
            var inventoryPageLocator =
                wait.Until(ExpectedConditions.ElementIsVisible(By.Id("inventory_container")));
            //Assert that the inventory page displayed appropriately
            Assert.IsTrue(inventoryPageLocator.Displayed);
        }

        /*
         *Below we are performing 2 critical actions. Quitting the driver and passing
         * the test result to Sauce Labs user interface.
         */
        [TearDown]
        public void CleanUpAfterEveryTestMethod()
        {
            var passed = TestContext.CurrentContext.Result.Outcome.Status == TestStatus.Passed;
            ((IJavaScriptExecutor)_driver).ExecuteScript("sauce:job-result=" + (passed ? "passed" : "failed"));
            _driver?.Quit();
        }
    }
}
