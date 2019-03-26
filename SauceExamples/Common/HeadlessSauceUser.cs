using System;

namespace Common
{
    //TODO future version should probably inherit from an ISauceUser that forces the impl of username and accessKey
    public class HeadlessSauceUser
    {
        public string UserName => Environment.GetEnvironmentVariable("SAUCE_HEADLESS_USERNAME", EnvironmentVariableTarget.User);
        public string AccessKey => Environment.GetEnvironmentVariable("SAUCE_HEADLESS_ACCESS_KEY", EnvironmentVariableTarget.User);
    }
}