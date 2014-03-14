using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace PerfSuite.Test.TestEngine
{
    public class TestEngineProvider
    {
        public ITestEngine GetService()
        {
            ITestEngine result = null;

            var key = "UnitTestFramework"; //Web.Config
            switch (key)
            {
                case "UnitTestFramework":
                    result = new UnitTestFramework();
                    break;
                case "PerfSuiteTestFramework":
                    result = new PerfSuiteTestFramework();
                    break;
                case "NUnitTestFramework":
                    result = new NUnitTestFramework();
                    break;               
                default:
                    result = Activator.CreateInstance(null, key) as ITestEngine;
                    break;
            }
            return result;
        }
    }
}
