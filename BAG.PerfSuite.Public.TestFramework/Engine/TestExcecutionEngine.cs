using BAG.PerfSuite.Public.TestFramework.DataModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BAG.PerfSuite.Public.TestFramework.Engine
{
    public class TestExcecutionEngine
    {
        Collecotor collector;
        Executor executor;
        public TestContainer Container { get; set; }


        public TestExcecutionEngine()
        {
            var location = System.IO.Directory.GetParent(System.Reflection.Assembly.GetExecutingAssembly().Location).FullName;
            var files = System.IO.Directory.GetFiles(location, "*.dll");

            collector = new Collecotor(files);
            executor = new Executor();
        }

        public TestExcecutionEngine(string location, string filter = "*.dll")
        {
            var files = System.IO.Directory.GetFiles(location, filter);

            collector = new Collecotor(files);
            executor = new Executor();
        }

        public TestExcecutionEngine(params string[] files)
        {
            collector = new Collecotor(files);
            executor = new Executor();
        }



        public TestExcecutionEngine Collect()
        {
            Container = collector.Collect();
            return this;
        }

        public TestExcecutionEngine Execute()
        {
            if (Container == null)
                throw new ArgumentNullException("call Collect method first");
            //Async || Parallel
            Container = this.executor.Execute(Container);
            return this;
        }
    }
}
