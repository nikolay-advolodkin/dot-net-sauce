using Common;
using NUnit.Framework;
using NUnit.Framework.Interfaces;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

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
        private bool _isUsingSauceLabs;

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
        protected BaseCrossBrowserTest(string browser, string browserVersion, string osPlatform, bool isDebuggingOn, string buildName)
        {
            _browser = browser;
            _browserVersion = browserVersion;
            _osPlatform = osPlatform;
            _isDebuggingOn = isDebuggingOn;
            _sauceBuildName = buildName;
        }

        [SetUp]
        public void ExecuteBeforeEveryTestMethod()
        {
            var sauceConfig = new SauceLabsCapabilities {IsDebuggingEnabled = true};
            SauceLabsCapabilities.BuildName = _sauceBuildName;
            //TODO move into external config
            //TODO add a factory method to create this driver easily
            var localExecution = false;
            if (localExecution)
            {
                Driver = new ChromeDriver();
                _isUsingSauceLabs = false;
            }
            else
            {
                Driver = new WebDriverFactory(sauceConfig).CreateSauceDriver(_browser, _browserVersion, _osPlatform);
                _sauceReporter = new SauceJavaScriptExecutor(Driver);
                _sauceReporter.SetTestName(TestContext.CurrentContext.Test.Name);
                _isUsingSauceLabs = true;
            }
        }

        public IWebDriver Driver { get; set; }

        [TearDown]
        public void CleanUpAfterEveryTestMethod()
        {
            if (_isUsingSauceLabs)
            {
                var isPassed = TestContext.CurrentContext.Result.Outcome.Status == TestStatus.Passed;
                _sauceReporter.LogTestStatus(isPassed);
                _sauceReporter.LogMessage("Test finished execution");
                _sauceReporter.LogMessage(TestContext.CurrentContext.Result.Message);
            }
            Driver?.Quit();
        }
    }
}
