﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PerfSuite.Test
{
    [AttributeUsage(AttributeTargets.Method, AllowMultiple = false)]
    public class ClassInitializeAttribute:Attribute
    {
    }
}
