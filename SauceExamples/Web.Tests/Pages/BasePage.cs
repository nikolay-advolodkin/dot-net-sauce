using Common;
using OpenQA.Selenium;

namespace Web.Tests.Pages
{
    public class BasePage
    {
        public readonly IWebDriver _driver;
        private readonly string _baseUrl;

        public SauceJavaScriptExecutor SauceJsExecutor => 
            new SauceJavaScriptExecutor(_driver);

        public Wait Wait => new Wait(_driver);
        public string BaseUrl => _baseUrl;

        public BasePage(IWebDriver driver)
        {
            this._driver = driver;
            _baseUrl = "https://www.saucedemo.com";
        }
    }
}