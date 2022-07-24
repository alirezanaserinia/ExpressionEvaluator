using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator.Exceptions
{
    public class StartWithOperatorException : Exception
    {
        public StartWithOperatorException(string message) : base(message)
        {
        }
    }
}
