using Common;
using FluentAssertions;
using NUnit.Framework;
using SeleniumNunit.BestPractices.CrossBrowserExamples;
using Web.Tests.Pages;


namespace Web.Tests.BestPractices
{
    [TestFixture]
    [TestFixtureSource(typeof(CrossBrowserData), "LatestConfigurations")]
    public class LoginFeature : BaseCrossBrowserTest
    {
        public LoginFeature(string browser, string version, string os) : 
            base(browser, version, os)
        {
        }

        [Test]
        public void LoginPageShouldLoad()
        {
            SauceReporter.SetBuildName("AntiPatternTests");
            var loginPage = new SauceDemoLoginPage(Driver);
            loginPage.Open().IsLoaded.Should().BeTrue("the login page should load successfully.");
        }
    }
}
