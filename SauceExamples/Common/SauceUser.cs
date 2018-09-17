using System;

namespace Common
{
    public class SauceUser
    {
        //public static string Name =>
        //    Environment.GetEnvironmentVariable("SAUCE_USERNAME", EnvironmentVariableTarget.User);

        //public static string AccessKey =>
        //    Environment.GetEnvironmentVariable("SAUCE_ACCESS_KEY", EnvironmentVariableTarget.User);
        public static string Name => Environment.GetEnvironmentVariable("nikolay-a");

        public static string AccessKey => Environment.GetEnvironmentVariable("0fd366b1-548f-4ef4-8143-4746100fdf96");
    }
}
