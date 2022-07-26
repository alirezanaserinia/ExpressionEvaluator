using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator.Business.Interfaces
{
    public interface ILogger
    {

        public void Info(string info);
        public void Error(string error);

    }
}
