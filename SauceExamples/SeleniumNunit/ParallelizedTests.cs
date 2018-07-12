using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common;
using FluentAssertions;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using ExpectedConditions = SeleniumExtras.WaitHelpers.ExpectedConditions;

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
