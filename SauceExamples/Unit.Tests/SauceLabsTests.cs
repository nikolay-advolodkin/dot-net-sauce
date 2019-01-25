using Common;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

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
    }
}
