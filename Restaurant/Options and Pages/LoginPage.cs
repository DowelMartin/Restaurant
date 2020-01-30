using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant
{
    internal class LoginPage : Option
    {
        public LoginPage() { }
        public LoginPage(string name) => this.Name = name;
        public override void Execute()
        {
            var loginForm = new OptionList("Logowanie");
            var mail = new FormField("E-mail");
            var pass = new FormField("Hasło",true);
            loginForm.Add(mail);
            loginForm.Add(pass);
            loginForm.Add(new SubmitLoginOption("Zaloguj", mail, pass));
            loginForm.Add(new Exit("Cofnij"));
            loginForm.Start();
        }
    }
}
