using System;
using System.Collections.Generic;
using System.Diagnostics.Tracing;
using System.Globalization;
using OpenQA.Selenium;
using OpenQA.Selenium.Remote;

namespace Common
{
    public class WebDriverFactory
    {
        private SauceLabsCapabilities _sauceCustomCapabilities;
        private DesiredCapabilities _desiredCapabilities;

        public WebDriverFactory()
        {
            _sauceCustomCapabilities = new SauceLabsCapabilities();
            _desiredCapabilities = new DesiredCapabilities();
        }

        public IWebDriver CreateSauceDriver(string testCaseName)
        {
            _desiredCapabilities.SetCapability(CapabilityType.BrowserName, "chrome");
            //will run on the latest browserVersion of the browser
            _desiredCapabilities.SetCapability(CapabilityType.Version, "latest");
            _desiredCapabilities.SetCapability(CapabilityType.Platform, "Windows 10");

            return SetSauceCapabilities(testCaseName, _desiredCapabilities);
        }

        private IWebDriver SetSauceCapabilities(string testCaseName, DesiredCapabilities capabilities)
        {
            _desiredCapabilities = capabilities;
            _desiredCapabilities.SetCapability("username", SauceUser.Name);
            _desiredCapabilities.SetCapability("accessKey", SauceUser.AccessKey);

            //CUSTOM SAUCE CAPABILITIES
            //These capabilities are excellent for debugging and make it much easier.
            //However, if your tests are pretty stable and you want faster tests, disable all the debugging features
            //capabilities.SetCapability("extendedDebugging", true);
            //capabilities.SetCapability("recordVideo", false);
            //capabilities.SetCapability("videoUploadOnPass", false);
            //capabilities.SetCapability("recordScreenshots", false);
            _desiredCapabilities.SetCapability("build", $"SauceExamples-{DateTime.Now.ToString(CultureInfo.InvariantCulture)}");
            var tags = new List<string> {"withDebugging", "automationGroupName1", "automationGroupName2"};
            _desiredCapabilities.SetCapability("tags", tags);
            //capabilities.SetCapability("tunnelIdentifier", "NikolaysTunnel");

            //SAUCE TIMEOUT CAPABILITIES
            //How long is a test allowed to run?
            _desiredCapabilities.SetCapability("maxDuration", 3600);
            //Selenium crash might hang a command, this is the max time allowed to wait for a Selenium command
            _desiredCapabilities.SetCapability("commandTimeout", 600);
            //How long can the browser wait before a new command?
            _desiredCapabilities.SetCapability("idleTimeout", 1000);
            var driver = new RemoteWebDriver(new Uri("http://ondemand.saucelabs.com:80/wd/hub"),
                _desiredCapabilities, TimeSpan.FromSeconds(600));
            new SauceJavaScriptExecutor(driver).SetTestName(testCaseName);
            return driver;
        }
        public IWebDriver CreateSauceDriver(string browser, string browserVersion, string osPlatform, bool isDebuggingOn)
        {
            _desiredCapabilities.SetCapability(CapabilityType.BrowserName, browser);
            _desiredCapabilities.SetCapability(CapabilityType.Version, browserVersion);
            _desiredCapabilities.SetCapability(CapabilityType.Platform, osPlatform);

            _sauceCustomCapabilities = new SauceLabsCapabilities {IsDebuggingEnabled = isDebuggingOn};
            return SetSauceCapabilities(_desiredCapabilities);
        }

        private IWebDriver SetSauceCapabilities(DesiredCapabilities capabilities)
        {
            _desiredCapabilities = capabilities;
            _desiredCapabilities.SetCapability("username", SauceUser.Name);
            _desiredCapabilities.SetCapability("accessKey", SauceUser.AccessKey);

            //CUSTOM SAUCE CAPABILITIES
            _desiredCapabilities = SetDebuggingCapabilities(_desiredCapabilities);
            //_desiredCapabilities.SetCapability("build", $"SauceExamples-{DateTime.Now.ToString(CultureInfo.InvariantCulture)}");
            _desiredCapabilities.SetCapability("build", $"SauceExamples-{_sauceCustomCapabilities.Tags[0]}");
            _desiredCapabilities.SetCapability("tags", _sauceCustomCapabilities.Tags);
            //_desiredCapabilities.SetCapability("tunnelIdentifier", "NikolaysTunnel");

            //SAUCE TIMEOUT CAPABILITIES
            SetSauceTimeouts();
            var driver = new RemoteWebDriver(new Uri("http://ondemand.saucelabs.com:80/wd/hub"),
                _desiredCapabilities, TimeSpan.FromSeconds(600));
            return driver;
        }

        private void SetSauceTimeouts()
        {
            //How long is a test allowed to run?
            _desiredCapabilities.SetCapability("maxDuration", 3600);
            //Selenium crash might hang a command, this is the max time allowed to wait for a Selenium command
            _desiredCapabilities.SetCapability("commandTimeout", 600);
            //How long can the browser wait before a new command?
            _desiredCapabilities.SetCapability("idleTimeout", 1000);
        }

        private DesiredCapabilities SetDebuggingCapabilities(DesiredCapabilities capabilities)
        {
            //These capabilities are excellent for debugging and make it much easier.
            //However, if your tests are pretty stable and you want faster tests, disable all the debugging features
            if (_sauceCustomCapabilities.IsDebuggingEnabled)
            {
                capabilities.SetCapability("extendedDebugging", true);
                capabilities.SetCapability("recordVideo", true);
                capabilities.SetCapability("videoUploadOnPass", true);
                capabilities.SetCapability("recordScreenshots", true);
                _sauceCustomCapabilities.Tags.Add("withDebuggingEnabled");
                return capabilities;
            }

            capabilities.SetCapability("extendedDebugging", false);
            capabilities.SetCapability("recordVideo", false);
            capabilities.SetCapability("videoUploadOnPass", false);
            capabilities.SetCapability("recordScreenshots", false);
            _sauceCustomCapabilities.Tags.Add("withDebuggingDisabled");
            return capabilities;
        }
    }
}
