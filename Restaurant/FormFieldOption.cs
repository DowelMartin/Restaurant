using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant
{
    class FormFieldOption:Option
    {
        private string name;
        public override string Name
        {
            get
            {
                return name+": "+Value ;
            }
            set { name = value; }
        }
        public string Value { set; get; }
        public FormFieldOption(string name)
        {
            this.name = name;
        }

        public override void Execute()
        {
            Console.Clear();
            Console.WriteLine(name + ":");
            Value = Console.ReadLine();
        }
    }
}
