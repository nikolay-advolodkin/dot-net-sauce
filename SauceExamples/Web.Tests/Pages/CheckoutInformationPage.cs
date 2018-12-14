using OpenQA.Selenium;

namespace Web.Tests.Pages
{
    internal class CheckoutInformationPage
    {
        private IWebDriver _driver;

        public CheckoutInformationPage(IWebDriver driver)
        {
            _driver = driver;
        }
    }
}