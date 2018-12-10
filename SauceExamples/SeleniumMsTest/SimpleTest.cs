using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Reflection;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Remote;

namespace SeleniumMsTest
{
    [TestClass]
    [TestCategory("SimpleTest")]
    public class SimpleTest
    {
        IWebDriver _driver;
        public TestContext TestContext { get; set; }
        [TestMethod]
        public void PerformanceTestingSample()
        {
            var sauceUserName = Environment.GetEnvironmentVariable(
                "SAUCE_USERNAME", EnvironmentVariableTarget.User);
            var sauceAccessKey = Environment.GetEnvironmentVariable(
                "SAUCE_ACCESS_KEY", EnvironmentVariableTarget.User);

#pragma warning disable 618

            DesiredCapabilities caps = new DesiredCapabilities();
            caps.SetCapability("browserName", "Chrome");
            //set operating system to macOS version 10.13
            caps.SetCapability("platform", "Windows 10");
            //set the browser version to 11.1
            caps.SetCapability("version", "latest");
            caps.SetCapability("username", sauceUserName);
            caps.SetCapability("accessKey", sauceAccessKey);

            caps.SetCapability("name", MethodBase.GetCurrentMethod().Name);
            caps.SetCapability("build", "SampleReleaseA");
            var tags = new List<string> { "Release1", "SmokeTests", "LoginFeature" };
            caps.SetCapability("tags", tags);
            caps.SetCapability("extendedDebugging", true);
#pragma warning restore 618
            _driver =  new RemoteWebDriver(new Uri("https://ondemand.saucelabs.com/wd/hub"), caps,
                TimeSpan.FromSeconds(600));
            ((IJavaScriptExecutor)_driver).ExecuteScript("sauce:context=" + "Start Test");
            ((IJavaScriptExecutor)_driver).ExecuteScript("sauce:context=" + "Open Sauce Demo");
            _driver.Navigate().GoToUrl("https://www.saucedemo.com");

            //var throttleOptions = new Dictionary<string, object>();
            //throttleOptions["condition"] = "offline";
            //((IJavaScriptExecutor)_driver).ExecuteScript("sauce:throttle", throttleOptions);
            //_driver.Navigate().Refresh();
            //((IJavaScriptExecutor)_driver).ExecuteScript("sauce:performance");

            //timing didn't work
            //var timing = ((IJavaScriptExecutor)_driver).ExecuteScript("sauce:timing");

            //this works
            //var metrics = new Dictionary<string, object>();
            //metrics["type"] = "sauce:metrics";
            //var output = ((IJavaScriptExecutor)_driver).ExecuteScript("sauce:log", metrics);
            //((IJavaScriptExecutor) _driver).ExecuteScript("sauce:network");

        }

        [TestCleanup]
        public void CleanUpAfterEveryTestMethod()
        {
            var passed = TestContext.CurrentTestOutcome == UnitTestOutcome.Passed;
            ((IJavaScriptExecutor)_driver).ExecuteScript("sauce:context=" + "Stop Test");
            ((IJavaScriptExecutor)_driver).ExecuteScript("sauce:job-result=" + (passed ? "passed" : "failed"));
            _driver?.Quit();
        }
    }
}
