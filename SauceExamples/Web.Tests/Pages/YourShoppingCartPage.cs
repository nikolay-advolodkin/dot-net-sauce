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
        //TODO duplication. Can be turned into UntilIsVisibleByCss(string cssLocator);
        private By CheckoutButtonLocator => By.CssSelector("a[class='btn_action checkout_button']");


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