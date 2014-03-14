using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PerfSuite.Test
{
    public class ExpectedExceptionAttribute : Attribute
    {

        public ExpectedExceptionAttribute(Type exceptionType)
        {
            this.ExceptionType = exceptionType;
        }

        public ExpectedExceptionAttribute(Type exceptionType, string noExceptionMessage)
        {
            this.ExceptionType = exceptionType;
        }

        public bool AllowDerivedTypes { get; set; }

        public Type ExceptionType { get; private set; }
        protected string NoExceptionMessage { get { return string.Empty; } }
        protected void Verify(Exception exception)
        {

        }
    }
}
