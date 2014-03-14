using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BAG.PerfSuite.Public.TestFramework
{
    /// <summary>Identifies a method that contains code that must be used after the test has run and to free resources obtained by all the tests in the test class. This class cannot be inherited.</summary>
    [AttributeUsage(AttributeTargets.Method, AllowMultiple = false)]
    public sealed class TestCleanupAttribute : Attribute
    {
    }
}
