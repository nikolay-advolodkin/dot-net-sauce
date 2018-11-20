using OpenQA.Selenium;

namespace Web.Tests.BestPractices.Pages
{
    public class CheckoutCompletePage
    {
        private readonly IWebDriver _driver;
        public bool IsCheckedOut => _driver.Url.Contains("checkout-complete.html");


        public CheckoutCompletePage(IWebDriver driver)
        {
            _driver = driver;
        }
    }
}