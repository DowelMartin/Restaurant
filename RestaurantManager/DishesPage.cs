using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Restaurant;
namespace RestaurantManager
{
    class DishesPage : Option
    {
        public DishesPage(string name) : base(name)
        {
        }
        public override void Execute()
        {
            int pick = 0;
            Console.WriteLine("Wybierz operację: [D]-Usuń/[M]-Modyfikuj/[I]-Importuj/[E]-Eksportuj");
            var operation = Pick.ForceProperKey(new List<ConsoleKey> { ConsoleKey.D, ConsoleKey.M, ConsoleKey.I, ConsoleKey.E });
            if(operation == ConsoleKey.E)
            {
                //CsvLibrary.Export("Dania_Restauracja.csv");
            }
            else if(operation == ConsoleKey.I)
            {
                CsvLibrary.Import("Dania_Restauracja.csv");
            }
            else
            {
                string message = "Dania w karcie:" +
                     //wypisać liste dań i ich ceny
                     "Wybierz pozycje z listy: ";
                Pick.SelectFromList(message, 10); //ILOść DAŃ
            }
            

        }
    }
}
