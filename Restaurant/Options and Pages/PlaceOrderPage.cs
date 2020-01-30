using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace Restaurant
{
    class PlaceOrderOption : Option
    {
        private DateTime reservation;
        private int tableNr;
        private int dishes;
        private Repository repo;
        private int userID;
        private Potrawa zamowienie;
        public PlaceOrderOption() { }
        public PlaceOrderOption(string name, int user)
        {
            Name = name;
            userID = user;
            repo = new Repository();
        }

        public override void Execute()
        {
            Choice choice;
            string dateInfo;
            string tableInfo;
            string dishesInfo;
            Repository repo = new Repository();
            do
            {
                var date = DatePick();
                reservation = HourPick(date);

                Console.Clear();
                dateInfo = "Data rezerwacji: " + reservation.ToShortDateString() + " w godzinach: " + reservation.ToShortTimeString() + "-" + reservation.AddHours(1).ToShortTimeString();
                Console.WriteLine(dateInfo);
                Console.WriteLine("Zatwierdzić datę rezerwacji?");
                choice = isGood();
                if (choice == Choice.CANCEL) return;

            } while (choice == Choice.NO);
            do
            {
                tableNr = TablePick();
                Console.Clear();
                tableInfo = "Stolik: " + tableNr;
                Console.WriteLine(tableInfo);
                Console.WriteLine("Zatwierdzić wybrany stolik?");
                choice = isGood();
                if (choice == Choice.CANCEL) return;
            } while (choice == Choice.NO);
            do
            {
                dishes = DishesPick();
                zamowienie = repo.GetPotrawy()[dishes - 1];
                dishesInfo = "Zamówiono " + zamowienie.Nazwa + " " + zamowienie.Cena + "zł";
                Console.WriteLine(dishesInfo + "\nZatwierdzić wybraną potrawę?");
                choice = isGood();
                if (choice == Choice.CANCEL) return;
            } while (choice == Choice.NO);

            Console.Clear();
            Console.WriteLine("Zamówienie:");
            Console.WriteLine(dateInfo);
            Console.WriteLine(tableInfo);
            Console.WriteLine(dishesInfo);
            Console.WriteLine("Zamawiam! [T]-Tak/[A]-Anuluj");
            var key = Pick.ForceProperKey(new List<ConsoleKey> { ConsoleKey.T, ConsoleKey.A });
            if (key == ConsoleKey.T)
            {
                if (repo.PlaceOrder(userID, reservation, tableNr, zamowienie))
                {
                    Console.Clear();
                    Console.WriteLine("Sukces! Zamówienie złożone!");
                }
                else
                {
                    Console.Clear();
                    Console.WriteLine("Błąd przy składaniu zamówienia");
                }
                Thread.Sleep(2000);
                return;

            }
            else return;
        }
        private enum Choice
        {
            YES,
            NO,
            CANCEL
        }
        private Choice isGood()
        {
            Console.WriteLine("[T]-Tak/[N]-Nie/[A]-Anuluj");
            var key = Pick.ForceProperKey(new List<ConsoleKey> { ConsoleKey.N, ConsoleKey.T, ConsoleKey.A });
            if (key == ConsoleKey.N)
                return Choice.NO;
            else if (key == ConsoleKey.T)
                return Choice.YES;
            return Choice.CANCEL;
        }

        private DateTime DatePick()
        {
            DateTime today = DateTime.Now;
            DateTime date = today;
            int pick = -1;
            while (!(pick >= 0 && pick <= 7))
            {
                Console.Clear();
                Console.WriteLine("Dzisiaj jest " + today.ToString("dddd"));
                Console.WriteLine("Data rezerwacji:");
                if (today.Hour >= 19)
                    today = today.AddDays(1);

                for (int i = 0; i < 8; i++)
                {
                    date = today.AddDays(i);
                    Console.WriteLine(i + " " + date.ToString("dddd").ToUpper() + " (" + date.ToShortDateString() + ")");
                }
                Console.WriteLine("Podaj dzień rezerwacji (0-7):");
                try
                {
                    pick = int.Parse(Console.ReadLine());
                    date = today.AddDays(pick);
                }
                catch (Exception) { }
            }
            return date;
        }
        private DateTime HourPick(DateTime date)
        {
            int pick = 0;
            DateTime result = date;
            int minReservationHour = 10;
            int LasteReservHour = 21;
            if (date.DayOfYear == DateTime.Now.DayOfYear)
            {
                minReservationHour = DateTime.Now.Hour + 2;
            }
            while (!(pick >= minReservationHour && pick <= LasteReservHour))
            {
                Console.Clear();
                Console.WriteLine("Godzina rezerwacji:");
                for (int godzina = minReservationHour; godzina < LasteReservHour + 1; godzina++)
                {
                    Console.WriteLine(godzina + ":00-" + (godzina + 1) + ":00");
                }
                Console.WriteLine("Podaj godzinę rezerwacji(" + minReservationHour + "-" + LasteReservHour + "):");
                try
                {
                    pick = int.Parse(Console.ReadLine());
                    result = new DateTime(date.Year, date.Month, date.Day, pick, 0, 0);
                }
                catch (Exception) { }

            }
            return result;
        }
        private int TablePick()
        {
            int pick = 0;
            var stoliki = repo.GetStoliki(reservation);
            do
            {
                Console.Clear();
                Console.WriteLine("Dostępne stoliki:");
                foreach (var s in stoliki)
                {
                    Console.WriteLine("Stół nr " + s.Nr_stolika + " osób:" + s.Ilosc_miejsc);
                }
                Console.WriteLine("Proszę wybrać stolik():");
                try
                {
                    pick = int.Parse(Console.ReadLine());

                }
                catch (Exception) { }
            } while (pick <= 0 || pick > stoliki.Count);
            return pick;
        }
        private int DishesPick()
        {
            int pick = 0;
            var dishes = repo.GetPotrawy();
            do
            {
                Console.Clear();
                Console.WriteLine("Menu:");
                int i = 1;
                foreach (var d in dishes)
                {
                    Console.WriteLine(i++ + ". " + d.Nazwa + " " + d.Cena + "zł");
                }
                Console.WriteLine("Proszę wybrać danie():");
                try
                {
                    pick = int.Parse(Console.ReadLine());
                }
                catch (Exception) { }
            } while (!(pick > 0 && pick <= dishes.Count));
            return pick;
        }
    }
}
