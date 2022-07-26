using Calculator.Business.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator.Business.Interfaces
{
    public interface IExpressionValidator
    {
        public ExprValidationModel CheckExprValidation(string input);
    }
}
