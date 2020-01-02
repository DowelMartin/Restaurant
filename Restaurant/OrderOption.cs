using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant
{
    class OrderOption : Option
    {
        private OptionList submenu;
        public OrderOption() { }
        public OrderOption(string name) => this.Name = name;

        public override void Execute()
        {
            
        }
    }
}
