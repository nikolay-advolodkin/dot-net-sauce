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
                //chrome
                yield return new TestFixtureData("Chrome", "latest", "macOS 10.13");
                yield return new TestFixtureData("Chrome", "latest-1", "macOS 10.13");
                yield return new TestFixtureData("Chrome", "latest-2", "macOS 10.13");

                //safari
                yield return new TestFixtureData("Safari", "latest", "macOS 10.13");
                yield return new TestFixtureData("Safari", "latest-1", "macOS 10.12");
                yield return new TestFixtureData("Safari", "10.0", "OS X 10.11");

                //firefox
                yield return new TestFixtureData("Firefox", "latest", "macOS 10.13");
                yield return new TestFixtureData("Firefox", "latest-1", "macOS 10.13");
                yield return new TestFixtureData("Firefox", "latest-2", "macOS 10.13");

                //edge
                yield return new TestFixtureData("MicrosoftEdge", "latest", "Windows 10");
                yield return new TestFixtureData("MicrosoftEdge", "latest-1", "Windows 10");
                yield return new TestFixtureData("MicrosoftEdge", "latest-2", "Windows 10");

                //IE
            }
        }

        public static IEnumerable LatestChrome
        {
            get
            {
                yield return new TestFixtureData("Chrome", "latest", "macOS 10.13");
            }
        }
    }
}