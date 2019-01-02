using FluentAssertions;
using NUnit.Framework;
using SeleniumNunit.BestPractices.CrossBrowserExamples;
using Web.Tests.Pages;


namespace Web.Tests.BestPractices
{
    [TestFixture]
    [TestFixtureSource(typeof(CrossBrowserData), "LatestConfigurations")]
    [Parallelizable]
    public class LogoutFeature : BaseTest
    {
        public LogoutFeature(string browser, string version, string os) : 
            base(browser, version, os)
        {
        }
        [Test]
        public void ShouldBeAbleToLogOut()
        {
            var loginPage = new SauceDemoLoginPage(Driver);
            loginPage.Open().IsLoaded.Should().BeTrue("the login page should load successfully.");
            var productsPage = loginPage.Login("standard_user", "secret_sauce");
            productsPage.IsLoaded.Should().BeTrue("we successfully logged in and the home page should load.");
            productsPage.Logout();
            loginPage.IsLoaded.Should().BeTrue("we successfully logged out, so the login page should be visible");
        }
    }
}
