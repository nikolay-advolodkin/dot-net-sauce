using Common.TestData;
using NUnit.Framework;
using OpenQA.Selenium;
using SeleniumNunit.BestPractices.CrossBrowserExamples;

namespace SeleniumNunit.SaucePerformance
{
    //Use platform configurator - https://wiki.saucelabs.com/display/DOCS/Platform+Configurator#/
    [Category("Cross browser performance tests")]
    [Category("withDebugging")]
    [TestFixtureSource(typeof(CrossBrowserData), nameof(CrossBrowserData.LatestChrome))]
    public class SingleBrowserTests : BaseCrossBrowserTest
    {
        public SingleBrowserTests(string browser, string browserVersion, string osPlatform) :
            base(browser, browserVersion, osPlatform, true, "1-chrome-tunnel")
        {
        }
        [Test]
        [Repeat(30)]
        public void SauceDemoOneFindElement()
        {
            CallFindElement(1);
        }
        [Test]
        [Repeat(10)]
        public void SauceDemo100FindElements()
        {
            CallFindElement(100);
        }
        [Test]
        [Repeat(10)]
        public void SauceDemo1000FindElements()
        {
            CallFindElement(1000);
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
