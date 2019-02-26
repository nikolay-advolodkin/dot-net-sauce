using System.Reflection;
using Common;
using OpenQA.Selenium;

namespace SeleniumNunit.SpecFlow.Pages
{
    public class SauceDemoLoginPage : BasePage
    {
        public SauceDemoLoginPage(IWebDriver driver) : base(driver)
        {
        }

        private readonly By _loginButtonLocator = By.ClassName("login-button");
        public bool IsLoaded => new Wait(_driver, _loginButtonLocator).IsVisible();


        public SauceDemoLoginPage Open()
        {
            _driver.Navigate().GoToUrl(BaseUrl);
            return this;
        }
    }
}