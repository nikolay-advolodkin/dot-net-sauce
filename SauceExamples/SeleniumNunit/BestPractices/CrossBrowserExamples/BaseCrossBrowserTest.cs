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

        public BaseCrossBrowserTest(string browser, string browserVersion, string osPlatform)
        {
            _browser = browser;
            _browserVersion = browserVersion;
            _osPlatform = osPlatform;
        }
        [SetUp]
        public void ExecuteBeforeEveryTestMethod()
        {
            Driver = new WebDriverFactory().CreateSauceDriver(_browser, _browserVersion, _osPlatform);
            _sauceReporter = new SauceJavaScriptExecutor(Driver);
            _sauceReporter.SetTestName(TestContext.CurrentContext.Test.Name);
        }

        public IWebDriver Driver { get; set; }

        [TearDown]
        public void CleanUpAfterEveryTestMethod()
        {
            var isPassed = TestContext.CurrentContext.Result.Outcome.Status == TestStatus.Passed;
            _sauceReporter.LogTestStatus(isPassed);
            _sauceReporter.LogMessage(TestContext.CurrentContext.Result.Message);
            Driver?.Quit();
        }
    }
}
