using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator
{
    public class MenuItem
    {
        public readonly int Id;
        public readonly string Name;

        public MenuItem(string _Name, int _Id)
        {
            Id = _Id;
            Name = _Name;
        }

        public string GetText()
        {
            StringBuilder sbuf = new StringBuilder();
            sbuf.Append(Id.ToString());
            sbuf.Append(". ");
            sbuf.Append(Name);
            sbuf.Append("\n");
            return sbuf.ToString();
        }
    }
}
