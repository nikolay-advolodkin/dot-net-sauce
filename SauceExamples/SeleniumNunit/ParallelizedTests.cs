using NUnit.Framework;
using OpenQA.Selenium;

namespace SeleniumNunit
{
    [TestFixture]
    class ParallelizedTests
    {
        public IWebDriver Driver;
        [Test]
        [Parallelizable]
        public void Test()
        {
            new ReusableTests().OpenBlogPage();
        }
        [Test]
        [Parallelizable]
        public void Test2()
        {
            new ReusableTests().OpenBlogPage();
        }
        [Test]
        [Parallelizable]
        public void Test3()
        {
            new ReusableTests().OpenBlogPage();
        }
    }
    [TestFixture]
    class ParallelizedTests2
    {
        public IWebDriver Driver;
        [Test]
        public void Test()
        {
            new ReusableTests().OpenBlogPage();
        }
    }
    [TestFixture]
    class ParallelizedTests3
    {
        public IWebDriver Driver;
        [Test]
        public void Test()
        {
            new ReusableTests().OpenBlogPage();
        }
    }
    [TestFixture]
    class ParallelizedTests4
    {
        public IWebDriver Driver;
        [Test]
        public void Test()
        {
            new ReusableTests().OpenBlogPage();
        }
    }
}
