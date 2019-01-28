using System;
using System.Reflection;
using Common;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Remote;
using OpenQA.Selenium.Support.UI;

namespace SeleniumMsTest.ParallelTests
{
    [TestClass]
    [TestCategory("Selenium")]
    public class DataDrivenCrossBrowserParallelMethods
    {
        /*
         * How to execute parallel tests at the method level using MsTest
         *
         * Make sure that your AssemplyInfo.cs for the project has this property:
         * [assembly: Parallelize(Workers = 100, Scope = ExecutionScope.MethodLevel)]
         *
         * There are recommendations on the web to configure the .runsettings file,
         * but you do not need it to run in parallel.
         *
         * In this example, we can run many Selenium test methods in parallel without any issue
         */
        private IWebDriver _driver;

        public TestContext TestContext { get; set; }
        [TestInitialize]
        public void ExecuteBeforeEveryTestMethod()
        {
            //initialize driver
        }
        [TestMethod]
        [DynamicData("LatestConfigurations", typeof(MsTestCrossBrowserData),
            DynamicDataDisplayName = "GetCustomDynamicDataDisplayName", 
            DynamicDataDisplayNameDeclaringType = typeof(MsTestCrossBrowserData))]
        public void SeleniumTest1(string browser, string version, string osVersion)
        {
            SimpleTest(MethodBase.GetCurrentMethod().Name);
        }
        [TestCleanup]
        public void CleanUpAfterEveryTestMethod()
        {
            var passed = TestContext.CurrentTestOutcome == UnitTestOutcome.Passed;
            ((IJavaScriptExecutor)_driver).ExecuteScript("sauce:job-result=" + (passed ? "passed" : "failed"));
            _driver?.Quit();
        }

        public void SimpleTest(string testName)
        {
            var sauceUserName = SauceUser.Name;
            var sauceAccessKey = SauceUser.AccessKey;

            /*
             * In this section, we will configure our test to run on some specific
             * browser/os combination in Sauce Labs
             */
            var capabilities = new DesiredCapabilities();
            //set your user name and access key to run tests in Sauce
            capabilities.SetCapability("username", sauceUserName);
            //set your sauce labs access key
            capabilities.SetCapability("accessKey", sauceAccessKey);
            //set browser to Safari
            capabilities.SetCapability("browserName", "Safari");
            //set operating system to macOS version 10.13
            capabilities.SetCapability("platform", "macOS 10.13");
            //set the browser version to 11.1
            capabilities.SetCapability("version", "11.1");
            //set your test case name so that it shows up in Sauce Labs
            capabilities.SetCapability("name", testName);

            //create a new Remote driver that will allow your test to send
            //commands to the Sauce Labs grid so that Sauce can execute your tests
            _driver = new RemoteWebDriver(new Uri("http://ondemand.saucelabs.com:80/wd/hub"),
                capabilities, TimeSpan.FromSeconds(600));
            //navigate to the url of the Sauce Labs Sample app
            _driver.Navigate().GoToUrl("https://www.saucedemo.com");

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

    }
}
