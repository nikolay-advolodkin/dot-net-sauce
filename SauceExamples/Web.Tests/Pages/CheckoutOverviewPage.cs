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
            Wait.UntilIsVisible(By.ClassName("cart_checkout_link")).Click();
            return new OrderConfirmationPage(_driver);
        }
    }
}