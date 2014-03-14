using BAG.PerfSuite.Public.TestFramework.DataModels;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace BAG.PerfSuite.Public.TestFramework.Engine
{
    public class Collecotor
    {
        string[] files;
        public Collecotor(params string[] files)
        {
            this.files = files;
        }

        public TestContainer Collect()
        {
            TestContainer container = new TestContainer();
            foreach (var file in files)
            {
                //Console.WriteLine(file);
                var asm = Assembly.LoadFile(Path.GetFullPath(file));
                var types = asm.GetTypes();
                foreach (var type in types)
                {
                    if (type.IsTestClass())
                    {
                        //var instance = Activator.CreateInstance(type);
                        var category = new TestCategory(asm, type);
                        category.Description = type.GetDescription();
                        //Console.WriteLine("Class" + type.Name);
                        var mis = type.GetMethods();
                        foreach (var mi in mis)
                        {
                            var tu = new TestUnit(mi);
                            tu.ExpectedExceptions = mi.GetExpectedExceptions();
                            tu.Description = mi.GetDescription();
                            tu.Enabled = !mi.IsIgnore();
                            //Console.WriteLine(mi.Name);
                            if (mi.IsTestInitialize())
                            {
                                category.TestInitialize.Add(tu);
                            }
                            else if (mi.IsTestCleanup())
                            {
                                category.TestCleanup.Add(tu);
                            }
                            else if (mi.IsTestMethod())
                            {
                                category.Test.Add(tu);
                            }
                        }
                        container.TestCategorys.Add(category);
                    }
                }
            }
            return container;
        }
    }
}
