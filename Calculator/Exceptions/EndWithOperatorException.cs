using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator.Exceptions
{
    public class EndWithOperatorException : Exception
    {
        public EndWithOperatorException(string message) : base(message)
        {
        }
    }
}
