using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BAG.PerfSuite.Public.TestFramework.DataModels
{
    [Flags]
    public enum TestStatus
    {
        None = 0,
        Passed = 1,
        PassedExpectedException = 2,
        Inconclusive = 4,
        Failed = 8,
        FailedUnhandledException = 16,
        Timeout = 32,
        Aborted = 64
    }

}
