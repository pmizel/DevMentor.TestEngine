using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PerfSuite.Test
{
    public class AssertInconclusiveException : Exception
    {
        private string _message;
        public AssertInconclusiveException()
        {

        }
        public AssertInconclusiveException(string message)
        {
            this._message = message;
        }


        public override string Message
        {
            get
            {
                return _message;
            }
        }
    }
}
