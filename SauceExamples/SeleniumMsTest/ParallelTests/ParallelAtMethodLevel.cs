using System.Threading;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace SeleniumMsTest.ParallelTests
{
    /*
     * How to execute parallel tests at the method level using MsTest
     *
     * Make sure that your AssemplyInfo.cs for the project has this property:
     * [assembly: Parallelize(Workers = 100, Scope = ExecutionScope.MethodLevel)]
     *
     * There are recommendations on the web to configure the .runsettings file,
     * but you do not need it to run in parallel.
     *
     * In this example, 25 are able to run without a problem on a VM with 2 cores
     */
    [TestClass]
    [TestCategory("MsTest")]
    public class ParallelAtMethodLevel
    {
        [TestMethod]
        public void TestMethod1()
        {
            Thread.Sleep(10000);
            Assert.IsTrue(true);
        }
        [TestMethod]
        public void TestMethod2()
        {
            Thread.Sleep(10000);
            Assert.IsTrue(true);
        }
        [TestMethod]
        public void TestMethod3()
        {
            Thread.Sleep(10000);
            Assert.IsTrue(true);
        }
        [TestMethod]
        public void TestMethod4()
        {
            Thread.Sleep(10000);
            Assert.IsTrue(true);
        }
        [TestMethod]
        public void TestMethod6()
        {
            Thread.Sleep(10000);
            Assert.IsTrue(true);
        }
        [TestMethod]
        public void TestMethod7()
        {
            Thread.Sleep(10000);
            Assert.IsTrue(true);
        }
        [TestMethod]
        public void TestMethod8()
        {
            Thread.Sleep(10000);
            Assert.IsTrue(true);
        }
        [TestMethod]
        public void TestMethod9()
        {
            Thread.Sleep(10000);
            Assert.IsTrue(true);
        }
        [TestMethod]
        public void TestMethod10()
        {
            Thread.Sleep(10000);
            Assert.IsTrue(true);
        }
        [TestMethod]
        public void TestMethod11()
        {
            Thread.Sleep(10000);
            Assert.IsTrue(true);
        }
        [TestMethod]
        public void TestMethod12()
        {
            Thread.Sleep(10000);
            Assert.IsTrue(true);
        }
        [TestMethod]
        public void TestMethod13()
        {
            Thread.Sleep(10000);
            Assert.IsTrue(true);
        }
        [TestMethod]
        public void TestMethod14()
        {
            Thread.Sleep(10000);
            Assert.IsTrue(true);
        }
        [TestMethod]
        public void TestMethod15()
        {
            Thread.Sleep(10000);
            Assert.IsTrue(true);
        }
        [TestMethod]
        public void TestMethod16()
        {
            Thread.Sleep(10000);
            Assert.IsTrue(true);
        }
        [TestMethod]
        public void TestMethod17()
        {
            Thread.Sleep(10000);
            Assert.IsTrue(true);
        }
        [TestMethod]
        public void TestMethod18()
        {
            Thread.Sleep(10000);
            Assert.IsTrue(true);
        }
        [TestMethod]
        public void TestMethod19()
        {
            Thread.Sleep(10000);
            Assert.IsTrue(true);
        }
        [TestMethod]
        public void TestMethod20()
        {
            Thread.Sleep(10000);
            Assert.IsTrue(true);
        }
        [TestMethod]
        public void TestMethod21()
        {
            Thread.Sleep(10000);
            Assert.IsTrue(true);
        }
        [TestMethod]
        public void TestMethod22()
        {
            Thread.Sleep(10000);
            Assert.IsTrue(true);
        }
        [TestMethod]
        public void TestMethod23()
        {
            Thread.Sleep(10000);
            Assert.IsTrue(true);
        }
        [TestMethod]
        public void TestMethod24()
        {
            Thread.Sleep(10000);
            Assert.IsTrue(true);
        }
        [TestMethod]
        public void TestMethod25()
        {
            Thread.Sleep(10000);
            Assert.IsTrue(true);
        }
        [TestMethod]
        public void TestMethod5()
        {
            Thread.Sleep(10000);
            Assert.IsTrue(true);
        }
    }
}
