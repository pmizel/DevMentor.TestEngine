using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace PerfSuite.Test.TestEngine
{
    public interface ITestEngine
    {
        bool IsTestClass(Type type);
        bool IsTestMethod(MethodInfo methodInfo);
        bool IsTestCleanup(MethodInfo methodInfo);
        bool IsTestInitialize(MethodInfo methodInfo);
        List<string> GetExpectedExceptions(MethodInfo methodInfo);
        string GetDescription(MethodInfo methodInfo);
        string GetDescription(Type type);
        string GetMessage(Exception ex);

        //bool IsFailed(Exception ex);
        //bool IsInconclusive(Exception ex);
        //bool IsExpectedException(Exception ex, string expectedException);
        //bool IsExpectedException(Exception ex, List<string> expectedExceptions);

    }
}
