using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant
{
    internal class LoginOption : Option
    {
        public LoginOption() { }
        public LoginOption(string name) => this.Name = name;
        public override void Execute()
        {
            var loginForm = new OptionList("Logowanie");
            var mail = new FormFieldOption("E-mail");
            var pass = new FormFieldOption("Hasło",true);
            loginForm.Add(mail);
            loginForm.Add(pass);
            loginForm.Add(new SubmitLoginOption("Zaloguj", mail.Value, pass.Value));
            loginForm.Add(new Option("Cofnij"));
            loginForm.Start();
        }
    }
}
