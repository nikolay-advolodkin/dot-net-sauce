using System.Collections.Generic;
using System.Reflection;

namespace SeleniumMsTest.ParallelTests.DataDriven
{
    public class MsTestCrossBrowserData
    {
        public static IEnumerable<object[]> LatestConfigurations => new[]
        {
            new object[] {"Chrome", "latest", "macOS 10.13"},
            new object[] {"Chrome", "latest-1", "macOS 10.13" }
        };
        public static string GetCustomDynamicDataDisplayName(MethodInfo methodInfo, object[] data)
        {
            return string.Format("DynamicDataTestMethod {0} with {1} parameters", methodInfo.Name, data.Length);
        }
    }
}