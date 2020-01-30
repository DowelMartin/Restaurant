using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant.Options
{
    class CheckOrdersPage : Option
    {
        private int userID;
        public CheckOrdersPage(string name, int user)
        {
            Name = name;
            userID = user;
        }
        public override void Execute()
        {
            Repository repo = new Repository();
            int pick = 0;
            var list = repo.GetRezerwacjaDtos(userID);
            do
            {
                Console.Clear();
                Console.WriteLine("Moje zamówienia:");
                int i = 1;
                foreach (var rez in list)
                {
                    Console.WriteLine("{0}. {1} cena:{2}zł stolik:{3} data:{4}", i++, rez.Potrawa.Nazwa, rez.Potrawa.Cena, rez.NumerStolika, rez.RezerwacjaOd.Date);
                }
                Console.WriteLine("Wybierz zamówienie, które chcesz anulować lub wprowadź \'X\', żeby powrócić do menu");
                string input = Console.ReadLine();
                if (input.ToUpper() == "X") return;
                try
                {
                    pick = int.Parse(input);
                }
                catch (Exception) { }
            } while (pick <= 0 || pick > list.Count);
            repo.CancelReservation(list[pick-1].Id_rezerwacji);

        }
    }
}
