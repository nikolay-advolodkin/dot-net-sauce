using System;

namespace Common
{
    public class SauceUser
    {
        public static string Name =>
            Environment.GetEnvironmentVariable("SAUCE_USERNAME", EnvironmentVariableTarget.User);

        public static string AccessKey =>
            Environment.GetEnvironmentVariable("SAUCE_ACCESS_KEY", EnvironmentVariableTarget.User);
    }
}
