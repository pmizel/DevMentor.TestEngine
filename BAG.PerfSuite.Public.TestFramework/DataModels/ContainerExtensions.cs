using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BAG.PerfSuite.Public.TestFramework.DataModels
{
    public static class ContainerExtensions
    {
        public static int Counter(this TestContainer container, TestStatus status)
        {
            return container.TestCategorys.Sum(cat => cat.AllTests.Sum(t => status.IsSet(t.Status) ? 1 : 0));
        }

        public static int Counter(this TestContainer container)
        {
            return container.TestCategorys.Sum(cat => cat.AllTests.Count());
        }

        public static int PassedCounter(this TestContainer container)
        {
            return container.Counter(TestStatus.Passed | TestStatus.PassedExpectedException);
        }
        public static int InconclusiveCounter(this TestContainer container)
        {
            return container.Counter(TestStatus.Inconclusive);
        }
        public static int FailedCounter(this TestContainer container)
        {
            return container.Counter(TestStatus.Failed | TestStatus.FailedUnhandledException);
        }

        public static bool IsSet(this TestStatus sender, TestStatus status)
        {
            return (sender & status) > 0;
        }

        public static bool IsFailed(this TestStatus status)
        {
            return status == TestStatus.Failed || status == TestStatus.FailedUnhandledException;
        }
        public static bool IsPassed(this TestStatus status)
        {
            return status == TestStatus.Passed || status == TestStatus.PassedExpectedException;
        }
        public static bool IsInconclusive(this TestStatus status)
        {
            return status == TestStatus.Inconclusive;
        }
    }
}
