using OpenQA.Selenium;

namespace Web.Tests.BestPractices.Pages
{
    public class LoginPage
    {
        private IWebDriver _driver;

        public LoginPage(IWebDriver driver)
        {
            _driver = driver;
        }

        public void SetCartState(TestUser standardUser)
        {
            ((IJavaScriptExecutor)_driver).ExecuteScript("window.sessionStorage.setItem('session-username', 'standard-user')");
            ((IJavaScriptExecutor)_driver).ExecuteScript("window.sessionStorage.setItem('cart-contents', '[4,1]')");
        }
    }
}