using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant
{
    class Menu
    {
        private List<IOption> options;
        private String title;
        public Menu(String title):this()
        {
            this.title = title;
        }
        public Menu()
        {
            options = new List<IOption>();
        }
        public void add(IOption option)
        {
            options.Add(option);
        }
        public void start()
        {
            add(new ExitOption());
            int select = 0;
            ConsoleKeyInfo key;
            
            do
            {
                Console.Clear();
                writeMenu(select);
                key = Console.ReadKey(true);
                switch (key.Key)
                {
                    case ConsoleKey.DownArrow:
                        select = select == options.Count - 1 ? select : select + 1;
                        break;
                    case ConsoleKey.UpArrow:
                        select = select == 0 ? select : select - 1;
                        break;
                    case ConsoleKey.Enter:
                        options[select].execute();
                        if(select==options.Count-1)return;
                        break;
                }
            } while (true);
        }
        private void writeMenu(int selected)
        {
            if(title!="")
            Console.WriteLine("----------------------------{0}----------------------------", title);
            for(int i=0;i<options.Count;i++)
            {
                String output = (i+1) + ". " + options[i].Name;
                if (i == selected)
                    consoleSelect(output);
                else
                    Console.WriteLine(output);
            }
        }
        private void consoleSelect(String s)
        {
            Console.BackgroundColor = ConsoleColor.White;
            Console.WriteLine(s);
            Console.BackgroundColor = ConsoleColor.Black;
        }
        private class ExitOption : IOption
        {
            public string Name { get; set; }
            public void execute(){}
            public ExitOption() { Name = "Exit"; }
        }
    }
}
