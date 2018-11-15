using System;
using System.Globalization;
using Common;
using NUnit.Framework;

namespace SeleniumNunit.BestPractices.CrossBrowserExamples
{
    [SetUpFixture]
    public class NamespaceSetup
    {
        [OneTimeSetUp]
        public void RunForWholeNamespace()
        {
            SauceLabsCapabilities.BuildName = $"CrossBrowserTests-{DateTime.Now.ToString(CultureInfo.InvariantCulture)}";
        }
    }
}
