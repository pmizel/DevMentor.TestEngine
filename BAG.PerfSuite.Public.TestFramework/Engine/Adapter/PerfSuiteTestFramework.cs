using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace BAG.PerfSuite.Public.TestFramework.Engine.Adapter
{
    public class PerfSuiteTestFramework : ITestEngine
    {
        public bool IsTestClass(Type type)
        {
            var attributes = type.GetCustomAttributes();
            foreach (var attribute in attributes)
            {
                if (attribute.GetType().Name == "TestClassAttribute")
                    return true;
            }
            return false;
        }
        public bool IsTestMethod(MethodInfo methodInfo)
        {
            var attributes = methodInfo.GetCustomAttributes();
            foreach (var attribute in attributes)
            {
                if (attribute.GetType().Name == "TestMethodAttribute")
                    return true;
            }
            return false;
        }

        public bool IsTestCleanup(MethodInfo methodInfo)
        {
            var attributes = methodInfo.GetCustomAttributes();
            foreach (var attribute in attributes)
            {
                if (attribute.GetType().Name == "TestCleanupAttribute")
                    return true;
            }
            return false;
        }


        public bool IsTestInitialize(MethodInfo methodInfo)
        {
            var attributes = methodInfo.GetCustomAttributes();
            foreach (var attribute in attributes)
            {
                if (attribute.GetType().Name == "TestInitializeAttribute")
                    return true;
            }
            return false;
        }

        public bool IsIgnore(MethodInfo methodInfo)
        {
            var attributes = methodInfo.GetCustomAttributes();
            foreach (var attribute in attributes)
            {
                if (attribute.GetType().Name == "IgnoreAttribute")
                    return true;
            }
            return false;
        }

        public List<string> GetExpectedExceptions(MethodInfo methodInfo)
        {
            var attributes = methodInfo.GetCustomAttributes();
            List<string> result = new List<string>();
            foreach (var attribute in attributes)
            {
                if (attribute.GetType().Name == "ExpectedExceptionAttribute")
                {
                    try
                    {
                        var type = attribute.GetType().GetProperty("ExceptionType").GetValue(attribute, null) as Type;
                        if (type != null)
                            result.Add(type.Name);
                    }
                    catch (Exception)
                    {
                    }

                }
            }
            return result;
        }

        public string GetDescription(MethodInfo methodInfo)
        {
            var attributes = methodInfo.GetCustomAttributes();
            foreach (var attribute in attributes)
            {
                if (attribute.GetType().Name == "DescriptionAttribute")
                {
                    string result = string.Empty;
                    try
                    {
                        result = attribute.GetType().GetProperty("Description").GetValue(attribute, null) as string;
                    }
                    catch (Exception)
                    {
                    }
                    return result;
                }
            }
            return string.Empty;
        }
        public string GetDescription(Type type)
        {
            var attributes = type.GetCustomAttributes();
            foreach (var attribute in attributes)
            {
                if (attribute.GetType().Name == "DescriptionAttribute")
                {
                    string result = string.Empty;
                    try
                    {
                        result = attribute.GetType().GetProperty("Description").GetValue(attribute, null) as string;
                    }
                    catch (Exception)
                    {
                    }
                    return result;
                }
            }
            return string.Empty;
        }

        public string GetMessage(Exception ex)
        {
            if (ex.InnerException != null)
                return GetMessage(ex.InnerException);

            return ex.Message;
        }

        public bool IsFailed( Exception ex)
        {
            return IsExpectedException(ex, "AssertFailedException");
        }
        public bool IsInconclusive( Exception ex)
        {
            return IsExpectedException(ex, "AssertInconclusiveException");
        }
        public bool IsExpectedException( Exception ex, string expectedException)
        {
            if (ex.InnerException != null && expectedException != ex.GetType().Name)
                return IsExpectedException(ex.InnerException, expectedException);
            else if (expectedException == ex.GetType().Name)
                return true;
            else
                return false;
        }
        public bool IsExpectedException( Exception ex, List<string> expectedExceptions)
        {
            if (ex.InnerException != null && !expectedExceptions.Contains(ex.GetType().Name))
                return IsExpectedException(ex.InnerException, expectedExceptions);
            else if (expectedExceptions.Contains(ex.GetType().Name))
                return true;
            else
                return false;
        }
    }
}
