﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator.Exceptions
{
    public class ConsecutiveOperatorsException : Exception
    {
        public ConsecutiveOperatorsException(string message) : base(message)
        {
        }
    }
}