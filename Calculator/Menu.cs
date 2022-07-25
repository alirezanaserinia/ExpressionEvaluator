using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator
{
    public class Menu
    {
        private readonly string OptionChoiseText;
        private int ItemIdGenerator;
        public List<MenuItem> Items;

        public Menu(List<string> _ItemNames)
        {
            OptionChoiseText = "Please enter your option number : \n";
            Items = new List<MenuItem>();
            ItemIdGenerator = 1;
            foreach (var itemName in _ItemNames)
            {
                MenuItem item = new MenuItem(itemName, ItemIdGenerator);
                ItemIdGenerator++;
                Items.Add(item);
            }
        }
        public string Show()
        {
            StringBuilder sbuf = new StringBuilder();

            sbuf.Append(OptionChoiseText);

            foreach (var item in Items)
            {
                sbuf.Append(item.GetText());
            }
            sbuf.Append("\n");
            for (int i = 0; i < 10; i++)
            {
                sbuf.Append("---");
            }
            sbuf.Append("\n");
            return sbuf.ToString();
        }

        public void ItemProvider(int userOption)
        {
            var menuItem = Items.FirstOrDefault(n => n.Id == userOption);
            if (menuItem != null)
            {
                
            }
            else
            {

            }

        }

    }
}
