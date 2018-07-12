using System;
using Common;
using FluentAssertions;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using TechTalk.SpecFlow;
using ExpectedConditions = SeleniumExtras.WaitHelpers.ExpectedConditions;

namespace SeleniumNunit.Steps
{
    [Binding]
    public class HomePageSteps
    {
        private IWebDriver Driver;
        [When(@"the user opens Ultimate QA home page")]
        public void WhenTheUserOpensUltimateQAHomePage()
        {
            Driver = new WebDriverFactory().CreateSauceDriver("SimpleBddTest");
            Driver.Navigate().GoToUrl("https://www.ultimateqa.com");
        }
        
        [Then(@"the home page loads successfully")]
        public void ThenTheHomePageLoadsSuccessfully()
        {
            var wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(5));
            wait.Until(ExpectedConditions.ElementIsVisible(By.Id("main-content")))
                .Displayed.Should().BeTrue("The home page should load in less than 5 seconds.");
        }
    }
}
