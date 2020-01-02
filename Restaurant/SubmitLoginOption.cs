using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant
{
    class SubmitLoginOption : Option
    {
        private string email;
        private string password;

        public SubmitLoginOption() { }
        public SubmitLoginOption(string name) => this.Name = name;
        public SubmitLoginOption(string name,string login,string pass)
        {
            Name = name;
            email = login;
            password = pass;
        }

        public override void Execute()
        {
            Console.WriteLine("Brak w bazie");
            Task.Delay(1000);
        }
    }
}
