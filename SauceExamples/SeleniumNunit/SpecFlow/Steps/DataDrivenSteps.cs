using System;
using System.Collections.Generic;
using System.Globalization;
using Common;
using FluentAssertions;
using OpenQA.Selenium.Remote;
using SeleniumNunit.SpecFlow.Pages;
using TechTalk.SpecFlow;


namespace SeleniumNunit.SpecFlow.Steps
{
    [Binding]
    public class DataDrivenSteps : BaseSteps
    {
        [Given(@"I have an OS (.*) with browser (.*) and browser version (.*) opened")]
        public void GivenIHaveAnOSWithBrowserAndBrowserVersionOpened(string os, string browser, string version)
        {
            var _desiredCapabilities = new DesiredCapabilities();
            _desiredCapabilities.SetCapability(CapabilityType.BrowserName, browser);
            _desiredCapabilities.SetCapability(CapabilityType.Version, version);
            _desiredCapabilities.SetCapability(CapabilityType.Platform, os);
            _desiredCapabilities.SetCapability("username", SauceUser.Name);
            _desiredCapabilities.SetCapability("accessKey", SauceUser.AccessKey);
            _desiredCapabilities.SetCapability("build", $"SauceExamples-{DateTime.Now.ToString(CultureInfo.InvariantCulture)}");
            var tags = new List<string> { "BDD", "Specflow" };
            _desiredCapabilities.SetCapability("tags", tags);
            Driver = new RemoteWebDriver(new Uri(new SauceLabsEndpoint().SauceHubUrl),
                _desiredCapabilities, TimeSpan.FromSeconds(600));
        }
        
        [When(@"I open the SauceDemo home page")]
        public void WhenIOpenTheSauceDemoHomePage()
        {
            HomePage = new SauceDemoLoginPage(Driver);
            HomePage.Open();
        }

        public SauceDemoLoginPage HomePage { get; set; }

        [Then(@"it loads successfully")]
        public void ThenItLoadsSuccessfully()
        {
            HomePage.Open().IsLoaded.Should().BeTrue("the page should load");
        }
    }
}
