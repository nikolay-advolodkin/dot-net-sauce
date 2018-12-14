using OpenQA.Selenium;

namespace Web.Tests.Pages
{
    public class OrderConfirmationPage : BasePage
    {
        public OrderConfirmationPage(IWebDriver driver) : base(driver)
        {
        }

        public bool IsCheckoutComplete =>
            Wait.UntilIsVisible(By.ClassName("subheader_label")).Text == "Checkout: Complete!";
    }
}