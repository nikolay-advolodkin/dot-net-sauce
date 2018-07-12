using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Remote;

namespace Common
{
    public class WebDriverFactory
    {
        public IWebDriver CreateSauceDriver(string testCaseName)
        {
            var capabilities =  new DesiredCapabilities();
            capabilities.SetCapability(CapabilityType.BrowserName, "chrome");
            capabilities.SetCapability(CapabilityType.Version, "latest");
            capabilities.SetCapability(CapabilityType.Platform, "Windows 10");
            capabilities.SetCapability("deviceName", "");
            capabilities.SetCapability("deviceOrientation", "");
            capabilities.SetCapability("username", 
                Environment.GetEnvironmentVariable("SAUCE_USERNAME", EnvironmentVariableTarget.User));
            capabilities.SetCapability("accessKey", 
                Environment.GetEnvironmentVariable("SAUCE_ACCESS_KEY", EnvironmentVariableTarget.User));
            var driver =  new RemoteWebDriver(new Uri("http://ondemand.saucelabs.com:80/wd/hub"),
                capabilities, TimeSpan.FromSeconds(600));
            ((IJavaScriptExecutor)driver).ExecuteScript($"sauce:job-name={testCaseName}");
            return driver;
        }
    }
}
