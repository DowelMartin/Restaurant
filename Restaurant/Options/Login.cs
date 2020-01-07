using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant
{
    internal class Login : Option
    {
        public Login() { }
        public Login(string name) => this.Name = name;
        public override void Execute()
        {
            var loginForm = new OptionList("Logowanie");
            var mail = new FormField("E-mail");
            var pass = new FormField("Hasło",true);
            loginForm.Add(mail);
            loginForm.Add(pass);
            loginForm.Add(new SubmitLoginOption("Zaloguj", mail.Value, pass.Value));
            loginForm.Add(new Exit("Cofnij"));
            loginForm.Start();
        }
    }
}
