﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant.Options
{
    class CheckOrdersPage:Option
    {
        private int userID;
        public CheckOrdersPage(string name,int user)
        {
            Name = name;
            userID = user;
        }
        public override void Execute()
        {
            int pick = 0;
            do
            {
                Console.Clear();
                Console.WriteLine("Moje zamówienia:");
                // wypisz zamówienia
                Console.WriteLine("Wybierz zamówienie, które chcesz anulować lub wprowadź \'X\', żeby powrócić do menu");
                string input = Console.ReadLine();
                if (input.ToUpper() == "X") return;
                try
                {
                    pick = int.Parse(input);
                }
                catch (Exception) { }

                //anuluj zamówienie
            } while (pick <= 0);


        }
    }
}