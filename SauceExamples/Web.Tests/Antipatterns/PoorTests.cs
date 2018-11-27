using System.Reflection;
using Common;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NUnit.Framework;
using NUnit.Framework.Interfaces;
using OpenQA.Selenium;
using Web.Tests.BestPractices.Pages;
using TestContext = NUnit.Framework.TestContext;

namespace Web.Tests.Antipatterns
{
    [TestClass]
    public class PoorTests
    {
        private IWebDriver _driver;
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

            //Add items to cart
            homePage = loginPage.Login("standard_user", "secret_sauce");
            homePage.IsLoaded.Should().BeTrue("we successfully logged in and the home page should load.");
            //var checkoutPage = new CheckoutPage(_driver);
            //checkoutPage.GoTo();
            //checkoutPage.Cart.SetCartState()
            //    .HasItems.Should().BeTrue("The cart should have some items in it since they were injected.");
            //var checkoutCompletePage = checkoutPage.Finish();
            //checkoutCompletePage.IsCheckedOut.Should().BeTrue("The checkout process should redirect us to the success page.");
        }

        [TestCleanup]
        public void CleanUpAfterEveryTestMethod()
        {
            var passed = TestContext.CurrentContext.Result.Outcome.Status == TestStatus.Passed;
            ((IJavaScriptExecutor)_driver).ExecuteScript("sauce:job-result=" + (passed ? "passed" : "failed"));
            _driver?.Quit();
        }
    }
}
