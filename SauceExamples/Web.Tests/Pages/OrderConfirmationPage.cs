using OpenQA.Selenium;

namespace Web.Tests.Pages
{
    public class OrderConfirmationPage : BasePage
    {
        public OrderConfirmationPage(IWebDriver driver) : base(driver)
        {
        }

        public bool IsCheckoutComplete =>
            Wait.UntilIsVisibleByClass("subheader_label").Text == "Checkout: Complete!";
    }
}