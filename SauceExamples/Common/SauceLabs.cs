using OpenQA.Selenium;
using OpenQA.Selenium.Remote;

namespace Common
{
    public class SauceLabs
    {
        private DesiredCapabilities _desiredCaps;
        public string UserName { get; private set; }
        public string AccessKey { get; private set; }

        public SauceLabs()
        {
        }

        public DesiredCapabilities DesiredCaps { get => _desiredCaps; set => _desiredCaps = value; }

        public DesiredCapabilities GetDesiredCapabilities()
        {
            _desiredCaps = new DesiredCapabilities();
            UserName = SauceUser.Name;
            AccessKey = SauceUser.AccessKey;
            return DesiredCaps;
        }
        public SauceJavaScriptExecutor JavaScriptApi(IWebDriver driver)
        {
            return new SauceJavaScriptExecutor(driver);
        }
    }
}