using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace Common
{
    public class Wait
    {
        private IWebDriver _driver;
        private WebDriverWait _wait => new WebDriverWait(_driver, TimeSpan.FromSeconds(5));
        private By _locator;
        private IWebDriver _driver1;

        public Wait(IWebDriver driver1)
        {
            _driver1 = driver1;
        }

        public IWebElement UntilIsVisible(By locator)
        {
            return _wait.Until(ExpectedConditions.ElementIsVisible(locator));
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
