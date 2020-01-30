using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Restaurant
{
    public static class Pick
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
                catch (Exception) { }

            } while (!(pick>=lowerRange && pick<=upperRange));
            return pick;

        }
        public static string SelectFile(string filter="All files(*)|*.*")
        {
            string path = "";
            Thread t = new Thread((ThreadStart)(() => {
                OpenFileDialog saveFileDialog1 = new OpenFileDialog();

                saveFileDialog1.Filter = filter;
                saveFileDialog1.FilterIndex = 2;
                saveFileDialog1.RestoreDirectory = true;


                if (saveFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    path = saveFileDialog1.FileName;
                }
            }));
            t.SetApartmentState(ApartmentState.STA);
            t.Start();
            t.Join();
            return path;
        }
       /* public static string SelectFolder()
        {
            string path = "";
            Thread t = new Thread((ThreadStart)(() => {
                var FolderBrowserDialog = new FolderBrowserDialog();
                if (FolderBrowserDialog.ShowDialog() == DialogResult.OK)
                {
                    path = FolderBrowserDialog.SelectedPath;
                }
            }));
            t.SetApartmentState(ApartmentState.STA);
            t.Start();
            t.Join();
            return path;
        }*/
    }
}
