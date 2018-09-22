using System.Reflection;
using Common;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AppiumOnDotNetFramework
{
    [TestClass]
    public class Rdc
    {
        [TestMethod]
        [TestCategory("AppiumTest")]
        public void SimpleTest()
        {
            new SampleTests().TestNativeAndroidApp(MethodBase.GetCurrentMethod().Name);
        }   
    }
}
