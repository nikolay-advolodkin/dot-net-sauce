using System;
using FluentAssertions;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumNunit.BestPractices.CrossBrowserExamples;

namespace SeleniumNunit.SaucePerformance
{
    //Use platform configurator - https://wiki.saucelabs.com/display/DOCS/Platform+Configurator#/
    [Category("Cross browser performance tests")]
    [Category("withDebugging")]
    [TestFixtureSource(typeof(CrossBrowserData), nameof(CrossBrowserData.LatestConfigurations))]
    public class ImplicitVsExplicitTests : BaseCrossBrowserTest
    {
        public ImplicitVsExplicitTests(string browser, string browserVersion, string osPlatform) :
            base(browser, browserVersion, osPlatform, true, "implicitWait2")
        {
        }
        [Test]
        public void ImplicitWait()
        {
            Driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            Driver.Navigate().GoToUrl("https://www.saucedemo.com");
            Driver.FindElement(By.CssSelector("[type='doent_exist']"));
        }
        [Test]
        public void ExplicitWait()
        {
            var wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(10));
            Driver.Navigate().GoToUrl("https://www.saucedemo.com");
            wait.Until(ExpectedConditions.ElementIsVisible(By.CssSelector("[type='doent_exist']")));
        }
    }
}
