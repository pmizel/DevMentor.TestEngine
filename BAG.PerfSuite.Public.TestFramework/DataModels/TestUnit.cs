using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace BAG.PerfSuite.Public.TestFramework.DataModels
{
    public class TestUnit
    {
        public TestUnit(MethodInfo methodInfo, string description = "")
            : this()
        {
            this.MethodInfo = methodInfo.Name;
            this.Name = methodInfo.Name;
            this.Description = description;
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
        public string Thread { get; set; }
        public string Exception { get; set; }
        public long ElapsedMilliseconds { get; set; }

        public List<string> ExpectedExceptions { get; set; }


        //public bool Success { get; set; }
        public TestStatus Status { get; set; }

        [XmlAttribute]
        public bool Enabled { get; set; }

    }
}
