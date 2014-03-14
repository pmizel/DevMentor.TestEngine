using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace BAG.PerfSuite.Public.TestFramework.DataModels
{
    public class TestCategory
    {
        public TestCategory(Assembly assembly, Type type, string description = "")
            : this()
        {
            this.Assembly = assembly.FullName;
            this.Type = type.FullName;
            this.Name = type.Name;
            this.Description = description;
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
        public long ElapsedMilliseconds { get; set; }
    }
}
