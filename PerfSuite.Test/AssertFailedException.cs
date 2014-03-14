using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PerfSuite.Test
{
    public class AssertFailedException : Exception
    {
        private string _message;
        public AssertFailedException()
        {

        }        
        public AssertFailedException(string message)
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
