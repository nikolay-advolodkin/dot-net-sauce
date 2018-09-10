using System;
using Common;
using FluentAssertions;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace SeleniumNunit.BestPractices.CrossBrowserExamples
{

    //Use platform configurator - https://wiki.saucelabs.com/display/DOCS/Platform+Configurator#/
    [Parallelizable]
    [Category("Cross browser tests")]
    [TestFixture("Chrome", "latest", "Windows 10")]
    [TestFixture("Safari", "latest", "macOS 10.13")]
    [TestFixture("MicrosoftEdge", "latest", "Windows 10")]
    [TestFixture("Firefox", "latest", "Windows 10")]
    class CrossBrowserTests : BaseCrossBrowserTest
    {
        public CrossBrowserTests(string browser, string browserVersion, string osPlatform) :
            base(browser, browserVersion, osPlatform)
        {
        }
        [Test]
        public void SaucePageOpens()
        {

            new SauceLabsPage(Driver).Open().IsVisible.Should().BeTrue();
        }
    }

    internal class SauceLabsPage
    {
        private readonly IWebDriver _driver;

        public SauceLabsPage(IWebDriver driver)
        {
            _driver = driver;
        }

        public bool IsVisible
        {
            get
            {
                var wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(10));
                return wait.Until(ExpectedConditions.ElementIsVisible(By.Id("site-header"))).Displayed;
            }
        }

        public SauceLabsPage Open()
        {
            _driver.Navigate().GoToUrl("https://www.saucelabs.com");
            return this;
        }
    }
}
