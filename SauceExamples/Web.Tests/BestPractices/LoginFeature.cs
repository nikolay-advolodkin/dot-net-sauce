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
        private SauceDemoLoginPage _loginPage;

        public LoginFeature(string browser, string version, string os) : 
            base(browser, version, os)
        {
        }

        [Test]
        public void LoginPageShouldLoad()
        {
            _loginPage.Open().IsLoaded.Should().BeTrue("the login page should load successfully.");
        }
        [Test]
        public void ShouldBeAbleToLoginWithValidUser()
        {
            _loginPage.Open().IsLoaded.Should().BeTrue("the login page should load successfully.");
            var productsPage = _loginPage.Login("standard_user", "secret_sauce");
            productsPage.IsLoaded.Should().BeTrue("we successfully logged in and the home page should load.");
        }
        [Test]
        public void ShouldNotBeAbleToLoginWithLockedOutUser()
        {
            _loginPage.Open().IsLoaded.Should().BeTrue("the login page should load successfully.");
            var productsPage = _loginPage.Login("locked_out_user", "secret_sauce");
            productsPage.IsLoaded.Should().BeFalse("we used a locked out user who should not be able to login.");
        }
        public void ShouldBeAbleToLoginWithProblemUser()
        {
            _loginPage.Open().IsLoaded.Should().BeTrue("the login page should load successfully.");
            var productsPage = _loginPage.Login("problem_user", "secret_sauce");
            productsPage.IsLoaded.Should().BeTrue("we successfully logged in and the home page should load.");
        }
        [SetUp]
        public void RunBeforeEveryTest()
        {
            SauceReporter.SetBuildName("BestPracticesTests");
            _loginPage = new SauceDemoLoginPage(Driver);

        }
    }
}
