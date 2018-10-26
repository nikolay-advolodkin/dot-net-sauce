using Common;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium.Remote;

namespace Unit.Tests
{
    [TestClass]
    [TestCategory("unit")]
    public class WebDriverFactoryTests
    {
        private string _testBrowser = "chrome";
        private string _testBrowserVersion = "latest";
        private string _testOS = "Windows 10";
        private string _testBuildName = "testBuildName";

        [TestMethod]
        public void ShouldReturnRemoteWebDriver()
        {
            var factory = new WebDriverFactory();
            var sauceCapabilities = new SauceLabsCapabilities();
            var driver = GetSauceDriver(factory, sauceCapabilities);
            driver.Should().NotBeNull();
        }

        private RemoteWebDriver GetSauceDriver(WebDriverFactory factory, SauceLabsCapabilities sauceCapabilities)
        {
            return factory.CreateSauceDriver(_testBrowser, _testBrowserVersion, _testOS, sauceCapabilities);
        }

        [TestMethod]
        public void ShouldReturnRemoteWebDriverWithBuildName()
        {
            var factory = new WebDriverFactory();
            var sauceCapabilities = new SauceLabsCapabilities();
            SauceLabsCapabilities.BuildName = _testBuildName;
            var driver = GetSauceDriver(factory, sauceCapabilities);
            driver.Capabilities.HasCapability("build").Should().BeTrue();
            driver.Capabilities.GetCapability("build").Should().BeEquivalentTo(_testBuildName);
        }

        [TestMethod]
        public void ShouldReturnRemoteWebDriverWithBrowserOsAndVersion()
        {

            var factory = new WebDriverFactory();
            var sauceCapabilities = new SauceLabsCapabilities();
            var driver = GetSauceDriver(factory, sauceCapabilities);
            driver.Capabilities.GetCapability(CapabilityType.BrowserName).
                Should().BeEquivalentTo(_testBrowser);
            driver.Capabilities.GetCapability(CapabilityType.BrowserVersion).
                Should().BeEquivalentTo(_testBrowserVersion);
            driver.Capabilities.GetCapability(CapabilityType.Platform).
                Should().BeEquivalentTo(_testOS);
        }
    }
}
