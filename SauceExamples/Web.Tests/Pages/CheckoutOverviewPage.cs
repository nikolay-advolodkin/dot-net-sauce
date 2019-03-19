using OpenQA.Selenium;

namespace Web.Tests.Pages
{
    public class CheckoutOverviewPage : BasePage
    {
        public CheckoutOverviewPage(IWebDriver driver) : base(driver)
        {
        }

        public OrderConfirmationPage FinishCheckout()
        {
            Wait.UntilIsVisibleByCss("[class='btn_action cart_button']").Click();
            return new OrderConfirmationPage(_driver);
        }
    }
}