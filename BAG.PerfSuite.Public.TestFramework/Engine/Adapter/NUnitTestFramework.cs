using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BAG.PerfSuite.Public.TestFramework.Engine.Adapter
{
    public class NUnitTestFramework : ITestEngine
    {

        public bool IsTestClass(Type type)
        {
            throw new NotImplementedException();
        }

        public bool IsTestMethod(System.Reflection.MethodInfo methodInfo)
        {
            throw new NotImplementedException();
        }

        public bool IsTestCleanup(System.Reflection.MethodInfo methodInfo)
        {
            throw new NotImplementedException();
        }

        public bool IsTestInitialize(System.Reflection.MethodInfo methodInfo)
        {
            throw new NotImplementedException();
        }
        public bool IsIgnore(System.Reflection.MethodInfo methodInfo)
        {
            throw new NotImplementedException();
        }

        public List<string> GetExpectedExceptions(System.Reflection.MethodInfo methodInfo)
        {
            throw new NotImplementedException();
        }

        public string GetDescription(System.Reflection.MethodInfo methodInfo)
        {
            throw new NotImplementedException();
        }

        public string GetDescription(Type type)
        {
            throw new NotImplementedException();
        }

        public string GetMessage(Exception ex)
        {
            throw new NotImplementedException();
        }

        public bool CheckExpectedExceptions(Exception ex, List<string> expectedExceptions)
        {
            throw new NotImplementedException();
        }


        public bool CheckExpectedException(Exception ex, string expectedException)
        {
            throw new NotImplementedException();
        }

        public bool IsFailed(Exception ex)
        {
            throw new NotImplementedException();
        }

        public bool IsInconclusive(Exception ex)
        {
            throw new NotImplementedException();
        }

        public bool IsExpectedException(Exception ex, string expectedException)
        {
            throw new NotImplementedException();
        }

        public bool IsExpectedException(Exception ex, List<string> expectedExceptions)
        {
            throw new NotImplementedException();
        }
    }
}
