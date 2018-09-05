using Common;
using NUnit.Framework;
using NUnit.Framework.Interfaces;
using OpenQA.Selenium;

namespace SeleniumNunit.BestPractices
{
    [TestFixture()]
    [Category("Parallel selenium tests at the class level using best practices")]
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
            var passed = TestContext.CurrentContext.Result.Outcome.Status == TestStatus.Passed;
            ((IJavaScriptExecutor)Driver).ExecuteScript("sauce:job-result=" + (passed ? "passed" : "failed"));
            Driver?.Quit();
        }
        public IWebDriver Driver { get; set; }
    }
}
