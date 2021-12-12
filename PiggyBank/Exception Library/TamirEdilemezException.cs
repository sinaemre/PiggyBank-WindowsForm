using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PiggyBank.Exception_Library
{
    public class TamirEdilemezException : Exception
    {
        public TamirEdilemezException() : base("Kumbara daha önce tamir edildiği için tekrar tamir edilemez")
        {

        }
    }
}
