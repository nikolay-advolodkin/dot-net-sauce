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
        [Test]
        public void ShouldBeAbleToLoginWithProblemUser()
        {
            _loginPage.Open().IsLoaded.Should().BeTrue("the login page should load successfully.");
            var productsPage = _loginPage.Login("problem_user", "secret_sauce");
            productsPage.IsLoaded.Should().BeTrue("we successfully logged in and the home page should load.");
        }
        [Test]
        public void ShouldNotLoginWithInvalidUserName()
        {
            _loginPage.Open().IsLoaded.Should().BeTrue("the login page should load successfully.");
            var productsPage = _loginPage.Login("FAKE_USER_NAME", "secret_sauce");
            productsPage.IsLoaded.Should().BeFalse("we used a invalid username who should not be able to login.");
        }
        [Test]
        public void ShouldNotLoginWithInvalidPassword()
        {
            _loginPage.Open().IsLoaded.Should().BeTrue("the login page should load successfully.");
            var productsPage = _loginPage.Login("problem_user", "FAKE_PASSWORD");
            productsPage.IsLoaded.Should().BeFalse("we used an invalid password, so the user should not be able to login");
        }

        ////test login with invalid password
        //productsPage = loginPage.Login("standard_user", "fake_pass");
        //    productsPage.IsLoaded.Should().BeFalse("we used an invalid password, so the user should not be able to login");

        ////validate that all products are present
        //productsPage = loginPage.Login("standard_user", "secret_sauce");
        //    productsPage.IsLoaded.Should().BeTrue("we successfully logged in and the home page should load.");
        //productsPage.ProductCount.Should().Be(6,
        //        "we logged in successfully and we should have 6 items on the page");

        ////validate that a product can be added to a cart
        //productsPage.AddToCart(Item.Backpack);
        //    productsPage.Cart.ItemCount.Should().Be(1, "we added a backpack to the cart");

        ////validate that user can checkout
        //var cartPage = productsPage.Cart.Click();
        //var checkoutOverviewPage = cartPage.Checkout().
        //    FillOutPersonalInformation();
        //checkoutOverviewPage.FinishCheckout().IsCheckoutComplete.
        //    Should().
        //        BeTrue("we finished the checkout process");
        [SetUp]
        public void RunBeforeEveryTest()
        {
            SauceReporter.SetBuildName("BestPracticesTests");
            _loginPage = new SauceDemoLoginPage(Driver);
        }
    }
}
