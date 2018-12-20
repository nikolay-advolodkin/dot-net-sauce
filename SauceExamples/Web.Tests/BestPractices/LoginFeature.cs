using Common;
using FluentAssertions;
using NUnit.Framework;
using SeleniumNunit.BestPractices.CrossBrowserExamples;
using Web.Tests.Pages;


namespace Web.Tests.BestPractices
{
    [TestFixture]
    [TestFixtureSource(typeof(CrossBrowserData), "LatestConfigurations")]
    [Parallelizable]
    public class LoginFeature : BaseCrossBrowserTest
    {
        public LoginFeature(string browser, string version, string os) : 
            base(browser, version, os)
        {
        }

        [Test]
        public void LoginPageShouldLoad()
        {
            var loginPage = new SauceDemoLoginPage(Driver);
            loginPage.Open().IsLoaded.Should().BeTrue("the login page should load successfully.");
        }
        [Test]
        public void ShouldBeAbleToLoginWithValidUser()
        {
            var loginPage = new SauceDemoLoginPage(Driver);
            loginPage.Open().IsLoaded.Should().BeTrue("the login page should load successfully.");
            var productsPage = loginPage.Login("standard_user", "secret_sauce");
            productsPage.IsLoaded.Should().BeTrue("we successfully logged in and the home page should load.");
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
        [Test]
        public void ShouldNotBeAbleToLoginWithLockedOutUser()
        {
            var loginPage = new SauceDemoLoginPage(Driver);
            loginPage.Open().IsLoaded.Should().BeTrue("the login page should load successfully.");
            var productsPage = loginPage.Login("locked_out_user", "secret_sauce");
            productsPage.IsLoaded.Should().BeFalse("we used a locked out user who should not be able to login.");
        }
        [SetUp]
        public void RunBeforeEveryTest()
        {
            SauceReporter.SetBuildName("BestPracticesTests");
        }
    }
}
