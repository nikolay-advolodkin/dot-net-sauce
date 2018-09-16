using OpenQA.Selenium;

namespace Common
{
    public class SauceJavaScriptExecutor
    {
        private IWebDriver _driver;

        public SauceJavaScriptExecutor(IWebDriver driver)
        {
            _driver = driver;
        }
        public void LogTestStatus(bool isPassed)
        {

            ((IJavaScriptExecutor)_driver).
                ExecuteScript("sauce:job-result=" + (isPassed ? "passed" : "failed"));
        }
        public void LogMessage(string message)
        {
            ((IJavaScriptExecutor)_driver).
                ExecuteScript($"sauce:context={message}");
        }

        public void SetTestName(string testName)
        {
            ((IJavaScriptExecutor)_driver).ExecuteScript($"sauce:job-name={testName}");
        }
    }
}
