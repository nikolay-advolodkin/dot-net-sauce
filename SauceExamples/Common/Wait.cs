using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using ExpectedConditions = SeleniumExtras.WaitHelpers.ExpectedConditions;

namespace Common
{
    public class Wait
    {
        private IWebDriver _driver;
        private WebDriverWait _wait => new WebDriverWait(_driver, TimeSpan.FromSeconds(5));
        private readonly By _locator;

        public Wait(IWebDriver driver)
        {
            _driver = driver;
        }

        public IWebElement UntilIsVisible(By locator)
        {
            return _wait.Until(ExpectedConditions.ElementIsVisible(locator));
        }
        public IWebElement UntilIsVisibleByClass(string className)
        {
            return _wait.Until(ExpectedConditions.ElementIsVisible(By.ClassName(className)));
        }
        public Wait(IWebDriver driver, By locator)
        {
            _driver = driver;
            _locator = locator;
        }

        public bool IsVisible()
        {
            return _wait.Until(ExpectedConditions.ElementIsVisible(_locator)).Displayed;
        }
    }
}
