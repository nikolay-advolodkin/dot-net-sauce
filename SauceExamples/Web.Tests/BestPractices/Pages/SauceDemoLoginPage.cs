using System;
using Common;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace Web.Tests.Antipatterns
{
    public class SauceDemoLoginPage
    {
        private readonly IWebDriver _driver;

        public SauceDemoLoginPage(IWebDriver driver)
        {
            _driver = driver;
        }

        public bool IsLoaded => new Wait(_driver, By.ClassName("login-button")).IsVisible();

        public SauceDemoLoginPage Open()
        {
            _driver.Navigate().GoToUrl("https://www.saucedemo.com/");
            return this;
        }
    }
}