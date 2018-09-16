using System;
using System.Threading;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace SeleniumNunit.BestPractices.LocalWebApp
{
    internal class AboutPage
    {
        private readonly IWebDriver _driver;

        public AboutPage(IWebDriver driver)
        {
            _driver = driver;
        }

        public bool IsLoaded
        {
            get
            {
                //using Thread.Sleep is a bad practice and here it is only done for demonstration purposes
                Thread.Sleep(10000);
                var wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(5));
                return wait.Until(ExpectedConditions.ElementIsVisible(By.TagName("h2"))).Displayed;
            }
        }

        public AboutPage Open()
        {
            _driver.Navigate().GoToUrl("http://localhost:8080/about");
            return this;
        }
    }
}
