using BAG.PerfSuite.Public.TestFramework.DataModels;
using BAG.PerfSuite.Public.TestFramework.Engine;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;

namespace PerfSuite.Test
{
    class Program
    {
        public static void TestRun()
        {
            //one line execution unit test engine
            var result = new TestExcecutionEngine().Collect().Execute().Container;

            Console.WriteLine(string.Format("Status: Failed: {0} Passed: {1} Inconclusive: {2} ({3}ms)",
               result.FailedCounter(),
               result.PassedCounter(),
               result.InconclusiveCounter(),
               result.ElapsedMilliseconds));

            result.TestCategorys.ForEach(c => c.AllTests.ToList().ForEach(t =>
            {
                Console.WriteLine(string.Format("{0} [{1}] {2} ({3}ms)",
                     t.Name,
                     t.Status.ToString(),
                     t.Message,
                     t.ElapsedMilliseconds));
            }));

            Console.WriteLine("\r\n\r\npress any key...");
            Console.ReadKey();

            //TestExcecutionEngine engine = new TestExcecutionEngine();
            //var container = engine.Collect().Container;
            //Serialize<TestContainer>(container, "file.xml");
            //engine.Container = Deserialize<TestContainer>("file.xml");
            //var con = engine.Execute().Container;
            //Serialize<TestContainer>(con, "result.xml");

            //Console.ForegroundColor = ConsoleColor.Gray;
            //Console.WriteLine(Environment.NewLine + "ElapsedMilliseconds: " + con.ElapsedMilliseconds + "ms");
            //Console.Write("Status: ");

            //Console.ForegroundColor = ConsoleColor.Red;
            //Console.Write(" Failed: " + con.FailedCounter());

            //Console.ForegroundColor = ConsoleColor.DarkGreen;
            //Console.Write(" Passed: " + con.PassedCounter());

            //Console.ForegroundColor = ConsoleColor.Yellow;
            //Console.Write(" Inconclusive: " + con.InconclusiveCounter());
        }

