using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace PerfSuite.Test
{
    public class TestContainer
    {
        public TestContainer()
        {
            TestCategorys = new List<TestCategory>();
        }
        public List<TestCategory> TestCategorys { get; set; }
    }

    public class TestCategory
    {
        public TestCategory(Assembly assembly, Type type)
            : this()
        {
            this.Assembly = assembly.FullName;
            this.Type = type.FullName;
            this.Name = type.Name;
            this.Description = type.GetDescription();
        }
        public TestCategory()
        {
            Test = new List<TestUnit>();
            TestInitialize = new List<TestUnit>();
            TestCleanup = new List<TestUnit>();
        }
        public List<TestUnit> Test { get; set; }
        public List<TestUnit> TestInitialize { get; set; }
        public List<TestUnit> TestCleanup { get; set; }

        public IEnumerable<TestUnit> AllTests
        {
            get
            {
                foreach (var item in TestInitialize)
                    yield return item;
                foreach (var item in Test)
                    yield return item;
                foreach (var item in TestCleanup)
                    yield return item;
            }
        }
        public string Assembly { get; set; }
        public string Type { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }

    public enum TestStatus
    {
        None,
        Passed,
        PassedExpectedException,
        Inconclusive,
        Failed,
        FailedUnhandledException,
        Timeout,
        Aborted,
        Unknown
    }
    public class TestUnit
    {
        public TestUnit(MethodInfo methodInfo)
            : this()
        {
            this.MethodInfo = methodInfo.Name;
            this.Name = methodInfo.Name;
            this.Description = methodInfo.GetDescription();
        }
        public TestUnit()
        {
            Enabled = true;
            ExpectedExceptions = new List<string>();
        }
        public string MethodInfo { get; set; }

        public string Name { get; set; }
        public string Description { get; set; }

        public string Message { get; set; }
        public string Exception { get; set; }
        public long ElapsedMilliseconds { get; set; }

        public List<string> ExpectedExceptions { get; set; }


        public bool Success { get; set; }
        public TestStatus Status { get; set; }

        [XmlAttribute]
        public bool Enabled { get; set; }

        public void HandleException(Exception ex)
        {

        }
    }

}
