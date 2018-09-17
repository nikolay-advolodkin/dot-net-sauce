using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using ExpectedConditions = SeleniumExtras.WaitHelpers.ExpectedConditions;

namespace SeleniumNunit.BestPractices.CrossBrowserExamples
{
    public class SauceLabsPage
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
