using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PerfSuite.Test
{
    [AttributeUsage(AttributeTargets.Method, AllowMultiple = false)]
    public class DescriptionAttribute : Attribute
    {
        public DescriptionAttribute()
        {

        }
        public DescriptionAttribute(string description)
        {
            this.Description = description;
        }
        public string Description { get; set; }
    }
}
