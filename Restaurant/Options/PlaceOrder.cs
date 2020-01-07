using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant
{
    class PlaceOrderOption : Option
    {
        private OptionList submenu;
        public PlaceOrderOption() { }
        public PlaceOrderOption(string name) => this.Name = name;

        public override void Execute()
        {
            
        }
    }
}
