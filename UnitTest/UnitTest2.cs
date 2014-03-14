using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Threading;

namespace UnitTest
{
    [TestClass]
    public class UnitTest2
    {
        [TestMethod]
        //[ExpectedException(typeof(Microsoft.VisualStudio.TestTools.UnitTesting.AssertFailedException))]
        [ExpectedException(typeof(NotImplementedException))]
        public void TestMethodException()
        {
            Thread.Sleep(200);
            Assert.IsFalse(true);
            Assert.IsFalse(false);
            throw new NotImplementedException();
        }

        [TestMethod]
        public void TestMethodInconclusive()
        {
            Thread.Sleep(500);
            Assert.Inconclusive("Oh oh Inconclusive");
        }

        [TestMethod]
        [Ignore]
        public void TestMethodIgnore()
        {
            Thread.Sleep(500);            
        }
    }
}
