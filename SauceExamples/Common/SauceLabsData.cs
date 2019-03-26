using System;

namespace Common
{
    public class SauceLabsData
    {
        public string SauceHubUrl => "https://ondemand.saucelabs.com/wd/hub";
        public Uri SauceHubUri => new Uri(SauceHubUrl);

        public string HeadlessUrl => "http://ondemand.us-east1.headless.saucelabs.com/wd/hub";
    }
}