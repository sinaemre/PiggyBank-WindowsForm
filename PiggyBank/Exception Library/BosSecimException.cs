using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PiggyBank.Exception_Library
{
    public class BosSecimException : Exception
    {
        public BosSecimException() : base("Lütfen bir seçim yapınız")
        {

        }
    }
}
