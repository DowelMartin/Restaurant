﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant
{
    class Program
    {
        static void Main(string[] args)
        {
            Menu menu = new Menu("Menu");
            menu.add(new OrderOption());
            menu.start();
        }
    }
}
