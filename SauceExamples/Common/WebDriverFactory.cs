using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Remote;

namespace Common
{
    public class WebDriverFactory
    {
        public IWebDriver CreateSauceDriver(string testCaseName)
        {
            var capabilities = new DesiredCapabilities();
            capabilities.SetCapability(CapabilityType.BrowserName, "chrome");
            capabilities.SetCapability(CapabilityType.Version, "latest");
            capabilities.SetCapability(CapabilityType.Platform, "Windows 10");
            capabilities.SetCapability("deviceName", "");
            capabilities.SetCapability("deviceOrientation", "");
            capabilities.SetCapability("username", 
                Environment.GetEnvironmentVariable("SAUCE_USERNAME", EnvironmentVariableTarget.User));
            capabilities.SetCapability("accessKey", 
                Environment.GetEnvironmentVariable("SAUCE_ACCESS_KEY", EnvironmentVariableTarget.User));

            capabilities.SetCapability("extendedDebugging", true);
            capabilities.SetCapability("tunnelIdentifier", "NikolaysTunnel");
            //How long is a test allowed to run?
            capabilities.SetCapability("maxDuration", 3600);
            //Selenium crash might hang a command, this is the max time allowed to wait for a Selenium command
            capabilities.SetCapability("commandTimeout", 600);
            //How long can the browser wait before a new command?
            capabilities.SetCapability("idleTimeout", 1000);
            var driver =  new RemoteWebDriver(new Uri("http://ondemand.saucelabs.com:80/wd/hub"),
                capabilities, TimeSpan.FromSeconds(600));
            ((IJavaScriptExecutor)driver).ExecuteScript($"sauce:job-name={testCaseName}");
            return driver;
        }
    }
}
