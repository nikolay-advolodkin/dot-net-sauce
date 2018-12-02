using Common;
using OpenQA.Selenium;

namespace Web.Tests.BestPractices.Pages
{
    public class SauceDemoLoginPage
    {
        private readonly IWebDriver _driver;

        public SauceDemoLoginPage(IWebDriver driver)
        {
            _driver = driver;
        }

        private readonly By _loginButtonLocator = By.ClassName("login-button");
        public bool IsLoaded => new Wait(_driver, _loginButtonLocator).IsVisible();
        public IWebElement UsernameField => _driver.FindElement(By.ClassName("login-input"));
        public IWebElement PasswordField => _driver.FindElement(By.CssSelector("[type='password']"));
        public IWebElement LoginButton => _driver.FindElement(_loginButtonLocator);


        public SauceDemoLoginPage Open()
        {
            _driver.Navigate().GoToUrl("https://www.saucedemo.com/");
            return this;
        }

        public ProductsPage Login(string username, string password)
        {
            UsernameField.Clear();
            UsernameField.SendKeys(username);
            PasswordField.Clear();
            PasswordField.SendKeys(password);
            LoginButton.Click();
            return new ProductsPage(_driver);
        }
    }
}