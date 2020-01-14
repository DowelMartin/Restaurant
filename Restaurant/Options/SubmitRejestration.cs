using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Restaurant.Options
{
    class SubmitRejestration:Option
    {
        private FormField imie;
        private FormField nazwisko;
        private FormField email;
        private FormField pass;
        private FormField passRep;
        private FormField nrTel;

        public SubmitRejestration(string name, FormField imie, FormField nazwisko, FormField email, FormField pass, FormField passRep, FormField nrTel)
        {
            this.Name = name;
            this.imie = imie;
            this.nazwisko = nazwisko;
            this.email = email;
            this.pass = pass;
            this.passRep = passRep;
            this.nrTel = nrTel;
        }
        public override void Execute()
        {
            
            if(imie.Value=="" || nazwisko.Value == ""|| email.Value == "" || pass.Value == "" || nrTel.Value == "" )
                Console.WriteLine("Wypełnij wszystkie pola formularza!");
            else if (pass.Value != passRep.Value )
                Console.WriteLine("Hasła nie są takie same!");
            else
                Console.WriteLine("Zarejestrowano");
            Thread.Sleep(1000);
        }
    }
}
