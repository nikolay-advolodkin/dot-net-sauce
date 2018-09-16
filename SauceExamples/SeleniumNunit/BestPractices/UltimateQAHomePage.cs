using System.Threading;
using OpenQA.Selenium;

namespace SeleniumNunit.BestPractices
{
    internal class UltimateQAHomePage
    {
        private readonly IWebDriver _driver;
        private IWebElement StartHereButton => 
            _driver.FindElement(By.LinkText("Start learning now"));

        public UltimateQAHomePage(IWebDriver driver)
        {
            _driver = driver;
        }

        public bool IsVisible
        {
            get
            {
                try
                {
                    return StartHereButton.Displayed;
                }
                catch (NoSuchElementException)
                {
                    return false;
                }
            }
        }

        internal UltimateQAHomePage Open()
        {
            _driver.Navigate().GoToUrl("https://www.ultimateqa.com");
            Thread.Sleep(30000);    //thread.sleep is a bad practice in test automation and this is only done for example purposes
            return this;
        }
    }
}