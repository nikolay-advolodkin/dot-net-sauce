using OpenQA.Selenium.Remote;
using System;

namespace Common
{
    public class SauceLabs
    {
        private DesiredCapabilities _desiredCaps;

        public SauceLabs()
        {
        }

        public DesiredCapabilities GetDesiredCaps()
        {
            return new DesiredCapabilities();
        }

        public SauceLabs DesiredCaps()
        {
            _desiredCaps = new DesiredCapabilities();
            return this;
        }

        public DesiredCapabilities WithCredentials()
        {
            _desiredCaps.SetCapability("username", SauceUser.Name);
            _desiredCaps.SetCapability("accessKey", SauceUser.AccessKey);
            return _desiredCaps;
        }
    }
}