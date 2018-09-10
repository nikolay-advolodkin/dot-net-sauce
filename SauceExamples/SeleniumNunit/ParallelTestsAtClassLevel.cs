using NUnit.Framework;

namespace SeleniumNunit
{
    [TestFixture]
    [Parallelizable]
    [Category("Parallel selenium tests at the class level")]
    class ParallelTestsAtClassLevel
    {
        [Test]
        public void Test1()
        {
            new ReusableTests().OpenBlogPage();
        }
    }
    [TestFixture]
    [Parallelizable]
    [Category("Parallel selenium tests at the class level")]

    class ParallelizedTests2
    {
        [Test]
        public void Test2()
        {
            new ReusableTests().OpenBlogPage();
        }
    }
    [TestFixture]
    [Parallelizable]
    [Category("Parallel selenium tests at the class level")]
    class ParallelizedTests3
    {
        [Test]
        public void Test3()
        {
            new ReusableTests().OpenBlogPage();
        }
    }
    [TestFixture]
    [Parallelizable]
    [Category("Parallel selenium tests at the class level")]
    class ParallelizedTests4
    {
        [Test]
        public void Test4()
        {
            new ReusableTests().OpenBlogPage();
        }
    }
}
