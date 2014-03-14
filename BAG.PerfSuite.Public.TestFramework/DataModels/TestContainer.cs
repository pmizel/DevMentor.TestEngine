using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace BAG.PerfSuite.Public.TestFramework.DataModels
{
    public class TestContainer
    {
        public TestContainer()
        {
            TestCategorys = new List<TestCategory>();
        }
        public List<TestCategory> TestCategorys { get; set; }
        public long ElapsedMilliseconds { get; set; }
    }

    

    

}
