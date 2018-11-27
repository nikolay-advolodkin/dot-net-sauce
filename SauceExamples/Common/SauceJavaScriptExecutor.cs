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
        public void LogTestStatus(bool isPassed, string message)
        {

            ((IJavaScriptExecutor)_driver).
                ExecuteScript("sauce:job-result=" + (isPassed ? "passed" : "failed"));
            LogMessage(message);
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
