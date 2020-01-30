using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Restaurant.Options
{
    class SubmitRejestration : Option
    {
        private FormField imie;
        private FormField nazwisko;
        private FormField email;
        private FormField pass;
        private FormField passRep;

        public SubmitRejestration(string name, FormField imie, FormField nazwisko, FormField email, FormField pass, FormField passRep)
        {
            this.Name = name;
            this.imie = imie;
            this.nazwisko = nazwisko;
            this.email = email;
            this.pass = pass;
            this.passRep = passRep;
        }
        public override void Execute()
        {
            Repository repository = new Repository();

            if (imie.Value == "" || nazwisko.Value == "" || email.Value == "" || pass.Value == "")
                Console.WriteLine("Wypełnij wszystkie pola formularza!");
            else if (pass.Value != passRep.Value)
                Console.WriteLine("Hasła nie są takie same!");
            else if (!repository.IsEmailFree(email.Value))
                Console.WriteLine("E-mail jest zarezerwowany!");
            else if(repository.AddKlient(imie.Value, nazwisko.Value, email.Value, pass.Value))
            {
                Console.WriteLine("Rejestracja przebiegła pomyślnie!");
            }
            Thread.Sleep(1000);
        }
    }
}
