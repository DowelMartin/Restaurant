using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Restaurant;

namespace RestaurantManager
{
    class Program
    {
        static void Main(string[] args)
        {
            OptionList menu = new OptionList("System zarządzania");
            menu.Add(new DishesPage("Dania"));
            menu.Add(new OrdersPage("Zamówienia"));
            menu.Add(new Exit("Wyjście"));
            menu.Start();
        }
    }
}
