using BAG.PerfSuite.Public.TestFramework.Engine.Adapter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace BAG.PerfSuite.Public.TestFramework.Engine
{
    public static class TestEngineExtensions
    {
        private static ITestEngine testEngine;
        public static ITestEngine TestEngine
        {
            get
            {
                if (testEngine == null)
                    testEngine = new TestEngineProvider().GetService();
                return testEngine;
            }
        }
        public static bool IsTestClass(this Type type)
        {
            return TestEngine.IsTestClass(type);
        }
        public static bool IsTestMethod(this MethodInfo methodInfo)
        {
            return TestEngine.IsTestMethod(methodInfo);
        }
        public static bool IsTestCleanup(this MethodInfo methodInfo)
        {
            return TestEngine.IsTestCleanup(methodInfo);
        }
        public static bool IsTestInitialize(this MethodInfo methodInfo)
        {
            return TestEngine.IsTestInitialize(methodInfo);
        }
        public static bool IsIgnore(this MethodInfo methodInfo)
        {
            return TestEngine.IsIgnore(methodInfo);
        }
        public static List<string> GetExpectedExceptions(this MethodInfo methodInfo)
        {
            return TestEngine.GetExpectedExceptions(methodInfo);
        }
        public static string GetDescription(this MethodInfo methodInfo)
        {
            return TestEngine.GetDescription(methodInfo);
        }
        public static string GetDescription(this Type type)
        {
            return TestEngine.GetDescription(type);
        }
        public static string GetMessage(this Exception ex)
        {
            return TestEngine.GetMessage(ex);
        }
        public static bool IsFailed(this Exception ex)
        {
            return TestEngine.IsFailed(ex);
        }
        public static bool IsInconclusive(this Exception ex)
        {
            return TestEngine.IsInconclusive(ex);
        }
        public static bool IsExpectedException(this Exception ex, string expectedException)
        {
            return TestEngine.IsExpectedException(ex, expectedException);
        }
        public static bool IsExpectedException(this Exception ex, List<string> expectedExceptions)
        {
            return TestEngine.IsExpectedException(ex, expectedExceptions);
        }
    }




    //public static class TestEngineExtensions
    //{
    //    private static ITestEngine testEngine;
    //    public static ITestEngine TestEngine
    //    {
    //        get
    //        {
    //            if (testEngine == null)
    //                testEngine = new TestEngineProvider().GetService();
    //            return testEngine;
    //        }
    //    }


    //    public static bool IsTestClass(this Type type)
    //    {
    //        return TestEngine.IsTestClass(type);

    //        //var attributes = type.GetCustomAttributes();
    //        //foreach (var attribute in attributes)
    //        //{
    //        //    if (attribute.GetType().Name == "TestClassAttribute")
    //        //        return true;
    //        //}
    //        //return false;
    //    }
    //    public static bool IsTestMethod(this MethodInfo methodInfo)
    //    {
    //        return TestEngine.IsTestMethod(methodInfo);
    //        //var attributes = methodInfo.GetCustomAttributes();
    //        //foreach (var attribute in attributes)
    //        //{
    //        //    if (attribute.GetType().Name == "TestMethodAttribute")
    //        //        return true;
    //        //}
    //        //return false;
    //    }

    //    public static bool IsTestCleanup(this MethodInfo methodInfo)
    //    {
    //        return TestEngine.IsTestCleanup(methodInfo);
    //        //var attributes = methodInfo.GetCustomAttributes();
    //        //foreach (var attribute in attributes)
    //        //{
    //        //    if (attribute.GetType().Name == "TestCleanupAttribute")
    //        //        return true;
    //        //}
    //        //return false;
    //    }


    //    public static bool IsTestInitialize(this MethodInfo methodInfo)
    //    {
    //        return TestEngine.IsTestInitialize(methodInfo);
    //        //var attributes = methodInfo.GetCustomAttributes();
    //        //foreach (var attribute in attributes)
    //        //{
    //        //    if (attribute.GetType().Name == "TestInitializeAttribute")
    //        //        return true;
    //        //}
    //        //return false;
    //    }
    //    public static bool IsIgnore(this MethodInfo methodInfo)
    //    {
    //        return TestEngine.IsIgnore(methodInfo);
    //        //var attributes = methodInfo.GetCustomAttributes();
    //        //foreach (var attribute in attributes)
    //        //{
    //        //    if (attribute.GetType().Name == "IgnoreAttribute")
    //        //        return true;
    //        //}
    //        //return false;
    //    }

    //    public static List<string> GetExpectedExceptions(this MethodInfo methodInfo)
    //    {
    //        return TestEngine.GetExpectedExceptions(methodInfo);
    //        //var attributes = methodInfo.GetCustomAttributes();
    //        //List<string> result = new List<string>();
    //        //foreach (var attribute in attributes)
    //        //{
    //        //    if (attribute.GetType().Name == "ExpectedExceptionAttribute")
    //        //    {
    //        //        try
    //        //        {
    //        //            var type = attribute.GetType().GetProperty("ExceptionType").GetValue(attribute, null) as Type;
    //        //            if (type != null)
    //        //                result.Add(type.Name);
    //        //        }
    //        //        catch (Exception)
    //        //        {
    //        //        }

    //        //    }
    //        //}
    //        //return result;
    //    }

    //    public static string GetDescription(this MethodInfo methodInfo)
    //    {
    //        return TestEngine.GetDescription(methodInfo);
    //        //var attributes = methodInfo.GetCustomAttributes();
    //        //foreach (var attribute in attributes)
    //        //{
    //        //    if (attribute.GetType().Name == "DescriptionAttribute")
    //        //    {
    //        //        string result = string.Empty;
    //        //        try
    //        //        {
    //        //            result = attribute.GetType().GetProperty("Description").GetValue(attribute, null) as string;
    //        //        }
    //        //        catch (Exception)
    //        //        {
    //        //        }
    //        //        return result;
    //        //    }
    //        //}
    //        //return string.Empty;
    //    }
    //    public static string GetDescription(this Type type)
    //    {
    //        return TestEngine.GetDescription(type);

    //        //var attributes = type.GetCustomAttributes();
    //        //foreach (var attribute in attributes)
    //        //{
    //        //    if (attribute.GetType().Name == "DescriptionAttribute")
    //        //    {
    //        //        string result = string.Empty;
    //        //        try
    //        //        {
    //        //            result = attribute.GetType().GetProperty("Description").GetValue(attribute, null) as string;
    //        //        }
    //        //        catch (Exception)
    //        //        {
    //        //        }
    //        //        return result;
    //        //    }
    //        //}
    //        //return string.Empty;
    //    }

    //    public static string GetMessage(this Exception ex)
    //    {
    //        return TestEngine.GetMessage(ex);
    //        //if (ex.InnerException != null)
    //        //    return GetMessage(ex.InnerException);
    //        //return ex.Message;
    //    }

    //    public static bool IsFailed(this Exception ex)
    //    {
    //        return TestEngine.IsFailed(ex);
    //        //return IsExpectedException(ex, "AssertFailedException");
    //    }
    //    public static bool IsInconclusive(this Exception ex)
    //    {
    //        return TestEngine.IsInconclusive(ex);
    //        //return IsExpectedException(ex, "AssertInconclusiveException");
    //    }
    //    public static bool IsExpectedException(this Exception ex, string expectedException)
    //    {
    //        return TestEngine.IsExpectedException(ex, expectedException);
    //        //if (ex.InnerException != null && expectedException != ex.GetType().Name)
    //        //    return IsExpectedException(ex.InnerException, expectedException);
    //        //else if (expectedException == ex.GetType().Name)
    //        //    return true;
    //        //else
    //        //    return false;
    //    }
    //    public static bool IsExpectedException(this Exception ex, List<string> expectedExceptions)
    //    {
    //        return TestEngine.IsExpectedException(ex, expectedExceptions);
    //        //if (ex.InnerException != null && !expectedExceptions.Contains(ex.GetType().Name))
    //        //    return IsExpectedException(ex.InnerException, expectedExceptions);
    //        //else if (expectedExceptions.Contains(ex.GetType().Name))
    //        //    return true;
    //        //else
    //        //    return false;
    //    }
    //}
}
