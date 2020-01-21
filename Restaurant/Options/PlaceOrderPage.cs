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
        public PlaceOrderOption() { }
        public PlaceOrderOption(string name) => this.Name = name;

        public override void Execute()
        {
            Choice choice;
            string dateInfo;
            string tableInfo;
            string dishesInfo;
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
            } while (choice == Choice.NO);
            do
            {
                dishes = DishesPick();
                dishesInfo = "Zamówiono "+dishes;
                Console.WriteLine("Zatwierdzić wybraną potrawę?");
                choice = isGood();
            } while(choice == Choice.NO);

            Console.Clear();
            Console.WriteLine("Zamówienie:");
            Console.WriteLine(dateInfo);
            Console.WriteLine(tableInfo);
            Console.WriteLine(dishesInfo);
            Console.WriteLine("Zamawiam! [T]-Tak/[A]-Anuluj");
            var key = Pick.ForceProperKey(new List<ConsoleKey> { ConsoleKey.T, ConsoleKey.A });
            if (key == ConsoleKey.T)
            {
                //ZAMÓW
                //
                //
                Console.Clear();
                Console.WriteLine("Sukces! Zamówienie złożone!");
                Thread.Sleep(2000);
                
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
            var key = Pick.ForceProperKey(new List<ConsoleKey> { ConsoleKey.N , ConsoleKey.T , ConsoleKey.A});
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
                for (int i = 0; i < 8; i++)
                {
                    date = today.AddDays(i);
                    Console.WriteLine( i + " " + date.ToString("dddd").ToUpper() + " (" + date.ToShortDateString() + ")");
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
        private int TablePick()
        {
            int pick = 0;
            do
            { 
                Console.Clear();
                Console.WriteLine("Dostępne stoliki:");
                // wypisanie numerów i ilości miejsc
                //
                Console.WriteLine("Proszę wybrać stolik():");
                try
                {
                    pick = int.Parse(Console.ReadLine());

                }
                catch (Exception) { }
            } while (pick <= 0);
            return pick;
        }
        private int DishesPick()
        {
            int pick = 0;
            do
            {
                Console.Clear();
                Console.WriteLine("Menu:");
                // wypisanie jedzenia i cen
                //
                Console.WriteLine("Proszę wybrać danie():");
                try
                {
                    pick = int.Parse(Console.ReadLine());
                }
                catch (Exception) { }
            } while (pick <= 0);
            return pick;
        }
        private DateTime HourPick(DateTime date)
        {
            int pick = 0;
            DateTime result = date;
            while (!(pick >= 10 && pick <= 21))
            {
                Console.Clear();
                Console.WriteLine("Godzina rezerwacji:");
                //wypisanie dostępnych godzin
                //
                for (int godzina = 10; godzina < 22; godzina++)
                {
                    Console.WriteLine(godzina + ":00-" + (godzina+1) + ":00");
                }
                Console.WriteLine("Podaj godzinę rezerwacji(10-21):");
                try
                {
                    pick = int.Parse(Console.ReadLine());
                    result = new DateTime(date.Year, date.Month, date.Day, pick, 0, 0);
                }
                catch (Exception) { }

            }
            return result;
        }
    }
}
