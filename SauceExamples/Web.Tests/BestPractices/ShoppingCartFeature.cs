using System.Reflection;
using Common;
using FluentAssertions;
using NUnit.Framework;
using NUnit.Framework.Interfaces;
using OpenQA.Selenium;
using Web.Tests.Pages;

namespace Web.Tests.BestPractices.Tests
{
    [TestFixture]
    [Parallelizable]
    public class ShoppingCartFeature
    {
        private IWebDriver _driver;
        [Test]
        public void ShouldBeAbleToCheckOutWithItems()
        {
            _driver = new WebDriverFactory().CreateSauceDriver(MethodBase.GetCurrentMethod().Name);
            var checkoutPage = new CheckoutPage(_driver);
            checkoutPage.GoTo();
            checkoutPage.Cart.SetCartState()
                .HasItems.Should().BeTrue("The cart should have some items in it since they were injected.");
            var checkoutCompletePage = checkoutPage.Finish();
            checkoutCompletePage.IsCheckedOut.Should().BeTrue("The checkout process should redirect us to the success page.");
        }

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
        [TearDown]
        public void CleanUpAfterEveryTestMethod()
        {
            var passed = TestContext.CurrentContext.Result.Outcome.Status == TestStatus.Passed;
            ((IJavaScriptExecutor)_driver).ExecuteScript("sauce:job-result=" + (passed ? "passed" : "failed"));
            _driver?.Quit();
        }
    }
}
