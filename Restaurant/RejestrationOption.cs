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

        public RejestrationOption()
        {
            Name = "Rejestracja";
        }
        public override void Execute()
        {
            OptionList form = new OptionList("Rejestracja");
            var imie = new FormFieldOption("Imię");
            var nazwisko = new FormFieldOption("Nazwisko");
            var email = new FormFieldOption("Email");
            var nrTel = new FormFieldOption("Numer Telefonu");
            form.Add(imie);
            form.Add(nazwisko);
            form.Add(email);
            form.Add(nrTel);
            form.Add(new Option("Cofnij"));
            form.Start();
        }
    }
}
