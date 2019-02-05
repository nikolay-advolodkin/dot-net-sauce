using System;
using System.Reflection;
using Common;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace SeleniumMsTest.ParallelTests.DataDriven
{
    [TestClass]
    [TestCategory("Selenium")]
    public class DataDrivenCrossBrowserParallelMethods : BaseWebTest
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

        public TestContext TestContext { get; set; }
        [TestInitialize]
        public void ExecuteBeforeEveryTestMethod()
        {
            //cannot initialize here as MSTest doesn't support DynamicData at the Class level
            //therefore, we have to initialize the driver in the method as we need to retrieve the
            //os/browser combinations from the method

            /*
             * The other disadvantage is that you will only see a single test in the Test Explorer
             * but that test will have multiple iterations: https://screencast.com/t/VLFJxomp3R1i
             */
        }
        [TestMethod]
        [DynamicData(nameof(MsTestCrossBrowserData.LatestConfigurations), typeof(MsTestCrossBrowserData))]
        public void SeleniumTest1(string browser, string version, string osVersion)
        {
            SetupTest(browser, version, osVersion);
            SimpleTest(MethodBase.GetCurrentMethod().Name);
        }
        [TestMethod]
        [DynamicData(nameof(MsTestCrossBrowserData.LatestConfigurations), typeof(MsTestCrossBrowserData))]
        public void SeleniumTest2(string browser, string version, string osVersion)
        {
            SetupTest(browser, version, osVersion);
            SimpleTest(MethodBase.GetCurrentMethod().Name);
        }
        private void SetupTest(string browser, string version, string osVersion)
        {
            var sauceConfig = new SauceLabsCapabilities {IsDebuggingEnabled = true};
            Driver = new WebDriverFactory(sauceConfig).CreateSauceDriver(browser, version, osVersion);
            SauceReporter = new SauceJavaScriptExecutor(Driver);
            SauceReporter.SetTestName(TestContext.TestName);
        }

        [TestCleanup]
        public void CleanUpAfterEveryTestMethod()
        {
            var passed = TestContext.CurrentTestOutcome == UnitTestOutcome.Passed;
            ((IJavaScriptExecutor)Driver).ExecuteScript("sauce:job-result=" + (passed ? "passed" : "failed"));
            Driver?.Quit();
        }


        public void SimpleTest(string testName)
        {
            //navigate to the url of the Sauce Labs Sample app
            Driver.Navigate().GoToUrl("https://www.saucedemo.com");

            //Create an instance of a Selenium explicit wait so that we can dynamically wait for an element
            var wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(5));
            //wait for the user name field to be visible and store that element into a variable
            var userNameField = wait.Until(ExpectedConditions.ElementIsVisible(By.CssSelector("[type='text']")));
            //type the user name string into the user name field
            userNameField.SendKeys("standard_user");
            //type the password into the password field
            Driver.FindElement(By.CssSelector("[type='password']")).SendKeys("secret_sauce");
            //hit Login button
            Driver.FindElement(By.CssSelector("[type='submit']")).Click();

            //Synchronize on the next page and make sure it loads
            var inventoryPageLocator =
                wait.Until(ExpectedConditions.ElementIsVisible(By.Id("inventory_container")));
            //Assert that the inventory page displayed appropriately
            Assert.IsTrue(inventoryPageLocator.Displayed);
        }

    }
}
