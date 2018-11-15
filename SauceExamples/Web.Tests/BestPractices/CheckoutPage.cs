using OpenQA.Selenium;

namespace Web.Tests.BestPractices
{
    public class CheckoutPage
    {
        private IWebDriver _driver;

        public string CartItemCounterText
        {
            get
            {
                try
                {
                    return _driver.FindElement(By.XPath("//*[@class='fa-layers-counter shopping_cart_badge']")).Text;
                }
                catch (NoSuchElementException)
                {
                    return "0";
                }
            }
        }

        public CheckoutPage(IWebDriver driver)
        {
            _driver = driver;
        }

        public bool HasItems => int.Parse(CartItemCounterText) > 0;

        public bool IsSuccessful => _driver.Url.Contains("checkout-complete.html");

        public CheckoutPage Finish()
        {
            _driver.FindElement(By.ClassName("cart_checkout_link")).Click();
            return this;
        }

        public void GoTo()
        {
            _driver.Navigate().GoToUrl("https://www.saucedemo.com/checkout-step-two.html");
        }

        public CheckoutPage SetCartState()
        {
            ((IJavaScriptExecutor)_driver).ExecuteScript("window.sessionStorage.setItem('session-username', 'standard-user')");
            ((IJavaScriptExecutor)_driver).ExecuteScript("window.sessionStorage.setItem('cart-contents', '[4,1]')");
            return this;
        }
    }
}