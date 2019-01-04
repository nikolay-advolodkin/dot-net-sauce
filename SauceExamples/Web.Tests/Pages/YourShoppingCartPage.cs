using OpenQA.Selenium;
using Web.Tests.Elements;

namespace Web.Tests.Pages
{
    internal class YourShoppingCartPage : BasePage
    {
        public YourShoppingCartPage(IWebDriver driver) : base(driver)
        {
        }

        public CartElement Cart => new CartElement(_driver);

        internal CheckoutInformationPage Checkout()
        {
            Wait.UntilIsVisibleByClass("cart_checkout_link").Click();
            return new CheckoutInformationPage(_driver);
        }

        internal YourShoppingCartPage Open()
        {
            _driver.Navigate().GoToUrl($"{BaseUrl}/cart.html");
            return this;
        }
    }
}