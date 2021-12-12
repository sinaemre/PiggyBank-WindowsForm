using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PiggyBank.Exception_Library
{
    public class KumbaraKirildiException : Exception
    {
        public KumbaraKirildiException() : base("Kumbara kırıldığı için işlem yapamazsınız. Tamir edin.")
        {
        }
    }
}
