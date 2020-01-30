using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant
{
    public class RezerwacjaDto
    {
        public int Id_rezerwacji { get; set; }
        public string Nazwisko { get; set; }
        public int NumerStolika { get; set; }
        public DateTime RezerwacjaOd { get; set; }
        public Potrawa Potrawa { get; set; }
    }
}
