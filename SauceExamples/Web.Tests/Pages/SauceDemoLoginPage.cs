using System.Reflection;
using Common;
using OpenQA.Selenium;

namespace Web.Tests.Pages
{
    public class SauceDemoLoginPage : BasePage
    {
        public SauceDemoLoginPage(IWebDriver driver) : base(driver)
        {
        }

        private readonly By _loginButtonLocator = By.ClassName("btn_action");
        public bool IsLoaded => new Wait(_driver, _loginButtonLocator).IsVisible();
        public IWebElement UsernameField => _driver.FindElement(By.Id("user-name"));
        public IWebElement PasswordField => _driver.FindElement(By.Id("password"));
        public IWebElement LoginButton => _driver.FindElement(_loginButtonLocator);


        public SauceDemoLoginPage Open()
        {
            _driver.Navigate().GoToUrl(BaseUrl);
            return this;
        }

        public ProductsPage Login(string username, string password)
        {
            SauceJsExecutor.LogMessage(
                $"Start login with user=>{username} and pass=>{password}");
            UsernameField.Clear();
            UsernameField.SendKeys(username);
            PasswordField.Clear();
            PasswordField.SendKeys(password);
            LoginButton.Click();
            SauceJsExecutor.LogMessage($"{MethodBase.GetCurrentMethod().Name} success");
            return new ProductsPage(_driver);
        }
    }
}