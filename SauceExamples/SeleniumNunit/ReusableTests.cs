using System;
using System.Threading;
using Common;
using FluentAssertions;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using ExpectedConditions = SeleniumExtras.WaitHelpers.ExpectedConditions;

namespace SeleniumNunit
{
    public class ReusableTests
    {
        public IWebDriver Driver;

        public void OpenBlogPage()
        {
            Driver = new WebDriverFactory().CreateSauceDriver("BlogTest");
            Driver.Navigate().GoToUrl("https://www.ultimateqa.com/blog");
            Thread.Sleep(15000);
            var wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(5));
            wait.Until(ExpectedConditions.ElementIsVisible(By.Id("main-content")))
                .Displayed.Should().BeTrue("The home page should load in less than 5 seconds.");
            ((IJavaScriptExecutor)Driver).ExecuteScript($"sauce:job-result=passed");
        }
    }
}
