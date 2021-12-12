using PiggyBank.Abstract;
using PiggyBank.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PiggyBank.Concrete
{
    public class KagitPara : Para,IKatlanabilir
    {
        private readonly Kagitlar kagitlar;
        public KagitPara(Kagitlar kagitlar)
        {
            this.kagitlar = kagitlar;
            DegerleriAt();
        }

        private void DegerleriAt()
        {
            Isim = kagitlar.ToString();
            Deger = (double)kagitlar;
            switch (kagitlar)
            {
                case Kagitlar.BesLira:
                    En = 130;
                    Boy = 64;
                    break;
                case Kagitlar.OnLira:
                    En = 136;
                    Boy = 64;
                    break;
                case Kagitlar.YirmiLira:
                    En = 142;
                    Boy = 68;
                    break;
                case Kagitlar.ElliLira:
                    En = 148;
                    Boy = 68;
                    break;
                case Kagitlar.YüzLira:
                    En = 154;
                    Boy = 72;
                    break;
                case Kagitlar.İkiyüzLira:
                    En = 160;
                    Boy = 72;
                    break;
            }

        }

        public double En { get; set; }
        public double Kalinlik { get; set; } = 0.25;
        public double Boy { get; set; }
        public bool KatlandiMi { get; private set; }
        public override double Hacim
        {
            get { return (En * Boy * Kalinlik) / 1000;  }
        }
        /// <summary>
        /// Parayı katlayınca hacmini azaltır
        /// </summary>
        public void Katla()
        {
            En *= 0.25;
            Kalinlik *= 4;
            KatlandiMi = true;
        }
    }
}
