using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant
{
    class Option
    {
        public virtual string Name { get; set; }
        public Option() { }
        public Option(string name) => this.Name = name;
        public virtual void Execute()
        {

        }
    }
}
