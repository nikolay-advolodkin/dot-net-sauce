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
        private By CheckoutButtonLocator => By.CssSelector("button[class='btn_primary btn_inventory']");


        internal CheckoutInformationPage Checkout()
        {
            Wait.UntilIsVisible(CheckoutButtonLocator).Click();
            return new CheckoutInformationPage(_driver);
        }

        internal YourShoppingCartPage Open()
        {
            _driver.Navigate().GoToUrl($"{BaseUrl}/cart.html");
            return this;
        }
    }
}