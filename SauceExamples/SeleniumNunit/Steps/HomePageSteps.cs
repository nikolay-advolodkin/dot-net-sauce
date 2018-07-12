using System;
using TechTalk.SpecFlow;

namespace SeleniumNunit.Steps
{
    [Binding]
    public class HomePageSteps
    {
        [When(@"the user opens Ultimate QA home page")]
        public void WhenTheUserOpensUltimateQAHomePage()
        {
            ScenarioContext.Current.Pending();
        }
        
        [Then(@"the home page loads successfully")]
        public void ThenTheHomePageLoadsSuccessfully()
        {
            ScenarioContext.Current.Pending();
        }
    }
}
