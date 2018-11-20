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

        public CartElement Cart => new CartElement(_driver);

        public CheckoutCompletePage Finish()
        {
            _driver.FindElement(By.ClassName("cart_checkout_link")).Click();
            return new CheckoutCompletePage(_driver);
        }

        public void GoTo()
        {
            _driver.Navigate().GoToUrl("https://www.saucedemo.com/checkout-step-two.html");
        }
    }
}