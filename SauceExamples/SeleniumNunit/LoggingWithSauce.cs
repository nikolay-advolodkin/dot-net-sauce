using NLog;
using NUnit.Framework;
using OpenQA.Selenium;

namespace SeleniumNunit
{
    [TestFixture]
    class LoggingWithSauce
    {
        private static readonly ILogger TheLogger = LogManager.GetCurrentClassLogger();

        public IWebDriver Driver { get; private set; }

        [Test]
        public void LogWithNLog()
        {
            //this is a sample test action
            LogTestStep(TheLogger, "Open home page");
            //peform other actions
            LogTestStep(TheLogger, "Click Lululemon logo");

        }

        //It's critical for you to pass in the logger every time you use this method because
        //the logger needs to be created in EVERY class. This way, the logger will provide you information
        //about the class and the method that called it. If you make the logger live only in a single
        //class, you will be confused because all of the logging messages will come from that class in your text files
        // and this will be misleading.
        public void LogTestStep(ILogger logger, string message)
        {
            //make sure that your Info level messages are configured to go to the file and to the console
            logger.Info(message);
            ((IJavaScriptExecutor)Driver).ExecuteScript($"sauce:context={message}");
        }
    }
}
