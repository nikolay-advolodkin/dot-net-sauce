using Common;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Unit.Tests
{
    [TestClass]
    [TestCategory("unit")]
    public class SauceLabsCapabilitiesTests
    {
        [TestMethod]
        public void ShouldWork()
        {
            Assert.IsTrue(true);
        }
        [TestMethod]
        public void ShouldNotBeNull()
        {
            var caps = new SauceLabsCapabilities();
            caps.Tags.Add("x");
            caps.Tags.Should().NotBeNull();
        }
        [TestMethod]
        public void ShouldContainNewTag()
        {
            var caps = new SauceLabsCapabilities();
            caps.Tags.Add("x");
            caps.Tags.Should().Contain("x");
        }
    }
}
