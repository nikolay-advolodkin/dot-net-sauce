using OpenQA.Selenium;

namespace Web.Tests.BestPractices.Pages
{
    public class SwagLabsHomePage
    {
        private readonly IWebDriver _driver;

        public SwagLabsHomePage(IWebDriver driver)
        {
            _driver = driver;
         
        }

        public bool IsLoaded => _driver.Url.Contains("/inventory.html");

        public void Logout()
        {
            HamburgerElement.Click();
            LogoutLink.Click();
        }

        public IWebElement LogoutLink => _driver.FindElement(By.Id("logout_sidebar_link"));

        public IWebElement HamburgerElement => _driver.FindElement(By.ClassName("bm-burger-button"));
    }
}