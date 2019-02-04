using Common;
using OpenQA.Selenium;

namespace SeleniumMsTest.ParallelTests.DataDriven
{
    public class BaseWebTest
    {
        public SauceJavaScriptExecutor SauceReporter { get; set; }

        public IWebDriver Driver { get; set; }


    }
}