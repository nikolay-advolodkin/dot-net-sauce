using System;
using Common;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumNunit.BestPractices.CrossBrowserExamples;

namespace Sandbox
{
    [TestFixture]
    [TestFixtureSource(typeof(CrossBrowserData), "LatestConfigurations")]

    public class ExplicitWaitsTest
    {
        protected ExplicitWaitsTest(string browser, string browserVersion, string osPlatform)
        {
            _browser = browser;
            _browserVersion = browserVersion;
            _osPlatform = osPlatform;
        }
        private IWebDriver _driver;
        private string _browser;
        private string _browserVersion;
        private string _osPlatform;
        private bool _isDebuggingOn;
        public static string SlowAnimationUrl => "http://awful-valentine.com/purchase-forms/slow-animation/";

        [SetUp]
        public void Setup()
        {
            var sauceCaps = new SauceLabsCapabilities();
            SauceLabsCapabilities.BuildName = "explicitWait";
            _driver = new WebDriverFactory(sauceCaps).CreateSauceDriver(_browser, _browserVersion, _osPlatform);
        }
        [Test]
        public void UsingExplicitWaits()
        {
            _driver.Navigate().GoToUrl(SlowAnimationUrl);
            FillOutCreditCardInfo();
            var wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(15)) {PollingInterval = TimeSpan.FromSeconds(3)};
            wait.Until(ExpectedConditions.ElementToBeClickable(By.Id("go"))).Click();
            Assert.IsTrue(wait.Until(ExpectedConditions.ElementIsVisible(By.Id("success"))).Displayed);
        }
        private void FillOutCreditCardInfo()
        {
            _driver.FindElement(By.Id("name")).SendKeys("test name");
            _driver.FindElement(By.Id("cc")).SendKeys("1234123412341234");
            _driver.FindElement(By.Id("month")).SendKeys("01");
            _driver.FindElement(By.Id("year")).SendKeys("2020");
        }
    }
}
