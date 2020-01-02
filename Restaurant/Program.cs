using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant
{
    class Program
    {
        static void Main(string[] args)
        {
            OptionList menu = new OptionList("Menu");
            menu.Add(new LoginOption("Logowanie"));
            menu.Add(new RejestrationOption());
            menu.Add(new Option("Wyjście"));
            menu.Start();
        }
    }
}
