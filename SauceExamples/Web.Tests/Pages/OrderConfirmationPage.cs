using OpenQA.Selenium;

namespace Web.Tests.Pages
{
    public class OrderConfirmationPage : BasePage
    {
        public OrderConfirmationPage(IWebDriver driver) : base(driver)
        {
        }

        public bool IsCheckoutComplete =>
            Wait.UntilIsVisibleByClass("complete-header").Text == "THANK YOU FOR YOUR ORDER";
    }
}