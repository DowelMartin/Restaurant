using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace Restaurant
{
    public class CsvLibrary
    {
        public static List<List<string>> Import(string path)  
        {
            var result = new List<List<string>>();
            using (var sr = new StreamReader(path))
            {
                string line;
                while ((line=sr.ReadLine()) != null)
                {
                    result.Add(new List<string>(line.Trim().Split(',')));
                } 
            }
            return result;
        }
        public static void Export(List<List<string>> data,string path)
        {
            using (var output = new StreamWriter(path, false))
            {
                string line;
                foreach (var items in data)
                {
                    line = string.Join(",", items);
                    output.WriteLine(line);
                }
            }
        }

    }
}
