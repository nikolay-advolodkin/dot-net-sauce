using OpenQA.Selenium;

namespace Web.Tests.BestPractices
{
    public class CartElement
    {
        private readonly IWebDriver _driver;
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
        public bool HasItems => int.Parse(CartItemCounterText) > 0;


        public CartElement(IWebDriver driver)
        {
            _driver = driver;
        }

        public CartElement SetCartState()
        {
            ((IJavaScriptExecutor)_driver).ExecuteScript("window.sessionStorage.setItem('session-username', 'standard-user')");
            ((IJavaScriptExecutor)_driver).ExecuteScript("window.sessionStorage.setItem('cart-contents', '[4,1]')");
            _driver.Navigate().Refresh();
            return this;
        }
    }
}