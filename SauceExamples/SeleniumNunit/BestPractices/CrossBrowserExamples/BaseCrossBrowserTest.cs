using System;
using System.Globalization;
using Common;
using NUnit.Framework;
using NUnit.Framework.Interfaces;
using OpenQA.Selenium;

namespace SeleniumNunit.BestPractices.CrossBrowserExamples
{
    [TestFixture]
    public class BaseCrossBrowserTest
    {
        private string _browser;
        private string _browserVersion;
        private string _osPlatform;
        private SauceJavaScriptExecutor _sauceReporter;
        private bool _isDebuggingOn;
        private static string _sauceBuildName;

        public BaseCrossBrowserTest(string browser, string browserVersion, string osPlatform)
        {
            _browser = browser;
            _browserVersion = browserVersion;
            _osPlatform = osPlatform;
        }

        protected BaseCrossBrowserTest(string browser, string browserVersion, string osPlatform, bool isDebuggingOn)
        {
            _browser = browser;
            _browserVersion = browserVersion;
            _osPlatform = osPlatform;
            _isDebuggingOn = isDebuggingOn;
        }
        [OneTimeSetUp]
        public void ExecuteBeforeTestClass()
        {
            _sauceBuildName = $"CrossBrowserTests-{DateTime.Now.ToString(CultureInfo.InvariantCulture)}";
        }
        [SetUp]
        public void ExecuteBeforeEveryTestMethod()
        {
            Driver = new WebDriverFactory().CreateSauceDriver(_browser, _browserVersion, _osPlatform, _isDebuggingOn);
            _sauceReporter = new SauceJavaScriptExecutor(Driver);
            _sauceReporter.SetTestName(TestContext.CurrentContext.Test.Name);
        }

        public IWebDriver Driver { get; set; }

        [TearDown]
        public void CleanUpAfterEveryTestMethod()
        {
            var isPassed = TestContext.CurrentContext.Result.Outcome.Status == TestStatus.Passed;
            _sauceReporter.LogTestStatus(isPassed);
            _sauceReporter.LogMessage("Test finished execution");
            _sauceReporter.LogMessage(TestContext.CurrentContext.Result.Message);
            Driver?.Quit();
        }
    }
}
