using System;
using System.Collections.Generic;
using System.Threading;
using Restaurant;


namespace RestaurantManager
{
    class DishesPage : Option
    {
        private Repository repository = new Repository();
        public DishesPage(string name) : base(name)
        {
        }
        public override void Execute()
        {
            Console.Clear();

            string message = "Dania w karcie:\n";
            int i = 1;
            foreach (Potrawa p in repository.GetPotrawy())
            {
                message += string.Format("{0}. {1} {2} zł\n", i++, p.Nazwa, p.Cena);
            }

            Console.WriteLine(message+"Wybierz operację: [A]-Dodaj/[D]-Usuń/[I]-Importuj/[E]-Eksportuj,[X]-Wyjdź");
            var operation = Pick.ForceProperKey(new List<ConsoleKey> { ConsoleKey.D, ConsoleKey.A, ConsoleKey.I, ConsoleKey.E, ConsoleKey.X });

            //---------------------------Export------------------------

            if (operation == ConsoleKey.E)
            {
                var potrawy = repository.GetPotrawy();
                var export = new List<List<string>>();
                foreach (var p in potrawy)
                {
                    export.Add(new List<string> { p.Nazwa, string.Format("{0}", p.Cena) });
                }
                CsvLibrary.Export(export, "Restauracja_Dania.csv");
            }

            //---------------------------Import------------------------

            else if (operation == ConsoleKey.I)
            {
                string path = Pick.SelectFile("CSV Files (*.csv)|*.csv");
                try
                {
                    var importResult = CsvLibrary.Import(path);
                    foreach (List<string> l in importResult)
                    {
                        var cena = double.Parse(l[1]);
                        repository.AddPotrawa(l[0], cena);
                    }
                    Console.WriteLine("Pomyślnie zaimportowano dane!");
                }
                catch (Exception)
                {
                    Console.Error.WriteLine("Błąd importu!!!");
                }
                Thread.Sleep(2000);
            }
            //---------------------------Dodawanie------------------------
            else if (operation == ConsoleKey.A)
            {
                Console.Clear();
                Console.WriteLine("Podaj nazwę dania: ");
                var nazwa = Console.ReadLine();
                Console.WriteLine("Podaj cenę: ");
                try
                {
                    var cena = double.Parse(Console.ReadLine());
                    repository.AddPotrawa(nazwa, cena);
                }
                catch (Exception)
                {
                    Console.WriteLine("Zły format ceny!");
                    Thread.Sleep(1000);
                }

            }
            //---------------------------Usuwanie------------------------
            else if (operation== ConsoleKey.D)
            {
                message += "Wybierz numer z listy: ";
                var pick = Pick.SelectFromList(message, i - 1);

                var potrawy = repository.GetPotrawy();
                repository.DelPotrawa(potrawy[pick - 1].Id_potrawy);

            }

        }
    }
}
