using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator.Exceptions
{
    public class DivideByZeroException : Exception
    {
        public DivideByZeroException(string message) : base(message)
        {
        }
    }
}

