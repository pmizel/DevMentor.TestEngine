DevMentor.TestEngine
====================

Fast and parallel testengine to support different test frameworks

NUnit, VisualStudio UnitTest, MSTest, PerfSuite.Test ...


###one line of code
```cs
            var result = new TestExcecutionEngine().Collect().Execute().Container;
```
```cs
            //output
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
            //Status: Failed: 4 Passed: 5 Inconclusive: 2 (1202ms)
            //MethodInconclusive [Inconclusive] Assert.Inconclusive <My Comment> (456ms)
            //...
            
```

###Collector
```cs
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
```

###Executor
```cs
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
```




