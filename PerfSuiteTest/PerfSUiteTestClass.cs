using BAG.PerfSuite.Public.TestFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace PerfSuiteTest
{
    [TestClass]
    [Description("Beschreibung der Klasse")]
    public class PerfSuiteTestClass
    {
        [TestInitialize]
        public void MethodInit()
        {
            System.Threading.Thread.Sleep(400);
        }

        [TestMethod]
        [Description("Beschreibung MethodInconclusive")]
        public void MethodInconclusive()
        {
            System.Threading.Thread.Sleep(400);
            Assert.Inconclusive("Mein Text...");
        }


        [TestMethod]
        [Description("Beschreibung MethodSuccess")]
        public void MethodSuccess()
        {
            System.Threading.Thread.Sleep(400);
            Assert.AreEqual(2, 2);
        }

        [TestMethod]
        public void MethodAreEqual()
        {
            System.Threading.Thread.Sleep(400);
            Assert.AreEqual(2, 3,"Sollte gleich sein...");
        }

        [TestMethod]
        public void MethodFail()
        {
            Assert.Fail("Fail weil absicht...");
        }

        [TestMethod]
        public void MethodAreSame()
        {
            System.Threading.Thread.Sleep(400);
            Assert.AreSame("Not", "NotYet","Oh Oh");
        }

        [TestMethod]
        [Ignore]
        public void TestMethodIgnore()
        {
            Thread.Sleep(500);
        }

    }
}
