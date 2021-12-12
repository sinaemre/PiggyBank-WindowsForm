using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PiggyBank.Exception_Library
{
    public class KumbaraDolduException : Exception
    {
        public KumbaraDolduException() : base ("Kumbara dolduğu için ekleme yapmazsınız. Kumbarayı salladığınız takdirde ekleme yapabilirsiniz.")
        {

        }
    }
}
