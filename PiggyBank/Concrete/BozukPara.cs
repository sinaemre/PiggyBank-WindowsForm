using PiggyBank.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PiggyBank.Concrete
{
    public class BozukPara : Para
    {
        private readonly Bozuklar bozukPara;
        public BozukPara(Bozuklar bozukPara)
        {
            this.bozukPara = bozukPara;
            DegerleriAt();
        }

        private void DegerleriAt()
        {
            Isim = bozukPara.ToString();
            Deger = (double)bozukPara / 100;
            switch (bozukPara)
            {
                case Bozuklar.BirKurus:
                    Yukseklik = 1.35;
                    Cap = 16.35;
                    break;
                case Bozuklar.BesKurus:
                    Yukseklik = 1.65;
                    Cap = 17.5;
                    break;
                case Bozuklar.OnKurus:
                    Yukseklik = 1.65;
                    Cap = 18.5;
                    break;
                case Bozuklar.YirmiBesKurus:
                    Yukseklik = 1.65;
                    Cap = 20.5;
                    break;
                case Bozuklar.ElliKurus:
                    Yukseklik = 1.9;
                    Cap = 23.85;
                    break;
                case Bozuklar.BirLira:
                    Yukseklik = 1.9;
                    Cap = 26.15;
                    break;
            }
        }

        public const double Pi = 3.14;
        public double Cap { get; private set; }
        public double Yukseklik { get; private set; }

        public override double Hacim
        {
            get { return ((Pi * (Math.Pow( ( Cap/2 ),2) ) ) * Yukseklik) / 1000; }
        }
    }
}
