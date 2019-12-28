using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant
{
    interface IOption
    {
        String Name { get; set; }
        void execute();
    }
}
