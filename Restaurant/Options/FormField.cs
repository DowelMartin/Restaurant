using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant
{
    class FormField : Option
    {
        private string name;
        private string value;
        private bool hidden = false;
        public override string Name
        {
            get
            {
                if(hidden&&Value!=null)return String.Format("{0,-15} {1,20}",name, Hide(Value));
                return String.Format("{0,-15} {1,20}", name, Value);
            }
            set { name = value; }
        }
        public string Value {
            get
            {
                if (value == null) return "" ;
                return value;
            }
            set { this.value = value;
            }
        }
        public FormField() { }
        public FormField(string name) => this.name = name;
        public FormField(string name, bool hidden)
        {
            this.name = name;
            this.hidden = hidden;
        }

        public override void Execute()
        {
            Console.Clear();
            Console.WriteLine(name + ":");
            Value = Console.ReadLine().Trim();
        }
        public string Hide(string str)
        {

            return string.Concat(Enumerable.Repeat("*", str.Length));
        }
    }
}
