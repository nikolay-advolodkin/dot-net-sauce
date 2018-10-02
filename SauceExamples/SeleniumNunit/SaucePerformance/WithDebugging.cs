using FluentAssertions;
using NUnit.Framework;
using SeleniumNunit.BestPractices.CrossBrowserExamples;

namespace SeleniumNunit.SaucePerformance
{
    //Use platform configurator - https://wiki.saucelabs.com/display/DOCS/Platform+Configurator#/
    //[Parallelizable]
    [Category("Cross browser tests")]
    [TestFixture("Chrome", "latest", "Windows 10")]
    [TestFixture("Safari", "latest", "macOS 10.13")]
    [TestFixture("MicrosoftEdge", "latest", "Windows 10")]
    [TestFixture("Firefox", "latest", "Windows 10")]
    [TestFixture("Chrome", "latest-1", "Windows 10")]
    [TestFixture("Safari", "latest-1", "macOS 10.12")]
    [TestFixture("MicrosoftEdge", "latest-1", "Windows 10")]
    [TestFixture("Firefox", "latest-1", "Windows 10")]
    [TestFixture("Chrome", "latest-2", "Windows 10")]
    [TestFixture("Safari", "10.0", "OS X 10.11")]
    [TestFixture("MicrosoftEdge", "latest-2", "Windows 10")]
    [TestFixture("Firefox", "latest-2", "Windows 10")]
    class WithDebugging : BaseCrossBrowserTest
    {
        public WithDebugging(string browser, string browserVersion, string osPlatform) :
            base(browser, browserVersion, osPlatform, true)
        {
        }
        [Test]
        public void SaucePageOpens()
        {
            new SauceLabsPage(Driver).Open().IsVisible.Should().BeTrue();
        }
    }
}
