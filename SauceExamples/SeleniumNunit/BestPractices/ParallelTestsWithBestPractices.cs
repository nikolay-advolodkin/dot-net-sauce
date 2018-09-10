using FluentAssertions;
using NUnit.Framework;

namespace SeleniumNunit.BestPractices
{
    [TestFixture]
    [Parallelizable]
    [Category("Parallel selenium tests at the class level using best practices")]
    class ParallelTestsWithBestPractices : BaseTest
    {
        [Test]
        public void Test1()
        {
            new UltimateQAHomePage(Driver).Open().IsVisible.Should().BeTrue();
        }
    }
    [TestFixture]
    [Parallelizable]
    [Category("Parallel selenium tests at the class level using best practices")]
    class ParallelTestsWithBestPractices2 : BaseTest
    {
        [Test]
        public void Test2()
        {
            new UltimateQAHomePage(Driver).Open().IsVisible.Should().BeTrue();
        }
    }
    [TestFixture]
    [Parallelizable]
    [Category("Parallel selenium tests at the class level using best practices")]
    class ParallelTestsWithBestPractices3 : BaseTest
    {
        [Test]
        public void Test3()
        {
            new UltimateQAHomePage(Driver).Open().IsVisible.Should().BeTrue();
        }
    }
    [TestFixture]
    [Parallelizable]
    [Category("Parallel selenium tests at the class level using best practices")]
    class ParallelTestsWithBestPractices4 : BaseTest
    {
        [Test]
        public void Test4()
        {
            new UltimateQAHomePage(Driver).Open().IsVisible.Should().BeTrue();
        }
    }
}
