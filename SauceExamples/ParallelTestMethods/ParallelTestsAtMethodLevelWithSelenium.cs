using System.Threading;
using Common;
using NUnit.Framework;
using NUnit.Framework.Interfaces;
using OpenQA.Selenium;


namespace ParallelTestMethods
{
    [TestFixture]
    [Category("Parallel Selenium tests")]
    public class ParallelTestsAtMethodLevelWithSelenium
    {
        [SetUp]
        public void Setup()
        {
            Driver = new WebDriverFactory().CreateSauceDriver(TestContext.CurrentContext.Test.Name);
        }
        [TearDown]
        public void TearDown()
        {
            var passed = TestContext.CurrentContext.Result.Outcome.Status == TestStatus.Passed;
            ((IJavaScriptExecutor)Driver).ExecuteScript("sauce:job-result=" + (passed ? "passed" : "failed"));
            Driver?.Quit();
        }
        public IWebDriver Driver { get; set; }

        //This will default to the number of processors that a laptop has and will run that many threads at the same time
        [Test]
        [Parallelizable]
        [Ignore("don't need")]
        public void SeleniumTest1()
        {
            PerformTestSteps();
        }

        private void PerformTestSteps()
        {
            Driver.Navigate().GoToUrl("https://www.google.com");
            Thread.Sleep(10000);
            Assert.Pass();
        }

        [Test]
        [Parallelizable]
        [Ignore("don't need")]
        public void SeleniumTest2()
        {
            PerformTestSteps();

        }
        [Test]
        [Parallelizable]
        [Ignore("don't need")]

        public void SeleniumTest3()
        {
            PerformTestSteps();

        }
        [Test]
        [Parallelizable]
        [Ignore("don't need")]

        public void SeleniumTest4()
        {
            PerformTestSteps();
        }
    }
}
