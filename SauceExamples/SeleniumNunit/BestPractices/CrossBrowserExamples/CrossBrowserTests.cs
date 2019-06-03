using Common.TestData;
using FluentAssertions;
using NUnit.Framework;

namespace SeleniumNunit.BestPractices.CrossBrowserExamples
{
    [Category("TestFixtureTests")]
    [TestFixtureSource(typeof(CrossBrowserData), "LatestConfigurations")]
    class CrossBrowserTests : BaseCrossBrowserTest
    {
        public CrossBrowserTests(string browser, string browserVersion, string osPlatform) :
            base(browser, browserVersion, osPlatform)
        {
        }
        [Test]
        public void SaucePageOpens()
        {
            new SauceLabsPage(Driver).Open().IsVisible.Should().BeTrue();
        }
    }

    //[Parallelizable]
    [Category("CrossBrowser")]
    [Category("PBI123")]
    [Category("FeatureTest")]
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

    [TestFixture("Chrome", "latest", "macOS 10.13")]
    [TestFixture("Safari", "latest", "macOS 10.13")]
    [TestFixture("Firefox", "latest", "macOS 10.13")]
    [TestFixture("Chrome", "latest-1", "macOS 10.13")]
    [TestFixture("Safari", "latest-1", "macOS 10.12")]
    [TestFixture("Firefox", "latest-1", "macOS 10.13")]
    [TestFixture("Chrome", "latest-2", "macOS 10.13")]
    [TestFixture("Safari", "10.0", "OS X 10.11")]
    [TestFixture("Firefox", "latest-2", "macOS 10.13")]
    class CrossBrowserTests2 : BaseCrossBrowserTest
    {
        public CrossBrowserTests2(string browser, string browserVersion, string osPlatform) :
            base(browser, browserVersion, osPlatform)
        {
        }
        [Test]
        public void SaucePageOpens()
        {

            new SauceLabsPage(Driver).Open().IsVisible.Should().BeTrue();
        }
    }
    [Category("CrossBrowser")]
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

    [TestFixture("Chrome", "latest", "macOS 10.13")]
    [TestFixture("Safari", "latest", "macOS 10.13")]
    [TestFixture("Firefox", "latest", "macOS 10.13")]
    [TestFixture("Chrome", "latest-1", "macOS 10.13")]
    [TestFixture("Safari", "latest-1", "macOS 10.12")]
    [TestFixture("Firefox", "latest-1", "macOS 10.13")]
    [TestFixture("Chrome", "latest-2", "macOS 10.13")]
    [TestFixture("Safari", "10.0", "OS X 10.11")]
    [TestFixture("Firefox", "latest-2", "macOS 10.13")]
    class CrossBrowserTests3 : BaseCrossBrowserTest
    {
        public CrossBrowserTests3(string browser, string browserVersion, string osPlatform) :
            base(browser, browserVersion, osPlatform)
        {
        }
        [Test]
        public void SaucePageOpens()
        {
            new SauceLabsPage(Driver).Open().IsVisible.Should().BeTrue();
        }
    }
}
