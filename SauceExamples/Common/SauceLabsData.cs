using System;

namespace Common
{
    public class SauceLabsData
    {
        public string SauceHubUrl => "https://ondemand.saucelabs.com/wd/hub";
        public Uri SauceHubUri => new Uri(SauceHubUrl);
    }
}