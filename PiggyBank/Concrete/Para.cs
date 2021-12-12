using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PiggyBank.Concrete
{
    public abstract class Para
    {
        public string Isim { get; set; }
        public double Deger  { get; set; }
        public abstract double Hacim { get; }
    }
}