        static void Main(string[] args)
        {


            TestRun();


            //var location = System.IO.Directory.GetParent(System.Reflection.Assembly.GetExecutingAssembly().Location).FullName;
            //var files = System.IO.Directory.GetFiles(location, "*.dll"); //.Test

            TestExcecutionEngine engine = new TestExcecutionEngine();

            var container = engine.Collect().Container;

            #region Collector
            //TestContainer container = new TestContainer();
            //foreach (var file in files)
            //{
            //    Console.WriteLine(file);
            //    var asm = Assembly.LoadFile(Path.GetFullPath(file));
            //    var types = asm.GetTypes();
            //    foreach (var type in types)
            //    {
            //        if (type.IsTestClass())
            //        {
            //            //var instance = Activator.CreateInstance(type);
            //            var category = new TestCategory(asm, type);
            //            Console.WriteLine("Class" + type.Name);
            //            var mis = type.GetMethods();
            //            foreach (var mi in mis)
            //            {
            //                if (mi.IsTestInitialize())
            //                {
            //                    var tu = new TestUnit(mi);
            //                    tu.ExpectedExceptions = mi.GetExpectedExceptions();
            //                    category.TestInitialize.Add(tu);
            //                    Console.WriteLine(mi.Name);
            //                }
            //                else if (mi.IsTestCleanup())
            //                {
            //                    var tu = new TestUnit(mi);
            //                    tu.ExpectedExceptions = mi.GetExpectedExceptions();
            //                    category.TestCleanup.Add(tu);
            //                    Console.WriteLine(mi.Name);
            //                }
            //                else if (mi.IsTestMethod())
            //                {
            //                    var tu = new TestUnit(mi);
            //                    tu.ExpectedExceptions = mi.GetExpectedExceptions();
            //                    category.Test.Add(tu);
            //                    Console.WriteLine(mi.Name);

            //                }
            //            }
            //            container.TestCategorys.Add(category);
            //        }
            //    }
            //}
            #endregion

            Serialize<TestContainer>(container, "file.xml");
            var con = Deserialize<TestContainer>("file.xml");

            con = engine.Execute().Container;

            #region Executor
            //foreach (var cat in con.TestCategorys)
            //{

            //    var instance = Activator.CreateInstance(cat.Assembly, cat.Type).Unwrap();

            //    foreach (var test in cat.AllTests)
            //    {
            //        Stopwatch sw = Stopwatch.StartNew();
            //        try
            //        {
            //            var mi = instance.GetType().GetMethod(test.MethodInfo);
            //            mi.Invoke(instance, new object[] { });
            //            test.Status = TestStatus.Passed;
            //        }
            //        catch (Exception ex)
            //        {
            //            if (ex.IsInconclusive())
            //                test.Status = TestStatus.Inconclusive;
            //            else if (ex.IsExpectedException(test.ExpectedExceptions))
            //                test.Status = TestStatus.PassedExpectedException;
            //            else if (ex.IsFailed())
            //                test.Status = TestStatus.Failed;
            //            else
            //                test.Status = TestStatus.FailedUnhandledException;

            //            Console.WriteLine(ex.GetMessage());
            //            test.Exception = ex.ToString();
            //            test.Message = ex.GetMessage();

            //        }
            //        sw.Stop();
            //        test.ElapsedMilliseconds = sw.ElapsedMilliseconds;
            //    }
            //}
            #endregion

            #region Output
            Console.Clear();
            foreach (var cat in con.TestCategorys)
            {
                Console.ForegroundColor = ConsoleColor.Gray;
                Console.WriteLine(cat.Name + "(" + cat.Name + ") [" + cat.Type + "]");
                foreach (var test in cat.AllTests)
                {
                    if (test.Status.IsFailed())
                        Console.ForegroundColor = ConsoleColor.Red;
                    else if (test.Status.IsPassed())
                        Console.ForegroundColor = ConsoleColor.DarkGreen;
                    else if (test.Status.IsInconclusive())
                        Console.ForegroundColor = ConsoleColor.Yellow;
                    else
                        Console.ForegroundColor = ConsoleColor.Blue;

                    Console.WriteLine(test.Name + "(" + test.Status.ToString() + ") [" + test.Message + "] - " + test.ElapsedMilliseconds + "ms");
                }
            }

            Console.ForegroundColor = ConsoleColor.Gray;
            Console.WriteLine(Environment.NewLine + "ElapsedMilliseconds: " + con.ElapsedMilliseconds + "ms");
            Console.Write("Status: ");

            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write(" Failed: " + con.FailedCounter());

            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.Write(" Passed: " + con.PassedCounter());

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write(" Inconclusive: " + con.InconclusiveCounter());

            Console.ForegroundColor = ConsoleColor.Gray;

            #endregion
            Console.WriteLine("\r\n\r\npress any key...");
            Console.ReadKey();
        }



        /// <summary>
        /// Serializes the data in the object to the designated file path
        /// </summary>
        /// <typeparam name="T">Type of Object to serialize</typeparam>
        /// <param name="dataToSerialize">Object to serialize</param>
        /// <param name="filePath">FilePath for the XML file</param>
        public static void Serialize<T>(T dataToSerialize, string filePath)
        {
            try
            {
                using (Stream stream = File.Open(filePath, FileMode.Create, FileAccess.ReadWrite))
                {
                    XmlSerializer serializer = new XmlSerializer(typeof(T));
                    XmlTextWriter writer = new XmlTextWriter(stream, Encoding.Default);
                    writer.Formatting = Formatting.Indented;
                    serializer.Serialize(writer, dataToSerialize);
                    writer.Close();
                }
            }
            catch
            {
                throw;
            }
        }

        /// <summary>
        /// Deserializes the data in the XML file into an object
        /// </summary>
        /// <typeparam name="T">Type of object to deserialize</typeparam>
        /// <param name="filePath">FilePath to XML file</param>
        /// <returns>Object containing deserialized data</returns>
        public static T Deserialize<T>(string filePath)
        {
            try
            {
                XmlSerializer serializer = new XmlSerializer(typeof(T));
                T serializedData;

                using (Stream stream = File.Open(filePath, FileMode.Open, FileAccess.Read))
                {
                    serializedData = (T)serializer.Deserialize(stream);
                }

                return serializedData;
            }
            catch
            {
                throw;
            }
        }
    }

