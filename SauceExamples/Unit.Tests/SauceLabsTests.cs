using System.Collections.ObjectModel;
using Common;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;

namespace Unit.Tests
{
    [TestClass]
    public class SauceLabsTests
    {
        private SauceLabs sauce;

        [TestInitialize]
        public void ExecuteBeforeEveryTest()
        {
            sauce = new SauceLabs();
        }
        [TestMethod]
        public void ShouldReturnSauceLabsObject()
        {
            var desiredCaps = sauce.GetDesiredCapabilities();
            desiredCaps.Should().BeOfType(typeof(SauceLabs));
        }
        [TestMethod]
        public void ShouldSetDesiredCaps()
        {
            var desiredCaps = sauce.GetDesiredCapabilities();
            desiredCaps.Should().NotBeNull();
        }
        [TestMethod]
        public void ShouldReturnSauseJsExecutor()
        {
            //TODO use the Mock when I have actual internet access
            var fakeDriver = new FakeDriver();
            sauce.JavaScriptApi(fakeDriver).Should().NotBeNull("it should return an object that we can use to interact with Sauce JS");
        }
    }

    public class FakeDriver : IWebDriver
    {
        public IWebElement FindElement(By @by)
        {
            throw new System.NotImplementedException();
        }

        public ReadOnlyCollection<IWebElement> FindElements(By @by)
        {
            throw new System.NotImplementedException();
        }

        public void Dispose()
        {
            throw new System.NotImplementedException();
        }

        public void Close()
        {
            throw new System.NotImplementedException();
        }

        public void Quit()
        {
            throw new System.NotImplementedException();
        }

        public IOptions Manage()
        {
            throw new System.NotImplementedException();
        }

        public INavigation Navigate()
        {
            throw new System.NotImplementedException();
        }

        public ITargetLocator SwitchTo()
        {
            throw new System.NotImplementedException();
        }

        public string Url { get; set; }
        public string Title { get; }
        public string PageSource { get; }
        public string CurrentWindowHandle { get; }
        public ReadOnlyCollection<string> WindowHandles { get; }
    }
}
