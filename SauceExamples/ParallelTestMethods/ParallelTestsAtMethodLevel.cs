using System;
using System.Threading;
using NUnit.Framework;


namespace ParallelTestMethods
{
    [TestFixture]
    [Category("Simple parallelized unit tests")]
    public class ParallelTestsAtMethodLevel
    {
        //This will default to the number of processors that a laptop has and will run that many threads at the same time
        [Test]
        [Parallelizable]
        public void TestMethod1()
        {
            Thread.Sleep(10000);
            Assert.Pass();
        }
        [Test]
        [Parallelizable]
        public void TestMethod2()
        {
            Thread.Sleep(10000);
            Assert.Pass();
        }
        [Test]
        [Parallelizable]
        public void TestMethod3()
        {
            Thread.Sleep(10000);
            Assert.Pass();
        }
        [Test]
        [Parallelizable]
        public void TestMethod4()
        {
            Thread.Sleep(10000);
            Assert.Pass();
        }
    }
}
