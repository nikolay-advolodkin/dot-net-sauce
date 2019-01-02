using OpenQA.Selenium;
using Web.Tests.Elements;

namespace Web.Tests.Pages
{
    public class ProductsPage : BasePage
    {
        private string _pageUrlPart;

        public ProductsPage(IWebDriver driver) : base(driver)
        {
            _pageUrlPart = "inventory.html";
        }

        public bool IsLoaded => _driver.Url.Contains($"/{_pageUrlPart}");

        public void Logout()
        {
            HamburgerElement.Click();
            LogoutLink.Click();
        }

        public IWebElement LogoutLink => _driver.FindElement(By.Id("logout_sidebar_link"));

        public IWebElement HamburgerElement => _driver.FindElement(By.ClassName("bm-burger-button"));
        public int ProductCount => 
            _driver.FindElements(By.ClassName("inventory_item")).Count;

        public CartElement Cart => new CartElement(_driver);

        internal ProductsPage Open()
        {
            _driver.Navigate().GoToUrl($"{BaseUrl}/{_pageUrlPart}");
            return this;
        }

        public void AddToCart(Item itemType)
        {
            Wait.UntilIsVisibleByClass("add-to-cart-button").Click();
        }
    }
}