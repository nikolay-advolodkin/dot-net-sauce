using System;
using Common;
using NUnit.Framework;
using NUnit.Framework.Interfaces;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumNunit.BestPractices.CrossBrowserExamples;

namespace Sandbox
{
    [TestFixture]
    [TestFixtureSource(typeof(CrossBrowserData), "LatestConfigurations")]

    public class ExplicitWaitsTest
    {
        public ExplicitWaitsTest(string browser, string browserVersion, string osPlatform)
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
        private SauceJavaScriptExecutor _sauceLogger;
        private SauceLabsCapabilities _sauceCaps;
        public static string SlowAnimationUrl => "http://awful-valentine.com/purchase-forms/slow-animation/";

        [SetUp]
        public void Setup()
        {
            _sauceCaps = new SauceLabsCapabilities();
            SauceLabsCapabilities.BuildName = "explicitWait";
            _sauceCaps.IsDebuggingEnabled = true;
            _sauceLogger = new SauceJavaScriptExecutor(_driver);
        }
        [TearDown]
        public void Teardown()
        {
            var isPassed = TestContext.CurrentContext.Result.Outcome.Status == TestStatus.Passed;
            _sauceLogger.LogTestStatus(isPassed, "Test finished execution");
            _driver?.Quit();
        }
        [Test]
        public void UsingExplicitWaits()
        {
            _driver = new WebDriverFactory(_sauceCaps).CreateSauceDriver(_browser, _browserVersion, _osPlatform);
            var wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(15))
                { PollingInterval = TimeSpan.FromSeconds(3) };

            _driver.Navigate().GoToUrl(SlowAnimationUrl);
            FillOutCreditCardInfo();
            wait.Until(ExpectedConditions.ElementToBeClickable(By.Id("go"))).Click();
            Assert.IsTrue(IsPurchaseComplete(wait));
        }
        private bool IsPurchaseComplete(WebDriverWait wait)
        {
            _sauceLogger.LogMessage("Start of IsPurchaseComplete()");

            _sauceLogger.LogMessage("Waiting for Purchase Complete message");
            var isPurchaseMessageDisplayed =
                wait.Until(ExpectedConditions.ElementIsVisible(By.Id("success"))).Displayed;
            _sauceLogger.LogMessage("Purchase Complete message finished");

            _sauceLogger.LogMessage("Waiting for spinner to dissapear.");
            var isInvisible = wait.Until(ExpectedConditions.InvisibilityOfElementLocated(By.Id("spinner")));
            _sauceLogger.LogMessage("End of waiting for spinner to dissapear.");

            _sauceLogger.LogMessage("End of IsPurchaseComplete()");
            return isPurchaseMessageDisplayed && isInvisible;
        }
        [Test]
        public void UsingActWaitAct()
        {
            _driver = new WebDriverFactory(_sauceCaps).CreateSauceDriver(_browser, _browserVersion, _osPlatform);
            var wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(15))
                { PollingInterval = TimeSpan.FromSeconds(3) };

            _driver.Navigate().GoToUrl(SlowAnimationUrl);
            FillOutCreditCardInfo();
            wait.Until(ExpectedConditions.ElementToBeClickable(By.Id("go"))).Click();
            Assert.IsTrue(IsPurchaseCompleteAct(wait));
        }
        private bool IsPurchaseCompleteAct(WebDriverWait wait)
        {
            _sauceLogger.LogMessage("Start of IsPurchaseComplete()");

            _sauceLogger.LogMessage("Waiting for Purchase Complete message");
            var locator = By.Id("success");
            bool isPurchaseMessageDisplayed = false;
            try
            {
                isPurchaseMessageDisplayed = _driver.FindElement(locator).Displayed;
            }
            catch (NoSuchElementException)
            {
                isPurchaseMessageDisplayed =
                    wait.Until(ExpectedConditions.ElementIsVisible(locator)).Displayed;
            }
            _sauceLogger.LogMessage("Purchase Complete message finished");

            _sauceLogger.LogMessage("Waiting for spinner to dissapear.");
            bool isInvisible = false;
            try
            {
                isPurchaseMessageDisplayed = _driver.FindElement(locator).Displayed;
            }
            catch (NoSuchElementException)
            {
                isInvisible = wait.Until(ExpectedConditions.InvisibilityOfElementLocated(By.Id("spinner")));
            }             
            _sauceLogger.LogMessage("End of waiting for spinner to dissapear.");

            _sauceLogger.LogMessage("End of IsPurchaseComplete()");
            return isPurchaseMessageDisplayed && isInvisible;
        }
        private void FillOutCreditCardInfo()
        {
            _sauceLogger.LogMessage("Start credit card filling");
            _driver.FindElement(By.Id("name")).SendKeys("test name");
            _driver.FindElement(By.Id("cc")).SendKeys("1234123412341234");
            _driver.FindElement(By.Id("month")).SendKeys("01");
            _driver.FindElement(By.Id("year")).SendKeys("2020");
            _sauceLogger.LogMessage("End credit card filling");
        }
    }
}
