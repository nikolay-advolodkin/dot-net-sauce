using System.Collections;
using NUnit.Framework;

namespace SeleniumNunit.BestPractices.CrossBrowserExamples
{
    public class CrossBrowserData
    {
        public static IEnumerable LatestConfigurations
        {
            get
            {
                yield return new TestFixtureData("Chrome", "latest", "macOS 10.13");
                yield return new TestFixtureData("Safari", "latest", "macOS 10.13");
                yield return new TestFixtureData("Firefox", "latest", "macOS 10.13");
                yield return new TestFixtureData("Chrome", "latest-1", "macOS 10.13");
                yield return new TestFixtureData("Safari", "latest-1", "macOS 10.12");
                yield return new TestFixtureData("Firefox", "latest-1", "macOS 10.13");
                yield return new TestFixtureData("Chrome", "latest-2", "macOS 10.13");
                yield return new TestFixtureData("Safari", "10.0", "OS X 10.11");
                yield return new TestFixtureData("Firefox", "latest-2", "macOS 10.13");
            }
        }
    }
}