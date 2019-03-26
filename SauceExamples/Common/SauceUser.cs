using System;

namespace Common
{
    //TODO future version should probably inherit from an ISauceUser that forces the impl of username and accessKey
    public class SauceUser
    {
        public static string Name =>
            Environment.GetEnvironmentVariable("SAUCE_USERNAME", EnvironmentVariableTarget.User);

        public static string AccessKey =>
            Environment.GetEnvironmentVariable("SAUCE_ACCESS_KEY", EnvironmentVariableTarget.User);

        public static HeadlessSauceUser Headless => new HeadlessSauceUser();
    }
}
