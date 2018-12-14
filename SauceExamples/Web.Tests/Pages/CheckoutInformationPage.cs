using OpenQA.Selenium;

namespace Web.Tests.Pages
{
    internal class CheckoutInformationPage : BasePage
    {
        public CheckoutInformationPage(IWebDriver driver) : base(driver)
        {
        }

        public CheckoutOverviewPage FillOutPersonalInformation()
        {
            Wait.UntilIsVisible(By.CssSelector("input[data-test='firstName']")).SendKeys("firstName");
            _driver.FindElement(By.CssSelector("input[data-test='lastName']")).SendKeys("lastName");
            _driver.FindElement(By.CssSelector("input[data-test='postalCode']")).SendKeys("zip");
            _driver.FindElement(By.ClassName("cart_checkout_link")).Click();
            return new CheckoutOverviewPage(_driver);
        }
    }
}