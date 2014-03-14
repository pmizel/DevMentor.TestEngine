using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTest
{
    [TestClass]    
    public class UnitTest1
    {
        [TestMethod]
        [TestInitialize]
        public void TestMethodInitialize()
        {
            //Assert.AreEqual("","");
            //Microsoft.VisualStudio.TestTools.UnitTesting.StringAssert.
            //Assert.AreEqual(2, 5);
            System.Threading.Thread.Sleep(200);
        }

        [TestMethod]
        [Description("Mein Test")]
        public void TestWhy()
        {
            System.Threading.Thread.Sleep(100);
            //Assert.AreEqual("","");
            //Microsoft.VisualStudio.TestTools.UnitTesting.StringAssert.
            Assert.AreEqual(2, 2,"Error wenn es nicht passt.");
        }

        [TestMethod]
        [Description("Mein Test 4")]
        public void TestMethod4()
        {
            System.Threading.Thread.Sleep(400);
            Assert.IsFalse(false);
        }

        [Ignore]
        [TestMethod]
        [TestCleanup]
        public void TestCleanup()
        {
            System.Threading.Thread.Sleep(400);
            //Assert.AreEqual("","");
            //Microsoft.VisualStudio.TestTools.UnitTesting.StringAssert.
            
        }
    }
}
