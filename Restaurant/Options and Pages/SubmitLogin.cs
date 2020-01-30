using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant
{
    class SubmitLoginOption : Option
    {
        private FormField email;
        private FormField password;

        public SubmitLoginOption() { }
        public SubmitLoginOption(string name) => this.Name = name;
        public SubmitLoginOption(string name, FormField login, FormField pass)
        {
            Name = name;
            email = login;
            password = pass;
        }

        public override void Execute()
        {
            Repository repo = new Repository();
            if (repo.CheckCredentials(email.Value, password.Value))
            {
                Menu menu = new Menu(repo.GetUserID(email.Value));
            }
            else
                Console.WriteLine("Logowanie nie powiodło się");
        }
    }
}
