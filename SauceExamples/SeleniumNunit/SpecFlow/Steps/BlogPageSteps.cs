using System;
using System.Threading;
using Common;
using FluentAssertions;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using TechTalk.SpecFlow;
using ExpectedConditions = SeleniumExtras.WaitHelpers.ExpectedConditions;

namespace SeleniumNunit.SpecFlow.Steps
{
    [Binding]
    public class BlogPageSteps
    {
        public IWebDriver Driver;
        [When(@"the user opens Ultimate QA blog page")]
        public void WhenTheUserOpensUltimateQABlogPage()
        {
            Driver = new WebDriverFactory().CreateSauceDriver("BlogTest");
            Driver.Navigate().GoToUrl("https://www.ultimateqa.com/blog");
            Thread.Sleep(20000);    //purely for demonstration purposes, this is a bad practice
        }
        
        [Then(@"the blog page loads successfully")]
        public void ThenTheBlogPageLoadsSuccessfully()
        {
            var wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(5));
            wait.Until(ExpectedConditions.ElementIsVisible(By.Id("main-content")))
                .Displayed.Should().BeTrue("The home page should load in less than 5 seconds.");
        }
    }
}
