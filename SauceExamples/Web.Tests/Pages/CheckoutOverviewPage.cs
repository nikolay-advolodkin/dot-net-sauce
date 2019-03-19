using OpenQA.Selenium;
using Web.Tests.Elements;

namespace Web.Tests.Pages
{
    public class CheckoutOverviewPage : BasePage
    {
        public CheckoutOverviewPage(IWebDriver driver) : base(driver)
        {           
        }
        public CartElement Cart => new CartElement(_driver);

        public OrderConfirmationPage FinishCheckout()
        {
            Wait.UntilIsVisibleByCss("[class='btn_action cart_button']").Click();
            return new OrderConfirmationPage(_driver);
        }

        internal CheckoutOverviewPage Open()
        {
            //TODO duplication here with the URL. Also happening in YourShoppingCartPage
            _driver.Navigate().GoToUrl($"{BaseUrl}/checkout-step-two.html");
            return this;
        }
    }
}