using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant
{
    class RejestrationOption : Option
    {
        private string Imie = "";
        private string Nazwisko = "";
        private string Email = "";
        private string NrTel = "";
        public RejestrationOption() { }
        public RejestrationOption(string name) => this.Name = name;
        public override void Execute()
        {
            OptionList form = new OptionList("Rejestracja");
            var imie = new FormFieldOption("Imię");
            var nazwisko = new FormFieldOption("Nazwisko");
            var email = new FormFieldOption("Email");
            var pass = new FormFieldOption("Hasło",true);
            var passRep = new FormFieldOption("Powtórz hasło",true);
            var nrTel = new FormFieldOption("Numer Telefonu");
            form.Add(imie);
            form.Add(nazwisko);
            form.Add(email);
            form.Add(pass);
            form.Add(passRep);
            form.Add(nrTel);
            form.Add(new Option("Cofnij"));
            form.Start();
        }
    }
}
