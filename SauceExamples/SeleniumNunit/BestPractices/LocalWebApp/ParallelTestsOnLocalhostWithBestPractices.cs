using FluentAssertions;
using NUnit.Framework;

namespace SeleniumNunit.BestPractices.LocalWebApp
{
    [TestFixture]
    [Parallelizable]
    class ParallelTestsOnLocalhostWithBestPractices : BaseTest
    {
        [Test]
        public void AboutPageLoads()
        {
            new AboutPage(Driver).Open().IsLoaded.Should().BeTrue();
        }
    }
}
