using Common;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium.Remote;

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
        public void ShouldReturnRemoteWebDriver()
        {
            var desiredCaps = sauce.GetDesiredCaps();
            desiredCaps.Should().BeOfType(typeof(DesiredCapabilities));
        }
    }
}
