using System;
using System.Reflection;
using Common;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Appium.Android;
using OpenQA.Selenium.Remote;
using RestSharp;

namespace AppiumLatestOnDotNetFramework
{
    [TestClass]
    [TestCategory("MsTest")]
    [TestCategory("Rdc")]
    [TestCategory("Android")]

    public class RdcCheckWithMsTest
    {
        private SessionId _sessionId;
        private AndroidDriver<IWebElement> _driver;
        public TestContext TestContext { get; set; }

        [TestMethod]
        public void RunRdcOnAndroid()
        {
            var capabilities = new DesiredCapabilities();
            capabilities.SetCapability("platformName", "Android");
            capabilities.SetCapability("platformVersion", "7.1.1");
            //TODO first you must upload an app to Test Object so that you get your app key
            capabilities.SetCapability("testobject_api_key", "622F71C1DA6C431B847542BC8B9EAA71");
            capabilities.SetCapability("name", MethodBase.GetCurrentMethod().Name);
            capabilities.SetCapability("newCommandTimeout", 90);

            var rdcUrl = "https://us1.appium.testobject.com/wd/hub";
            //TODO should be interchangeable to run on Windows/Mac
            _driver = new AndroidDriver<IWebElement>(new Uri(rdcUrl), capabilities, 
                TimeSpan.FromSeconds(300));
            _sessionId = _driver.SessionId;

            _driver.Navigate().GoToUrl("https://www.saucedemo.com");
            Assert.IsTrue(false);

        }
        [TestCleanup]
        public void Teardown()
        {
            var isPassed = TestContext.CurrentTestOutcome == UnitTestOutcome.Passed;
            var jsonBody = "{\"passed\":\"" + isPassed + "\"}";

            var client = new RestClient("https://app.testobject.com/api/rest");
            var request = new RestRequest($"/v2/appium/session/{_sessionId}/test", Method.PUT);
            request.AddParameter("application/json", jsonBody, ParameterType.RequestBody);
            client.Execute(request);
            _driver.Quit();
        }
    }
}
