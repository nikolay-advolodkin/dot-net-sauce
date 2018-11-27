using System.Reflection;
using Common;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using Web.Tests.BestPractices.Pages;


namespace Web.Tests.Antipatterns
{
    [TestClass]
    public class PoorTests
    {
        private IWebDriver _driver;
        public TestContext TestContext { get; set; }

        [TestMethod]
        public void EndToEndTest()
        {
            _driver = new WebDriverFactory().CreateSauceDriver(MethodBase.GetCurrentMethod().Name);
            var loginPage = new SauceDemoLoginPage(_driver);
            //test loading of login page
            loginPage.Open().IsLoaded.Should().BeTrue("the login page should load successfully.");
            loginPage.UsernameField.Displayed.Should().BeTrue("the page is loaded, so the username field should exist");
            loginPage.PasswordField.Displayed.Should().BeTrue("the page is loaded, so the password field should exist");
           
            //test login with valid user
            var homePage = loginPage.Login("standard_user", "secret_sauce");
            homePage.IsLoaded.Should().BeTrue("we successfully logged in and the home page should load.");
            homePage.Logout();
            loginPage.IsLoaded.Should().BeTrue("we successfully logged out, so the login page should be visible");
            
            //test login with Locked Out user
            homePage = loginPage.Login("locked_out_user", "secret_sauce");
            homePage.IsLoaded.Should().BeFalse("we used a locked out user who should not be able to login.");

            //test login with Problem user
            homePage = loginPage.Login("problem_user", "secret_sauce");
            homePage.IsLoaded.Should().BeTrue("we successfully logged in and the home page should load.");
            homePage.Logout();

            //test login with invalid username
            homePage = loginPage.Login("fake_user_name", "secret_sauce");
            homePage.IsLoaded.Should().BeFalse("we used a locked out user who should not be able to login.");

            //test login with invalid password
            homePage = loginPage.Login("standard_user", "fake_pass");
            homePage.IsLoaded.Should().BeFalse("we used a locked out user who should not be able to login.");
            
            //Add items to cart
            //homePage = loginPage.Login("standard_user", "secret_sauce");
            //homePage.IsLoaded.Should().BeTrue("we successfully logged in and the home page should load.");

        }

        [TestCleanup]
        public void CleanUpAfterEveryTestMethod()
        {
            var passed = TestContext.CurrentTestOutcome == UnitTestOutcome.Passed;
            new SauceJavaScriptExecutor(_driver).LogTestStatus(passed, TestContext.CurrentTestOutcome.ToString());
            _driver?.Quit();
        }
    }
}
