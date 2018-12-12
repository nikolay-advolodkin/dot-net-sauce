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
        private WebDriverWait _wait;
        public static string SlowAnimationUrl => "http://awful-valentine.com/purchase-forms/slow-animation/";

        [SetUp]
        public void Setup()
        {

            _sauceCaps = new SauceLabsCapabilities();
            SauceLabsCapabilities.BuildName = "actWaitAct";
            _sauceCaps.IsDebuggingEnabled = true;
            _driver = new WebDriverFactory(_sauceCaps).CreateSauceDriver(_browser, _browserVersion, _osPlatform);

            _sauceLogger = new SauceJavaScriptExecutor(_driver);

        }
        [TearDown]
        public void Teardown()
        {
            var isPassed = TestContext.CurrentContext.Result.Outcome.Status == TestStatus.Passed;
            _sauceLogger.LogTestStatus(isPassed, "Test finished execution");
            _driver?.Quit();
        }
        //[Test]
        //public void UsingExplicitWaits()
        //{
        //    _wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(15))
        //        { PollingInterval = TimeSpan.FromSeconds(3) };

        //    _driver.Navigate().GoToUrl(SlowAnimationUrl);
        //    FillOutCreditCardInfo();
        //    _wait.Until(ExpectedConditions.ElementToBeClickable(By.Id("go"))).Click();
        //    Assert.IsTrue(IsPurchaseComplete(_wait));
        //}
        [Test]
        public void UsingActWaitAct()
        {
            _wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(15))
                { PollingInterval = TimeSpan.FromSeconds(3) };

            _driver.Navigate().GoToUrl(SlowAnimationUrl);
            FillOutCreditCardInfo();
            _wait.Until(ExpectedConditions.ElementToBeClickable(By.Id("go"))).Click();
            Assert.IsTrue(IsPurchaseCompleteAct());
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

        private bool IsPurchaseCompleteAct()
        {
            _sauceLogger.LogMessage("Start of IsPurchaseComplete()");

            var isPurchaseMessageDisplayed = 
                ActWait(By.Id("success"), "Waiting for Purchase Complete message", true);

            var isInvisible = ActWait(By.Id("spinner"), "Waiting for spinner to dissapear", false);

            _sauceLogger.LogMessage("End of IsPurchaseComplete()");
            return isPurchaseMessageDisplayed && isInvisible;
        }

        private bool ActWait(By locator, string message, bool displayed)
        {
            _sauceLogger.LogMessage($"{message}.");
            bool isTrue;
            try
            {
                isTrue = _driver.FindElement(locator).Displayed;
            }
            catch (NoSuchElementException)
            {
                if (displayed)
                    isTrue = _wait.Until(ExpectedConditions.ElementIsVisible(By.Id("success"))).Displayed;
                else
                    isTrue = _wait.Until(ExpectedConditions.InvisibilityOfElementLocated(By.Id("spinner")));
            }
            _sauceLogger.LogMessage($"End of {message}.");
            return isTrue;
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
