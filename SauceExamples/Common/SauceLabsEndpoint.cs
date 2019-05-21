using System;

namespace Common
{
    public class SauceLabsEndpoint
    {
        public string SauceHubUrl => "https://ondemand.saucelabs.com/wd/hub";
        public Uri SauceHubUri => new Uri(SauceHubUrl);

        public string HeadlessSeleniumUrl => "https://ondemand.us-east-1.saucelabs.com/wd/hub";

        public string HeadlessRestApiUrl => "https://us-east-1.saucelabs.com/rest/v1";
    }
}