    //public static class TestExtensions
    //{
    //    public static bool IsTestClass(this Type type)
    //    {
    //        var attributes = type.GetCustomAttributes();
    //        foreach (var attribute in attributes)
    //        {
    //            if (attribute.GetType().Name == "TestClassAttribute")
    //                return true;
    //        }
    //        return false;
    //    }
    //    public static bool IsTestMethod(this MethodInfo methodInfo)
    //    {
    //        var attributes = methodInfo.GetCustomAttributes();
    //        foreach (var attribute in attributes)
    //        {
    //            if (attribute.GetType().Name == "TestMethodAttribute")
    //                return true;
    //        }
    //        return false;
    //    }

    //    public static bool IsTestCleanup(this MethodInfo methodInfo)
    //    {
    //        var attributes = methodInfo.GetCustomAttributes();
    //        foreach (var attribute in attributes)
    //        {
    //            if (attribute.GetType().Name == "TestCleanupAttribute")
    //                return true;
    //        }
    //        return false;
    //    }


    //    public static bool IsTestInitialize(this MethodInfo methodInfo)
    //    {
    //        var attributes = methodInfo.GetCustomAttributes();
    //        foreach (var attribute in attributes)
    //        {
    //            if (attribute.GetType().Name == "TestInitializeAttribute")
    //                return true;
    //        }
    //        return false;
    //    }

    //    public static List<string> GetExpectedExceptions(this MethodInfo methodInfo)
    //    {
    //        var attributes = methodInfo.GetCustomAttributes();
    //        List<string> result = new List<string>();
    //        foreach (var attribute in attributes)
    //        {
    //            if (attribute.GetType().Name == "ExpectedExceptionAttribute")
    //            {
    //                try
    //                {
    //                    var type = attribute.GetType().GetProperty("ExceptionType").GetValue(attribute, null) as Type;
    //                    if (type != null)
    //                        result.Add(type.Name);
    //                }
    //                catch (Exception)
    //                {
    //                }

    //            }
    //        }
    //        return result;
    //    }

    //    public static string GetDescription(this MethodInfo methodInfo)
    //    {
    //        var attributes = methodInfo.GetCustomAttributes();
    //        foreach (var attribute in attributes)
    //        {
    //            if (attribute.GetType().Name == "DescriptionAttribute")
    //            {
    //                string result = string.Empty;
    //                try
    //                {
    //                    result = attribute.GetType().GetProperty("Description").GetValue(attribute, null) as string;
    //                }
    //                catch (Exception)
    //                {
    //                }
    //                return result;
    //            }
    //        }
    //        return string.Empty;
    //    }
    //    public static string GetDescription(this Type type)
    //    {
    //        var attributes = type.GetCustomAttributes();
    //        foreach (var attribute in attributes)
    //        {
    //            if (attribute.GetType().Name == "DescriptionAttribute")
    //            {
    //                string result = string.Empty;
    //                try
    //                {
    //                    result = attribute.GetType().GetProperty("Description").GetValue(attribute, null) as string;
    //                }
    //                catch (Exception)
    //                {
    //                }
    //                return result;
    //            }
    //        }
    //        return string.Empty;
    //    }

    //    public static string GetMessage(this Exception ex)
    //    {
    //        if (ex.InnerException != null)
    //            return GetMessage(ex.InnerException);

    //        return ex.Message;
    //    }

    //    public static bool IsFailed(this Exception ex)
    //    {
    //        return IsExpectedException(ex, "AssertFailedException");
    //    }
    //    public static bool IsInconclusive(this Exception ex)
    //    {
    //        return IsExpectedException(ex, "AssertInconclusiveException");
    //    }
    //    public static bool IsExpectedException(this Exception ex, string expectedException)
    //    {
    //        if (ex.InnerException != null && expectedException != ex.GetType().Name)
    //            return IsExpectedException(ex.InnerException, expectedException);
    //        else if (expectedException == ex.GetType().Name)
    //            return true;
    //        else
    //            return false;
    //    }
    //    public static bool IsExpectedException(this Exception ex, List<string> expectedExceptions)
    //    {
    //        if (ex.InnerException != null && !expectedExceptions.Contains(ex.GetType().Name))
    //            return IsExpectedException(ex.InnerException, expectedExceptions);
    //        else if (expectedExceptions.Contains(ex.GetType().Name))
    //            return true;
    //        else
    //            return false;
    //    }
    //}
}
