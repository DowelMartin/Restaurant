using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant
{
    class OptionList
    {
        private List<Option> options;
        private string title;
        public OptionList(string title):this()
        {
            this.title = title;
        }
        public OptionList()
        {
            options = new List<Option>();
        }
        public void Add(Option option)
        {
            options.Add(option);
        }
        public void Start()
        {
            int backlight = 0;
            ConsoleKeyInfo key;
            
            do
            {
                Console.Clear();
                WriteOptions(backlight);
                key = Console.ReadKey(true);
                switch (key.Key)
                {
                    case ConsoleKey.DownArrow:
                        backlight = backlight == options.Count - 1 ? backlight : backlight + 1;
                        break;
                    case ConsoleKey.UpArrow:
                        backlight = backlight == 0 ? backlight : backlight - 1;
                        break;
                    case ConsoleKey.Enter:
                        options[backlight].Execute();
                        if(backlight==options.Count-1)return;
                        break;
                }
            } while (true);
        }
        private void WriteOptions(int backlight)
        {
            if(title!="")
            Console.WriteLine("{0,20}", title);
            for(int i=0;i<options.Count;i++)
            {
                string output =  options[i].Name;
                if (i == backlight)
                    ConsoleSelect(output);
                else
                    Console.WriteLine(output);
            }
        }
        public static void ConsoleSelect(string s,ConsoleColor fgr=ConsoleColor.Black,ConsoleColor bgr=ConsoleColor.White)
        {
            Console.BackgroundColor = bgr;
            Console.ForegroundColor = fgr;
            Console.WriteLine(s);
            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.Gray;
        }
    }
}
