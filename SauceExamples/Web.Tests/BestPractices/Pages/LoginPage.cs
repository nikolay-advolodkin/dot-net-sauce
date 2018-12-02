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
    }
}