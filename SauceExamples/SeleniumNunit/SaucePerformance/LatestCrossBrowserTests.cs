using Common.TestData;
using NUnit.Framework;
using OpenQA.Selenium;
using SeleniumNunit.BestPractices.CrossBrowserExamples;

namespace SeleniumNunit.SaucePerformance
{
    [Category("Cross browser performance tests")]
    [Category("withDebugging")]
    [TestFixtureSource(typeof(CrossBrowserData), nameof(CrossBrowserData.LatestConfigurations))]
    class LatestCrossBrowserTests : BaseCrossBrowserTest
    {
        public LatestCrossBrowserTests(string browser, string browserVersion, string osPlatform) :
            base(browser, browserVersion, osPlatform, true, "1-crossBrowser-tunnel")
        {
        }
        [Test]
        [Repeat(10)]
        public void SauceDemoOneFindElement()
        {
            CallFindElement(1);
        }

        private void CallFindElement(int numberOfTimes)
        {
            for (int j = 0; j < numberOfTimes; j++)
            {
                Driver.Navigate().GoToUrl("https://www.saucedemo.com");
                Driver.FindElement(By.CssSelector("[type='text']"));
                Driver.Navigate().Refresh();
            }
        }
    }
}
