using System;
using System.Configuration;
using Common;
using NUnit.Framework;
using NUnit.Framework.Interfaces;
using OpenQA.Selenium;
using OpenQA.Selenium.Remote;
using RestSharp;
using RestSharp.Authenticators;
using TestContext = NUnit.Framework.TestContext;

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
            SauceConfig = new SauceLabsCapabilities {
                IsDebuggingEnabled = false,
                IsHeadless = bool.Parse(ConfigurationManager.AppSettings["sauceHeadless"])
            };
            SauceLabsCapabilities.BuildName = ConfigurationManager.AppSettings["buildName"];

            Driver = new WebDriverFactory(SauceConfig).
                CreateSauceDriver(_browser, _browserVersion, _osPlatform);
            SauceReporter = new SauceJavaScriptExecutor(Driver);
            SauceReporter.SetTestName(TestContext.CurrentContext.Test.Name);
            SauceReporter.SetBuildName(SauceLabsCapabilities.BuildName);
        }

        [TearDown]
        public void CleanUpAfterEveryTestMethod()
        {
            if (SauceConfig.IsUsingSauceLabs)
            {
                ExecuteSauceCleanupSteps();
            }
            Driver?.Quit();
        }

        private void ExecuteSauceCleanupSteps()
        {
            var isPassed = TestContext.CurrentContext.Result.Outcome.Status == TestStatus.Passed;
            SauceReporter.LogTestStatus(isPassed);
            //SetTestStatusUsingApi(isPassed);
            SauceReporter.LogMessage("Test finished execution");
            SauceReporter.LogMessage(TestContext.CurrentContext.Result.Message);
        }

        private void SetTestStatusUsingApi(bool isPassed)
        {
            string userName;
            string accessKey;
            //Todo cleanup later
            if (SauceConfig.IsHeadless)
            {
                userName = SauceUser.Headless.UserName;
                accessKey = SauceUser.Headless.AccessKey;
            }
            else
            {
                userName = SauceUser.Name;
                accessKey = SauceUser.AccessKey;
            }
            var sessionId = ((RemoteWebDriver) Driver).SessionId;
            var client = new RestClient()
            {
                Authenticator = new HttpBasicAuthenticator(userName, accessKey),
                BaseUrl = new Uri(new SauceLabsEndpoint().HeadlessRestApiUrl)
            };
            var request = new RestRequest($"/{userName}/jobs/{sessionId}",
                Method.PUT) {RequestFormat = DataFormat.Json};
            request.AddJsonBody(new { passed = isPassed });
            client.Execute(request);
        }

        private readonly string _browser;
        private readonly string _browserVersion;
        private readonly string _osPlatform;
        public SauceJavaScriptExecutor SauceReporter;
        private SauceLabsCapabilities SauceConfig { get; set; }

        public BaseTest(string browser, string browserVersion, string osPlatform)
        {
            _browser = browser;
            _browserVersion = browserVersion;
            _osPlatform = osPlatform;
        }

        public IWebDriver Driver { get; set; }
    }
}