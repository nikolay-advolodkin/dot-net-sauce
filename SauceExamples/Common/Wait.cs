using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;


namespace Common
{
    public class Wait
    {
        private IWebDriver _driver;
        private WebDriverWait _wait;
        private By _locator;

        public Wait(IWebDriver driver, By locator)
        {
            _driver = driver;
            _wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(5));
            _locator = locator;
        }

        public bool IsVisible()
        {
            return _wait.Until(ExpectedConditions.ElementIsVisible(_locator)).Displayed;
        }
    }
}
