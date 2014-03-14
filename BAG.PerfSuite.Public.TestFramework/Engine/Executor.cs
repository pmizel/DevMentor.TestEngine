using BAG.PerfSuite.Public.TestFramework.DataModels;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace BAG.PerfSuite.Public.TestFramework.Engine
{
    public class Executor
    {
        public Executor()
        {

        }

        public TestContainer Execute(TestContainer container)
        {
            Stopwatch swContainer = Stopwatch.StartNew();
            //foreach (var cat in con.TestCategorys)
            container.TestCategorys.AsParallel().ForAll(cat =>
            {
                var instance = Activator.CreateInstance(cat.Assembly, cat.Type).Unwrap();
                Stopwatch swCategory = Stopwatch.StartNew();
                //foreach (var test in cat.AllTests)
                cat.AllTests.AsParallel().ForAll(test =>
                {
                    if (test.Enabled)
                    {
                        Stopwatch swTest = Stopwatch.StartNew();
                        try
                        {
                            var mi = instance.GetType().GetMethod(test.MethodInfo);
                            mi.Invoke(instance, new object[] { });
                            test.Status = TestStatus.Passed;
                        }
                        catch (Exception ex)
                        {
                            if (ex.IsInconclusive())
                                test.Status = TestStatus.Inconclusive;
                            else if (ex.IsExpectedException(test.ExpectedExceptions))
                                test.Status = TestStatus.PassedExpectedException;
                            else if (ex.IsFailed())
                                test.Status = TestStatus.Failed;
                            else
                                test.Status = TestStatus.FailedUnhandledException;

                            //Console.WriteLine(ex.GetMessage());
                            test.Exception = ex.ToString();
                            test.Message = ex.GetMessage();
                        }
                        swTest.Stop();
                        test.ElapsedMilliseconds = swTest.ElapsedMilliseconds;
                        test.Thread = Thread.CurrentThread.ManagedThreadId.ToString();
                    }
                });
                swCategory.Stop();
                cat.ElapsedMilliseconds = swCategory.ElapsedMilliseconds;

            });
            swContainer.Stop();
            container.ElapsedMilliseconds = swContainer.ElapsedMilliseconds;
            return container;
        }
    }
}
