using Restaurant.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant
{
    class RejestrationOption : Option
    {
        public RejestrationOption(string name) => this.Name = name;
        public override void Execute()
        {
            OptionList form = new OptionList("Rejestracja");
            var imie = new FormField("Imię");
            var nazwisko = new FormField("Nazwisko");
            var email = new FormField("Email");
            var pass = new FormField("Hasło", true);
            var passRep = new FormField("Powtórz hasło", true);
            var nrTel = new FormField("Numer Telefonu");
            form.Add(imie);
            form.Add(nazwisko);
            form.Add(email);
            form.Add(pass);
            form.Add(passRep);
            form.Add(nrTel);
            form.Add(new SubmitRejestration("Zarejestruj", imie, nazwisko, email, pass, passRep, nrTel));
            form.Add(new Exit("Cofnij"));
            form.Start();
        }
    }
}
