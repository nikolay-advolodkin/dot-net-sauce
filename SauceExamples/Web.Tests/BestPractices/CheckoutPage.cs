using OpenQA.Selenium;

namespace Web.Tests.BestPractices
{
    public class CheckoutPage
    {
        private IWebDriver _driver;

        public CheckoutPage(IWebDriver driver)
        {
            _driver = driver;
        }

        public bool IsCheckedOut => _driver.Url.Contains("checkout-complete.html");
        public CartElement Cart => new CartElement(_driver);

        public CheckoutPage Finish()
        {
            _driver.FindElement(By.ClassName("cart_checkout_link")).Click();
            return this;
        }

        public void GoTo()
        {
            _driver.Navigate().GoToUrl("https://www.saucedemo.com/checkout-step-two.html");
        }
    }
}