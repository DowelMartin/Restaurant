using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant
{
    public class Pick
    {
        public static ConsoleKey ForceProperKey(List<ConsoleKey> list)
        {
            ConsoleKey key;
            do
            {
                key = Console.ReadKey(true).Key;
            } while (list.IndexOf(key) == -1);
            return key;
        }

        public static int SelectFromList(string message,int upperRange)
        {
            return SelectFromList(message,1,upperRange);
        }

        public static int SelectFromList(string message,int lowerRange, int upperRange)
        {
            int pick=lowerRange-1;
            do
            {
                Console.Clear();
                Console.WriteLine(message);
                try
                {
                    pick = int.Parse(Console.ReadLine());
                }
                catch (Exception e) { }

            } while (!(pick>=lowerRange && pick<=upperRange));
            return pick;

        }
    }
}
