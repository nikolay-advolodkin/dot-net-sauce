using System.Reflection;
using Common;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AppiumOnDotNetFramework
{
    [TestClass]
    public class Rdc
    {
        [TestMethod]
        public void SimpleTest()
        {
            new SampleTests().TestNativeAndroidApp(MethodBase.GetCurrentMethod().Name);
        }   
    }
}
