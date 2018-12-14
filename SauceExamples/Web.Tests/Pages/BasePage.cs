using Common;
using OpenQA.Selenium;

namespace Web.Tests.Pages
{
    public class BasePage
    {
        public readonly IWebDriver _driver;

        public SauceJavaScriptExecutor SauceJsExecutor => 
            new SauceJavaScriptExecutor(_driver);

        public Wait Wait => new Wait(_driver);

        public BasePage(IWebDriver driver)
        {
            this._driver = driver;
        }
    }
}