using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant
{
    class OrderOption : IOption
    {
        public string Name { get ; set ; }
        private Menu submenu;

        public void execute()
        {
            Console.WriteLine("Zamów");
            submenu.start();
            
        }
        public OrderOption()
        {
            Name = "Zamów";
            submenu = new Menu("Zamów");
            submenu.add(new Option());
        }
       
        private class Option : IOption //do testów
        {
            public string Name { get ; set; }

            public void execute()
            {
            }
            public Option() { Name = "Option"; }
        }
    }
}
