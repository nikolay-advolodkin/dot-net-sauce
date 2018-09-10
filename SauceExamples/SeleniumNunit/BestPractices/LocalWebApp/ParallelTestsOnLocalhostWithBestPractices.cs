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
            //Use a RESTSharp api call here to update some test data
            //Or you can inject some data into a DB
            //Or you can inject a cookie

            //this is the part that runs in sauce labs
            new AboutPage(Driver).Open().IsLoaded.Should().BeTrue();

            //clean up the test data here
        }
    }
    [TestFixture]
    [Parallelizable]
    class ParallelTestsOnLocalhostWithBestPractices2 : BaseTest
    {
        [Test]
        public void AboutPageLoads()
        {
            new AboutPage(Driver).Open().IsLoaded.Should().BeTrue();
        }
    }
    [TestFixture]
    [Parallelizable]
    class ParallelTestsOnLocalhostWithBestPractices3 : BaseTest
    {
        [Test]
        public void AboutPageLoads()
        {
            new AboutPage(Driver).Open().IsLoaded.Should().BeTrue();
        }
    }
}
