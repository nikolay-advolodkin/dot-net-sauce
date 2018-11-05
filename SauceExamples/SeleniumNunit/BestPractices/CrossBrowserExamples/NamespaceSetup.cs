using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
