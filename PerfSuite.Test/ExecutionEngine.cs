using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PerfSuite.Test
{
    public class ExecutionEngine
    {
        TestExecuter executer;
        public ExecutionEngine(TestExecuter executer)
        {
            this.executer = executer;
        }

        public void Execute()
        {
            executer.Execute();
        }
    }

    public class TestExecuter
    {
        public TestExecuter()
        {

        }

        public void Execute()
        {

        }
    }
}
