using Common;
using NUnit.Framework;
using NUnit.Framework.Interfaces;
using OpenQA.Selenium;
using saucelabs.saucerest;

namespace SeleniumNunit.BestPractices
{
    [TestFixture()]
    public class BaseTest
    {
        [SetUp]
        public void ExecuteBeforeEveryTestMethod()
        {
            Driver = new WebDriverFactory().CreateSauceDriver(TestContext.CurrentContext.Test.Name);
        }
        [TearDown]
        public void CleanUpAfterEveryTestMethod()
        {
            LogTestStatusWithJavascript();
            //LogTestStatusWithApi();
            Driver?.Quit();
        }

        private void LogTestStatusWithApi()
        {
            new SauceREST(SauceUser.Name, SauceUser.AccessKey);
        }

        private void LogTestStatusWithJavascript()
        {
            var passed = TestContext.CurrentContext.Result.Outcome.Status == TestStatus.Passed;
            ((IJavaScriptExecutor)Driver).
                ExecuteScript("sauce:job-result=" + (passed ? "passed" : "failed"));
        }

        public IWebDriver Driver { get; set; }
    }
}
