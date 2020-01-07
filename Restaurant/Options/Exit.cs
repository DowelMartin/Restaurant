using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant
{
    class Exit:Option
    {
        
        public Exit() { }
        public Exit(string name) => this.Name = name;
        public override void Execute()
        {

        }
    }
}
