using OpenQA.Selenium.Remote;

namespace Common
{
    public class SauceLabs
    {
        private DesiredCapabilities desiredCaps;

        public SauceLabs()
        {
        }

        public DesiredCapabilities DesiredCaps { get => desiredCaps; set => desiredCaps = value; }

        public SauceLabs GetDesiredCapabilities()
        {
            DesiredCaps = new DesiredCapabilities();
            return this;
        }

        public DesiredCapabilities WithCredentials()
        {
            DesiredCaps.SetCapability("username", SauceUser.Name);
            DesiredCaps.SetCapability("accessKey", SauceUser.AccessKey);
            return DesiredCaps;
        }
    }
}