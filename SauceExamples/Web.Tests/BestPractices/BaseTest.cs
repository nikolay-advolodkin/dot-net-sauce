using Common;
using NUnit.Framework;
using NUnit.Framework.Interfaces;
using OpenQA.Selenium;

namespace Web.Tests.BestPractices
{
    //TODO this whole class is a duplication of BaseCrossBrowserTEst.cs
    //The reason why it was duplicated was because I needed to be able to configure
    //the [Setup] methods. Some needed to be able to set the Build Name and do some actions,
    //other tests didn't need to set the build name, and others, only needed to set
    //the build name. It seems as though maybe a Strategy pattern might solve these problems
    //It might make sense to create a ISetupStrategy that is defined in the constructor
    //of every single feature file. That feature file will define the setup Strategy.
    //Then, those operations will be performed int the [Setup] of the BaseTest
    [TestFixture]
    [Category("AcceptanceTests"), Category("CrossBrowser"), Category("NUnit"), Category("BestPractices") ]
    public class BaseTest
    {
        [SetUp]
        public void ExecuteBeforeEveryTestMethod()
        {
            var sauceConfig = new SauceLabsCapabilities {IsDebuggingEnabled = true};
            SauceLabsCapabilities.BuildName = _sauceBuildName;
            //TODO move into external config
            //TODO add a factory method to create this driver easily
 
            Driver = new WebDriverFactory(sauceConfig).CreateSauceDriver(_browser, _browserVersion, _osPlatform);
            SauceReporter = new SauceJavaScriptExecutor(Driver);
            SauceReporter.SetTestName(TestContext.CurrentContext.Test.Name);
            SauceReporter.SetBuildName("parallel-noSC");
            _isUsingSauceLabs = true;
        }

        [TearDown]
        public void CleanUpAfterEveryTestMethod()
        {
            if (_isUsingSauceLabs)
            {
                var isPassed = TestContext.CurrentContext.Result.Outcome.Status == TestStatus.Passed;
                SauceReporter.LogTestStatus(isPassed);
                SauceReporter.LogMessage("Test finished execution");
                SauceReporter.LogMessage(TestContext.CurrentContext.Result.Message);
            }
            Driver?.Quit();
        }

        private readonly string _browser;
        private readonly string _browserVersion;
        private readonly string _osPlatform;
        public SauceJavaScriptExecutor SauceReporter;
        private static string _sauceBuildName;
        private bool _isUsingSauceLabs;

        public BaseTest(string browser, string browserVersion, string osPlatform)
        {
            _browser = browser;
            _browserVersion = browserVersion;
            _osPlatform = osPlatform;
        }

        protected BaseTest(string browser, string browserVersion, string osPlatform, bool isDebuggingOn)
        {
            _browser = browser;
            _browserVersion = browserVersion;
            _osPlatform = osPlatform;
        }

        protected BaseTest(string browser, string browserVersion, string osPlatform, bool isDebuggingOn,
            string buildName)
        {
            _browser = browser;
            _browserVersion = browserVersion;
            _osPlatform = osPlatform;
            _sauceBuildName = buildName;
        }
        public IWebDriver Driver { get; set; }

    }
}