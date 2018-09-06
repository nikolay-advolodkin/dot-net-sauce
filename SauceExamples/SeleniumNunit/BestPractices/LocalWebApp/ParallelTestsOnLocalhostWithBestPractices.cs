using System;
using System.Threading;
using FluentAssertions;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

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

    internal class AboutPage
    {
        private readonly IWebDriver _driver;

        public AboutPage(IWebDriver driver)
        {
            _driver = driver;
        }

        public bool IsLoaded
        {
            get
            {
                //using Thread.Sleep is a bad practice and here it is only done for demonstration purposes
                Thread.Sleep(10000);
                var wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(5));
                return wait.Until(ExpectedConditions.ElementIsVisible(By.TagName("h2"))).Displayed;
            }
        }

        public AboutPage Open()
        {
            _driver.Navigate().GoToUrl("https://localhost:44304/about");
            return this;
        }
    }

    [TestFixture]
    [Parallelizable]
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
    class ParallelTestsWithBestPractices4 : BaseTest
    {
        [Test]
        public void Test4()
        {
            new UltimateQAHomePage(Driver).Open().IsVisible.Should().BeTrue();
        }
    }
}
