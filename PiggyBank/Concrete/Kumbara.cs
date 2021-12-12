using PiggyBank.Abstract;
using PiggyBank.Exception_Library;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PiggyBank.Concrete
{
    public class Kumbara
    {
        Random rnd = new Random();
        public Kumbara()
        {
            Paralar = new List<Para>();
        }
        private List<Para> Paralar { get; set; }
        public bool KirildiMi { get; set; } = false; // Burayı aslında bir saaçla da tutabilirdim ama iki tane boolean değer tercih ettim.
        public bool TamirEdildiMi { get; set; } = false;
        public bool BosMu => Paralar.Count < 0;
        public double KumbaraHacmi { get; private set; } = 100; // 10cm * 5cm * 2cm ortalama kumbara ölçülerine göre alınmış değer
        public double DolanHacim { get; private set; }
        public double DolulukOranı => DolanHacim / KumbaraHacmi;
        private double ToplamPara { get {return Paralar.Sum(x => x.Deger); } }
        
        /// <summary>
        /// Kumbaradaki toplam parayı gösterir
        /// </summary>
        /// <returns>double ToplamPara</returns>
        /// <exception cref="ParaGosterilemezException"></exception>
        public double ToplamParayiGöster()
        {

            if (!KirildiMi)
            {
                throw new ParaGosterilemezException();
            }
            else
            {
                return ToplamPara;
            }
        }
        public List<Para> Break()
        {
            if (BosMu == true)
            {
                throw new KumbaraBosException();
            }
            if (KirildiMi == false)
            {
                KirildiMi = true;
                DolanHacim = 0;
                return Paralar;
            }
            else
            {
                throw new KumbaraKirildiException();
            }

        }
        /// <summary>
        /// Kumbara kırıldıktan sonra tamir eder
        /// </summary>
        /// <exception cref="TamirEdilemezException"></exception>
        public void TamirEt()
        {
            if (KirildiMi == true && TamirEdildiMi == false)
            {
                KirildiMi = false;
                TamirEdildiMi = true;
                DolanHacim = 0;
                Paralar.Clear();
            }
            else if (KirildiMi == false)
                throw new TamirEdilemezException();


        }
        /// <summary>
        /// Kumbaraya para eklememizi sağlar
        /// </summary>
        /// <param name="para"></param>
        /// <exception cref="KumbaraKirildiException"></exception>
        /// <exception cref="KumbaraDolduException"></exception>
        /// <exception cref="BanknotKatlanmadiException"></exception>
        public void ParaEkle(Para para)
        {
            if (KirildiMi == true) // Kırılma kontrolü
            {
                throw new KumbaraKirildiException();
            }
            if (DolanHacim < KumbaraHacmi) // Hacim kontrolü
            {
                if (KumbaraHacmi - DolanHacim < para.Hacim)
                {
                    throw new KumbaraDolduException();
                }

                if (para is KagitPara) // kağıt para ekleme
                {
                    KagitPara kagitPara = (KagitPara)para;
                    if (kagitPara.KatlandiMi == true)
                    {
                        Paralar.Add(kagitPara);
                        DolanHacim += kagitPara.Hacim + ((kagitPara.Hacim * rnd.Next(25, 76)) / 100);
                    }
                    else
                        throw new BanknotKatlanmadiException();
                }
                else // Bozuk para ekleme
                {
                    Paralar.Add(para);
                    DolanHacim += para.Hacim + ((para.Hacim * rnd.Next(25, 76)) / 100);
                }
            }
            else
            {
                throw new KumbaraDolduException();
            }

        }
        /// <summary>
        /// Kumbarayı sallayınca paraların hacmini azaltır.
        /// </summary>
        /// <exception cref="KumbaraKirildiException"></exception>
        /// <exception cref="KumbaraBosException"></exception>
        public void Shake()
        {
            if (KirildiMi == true)
            {
                throw new KumbaraKirildiException();
            }
            if (BosMu == true)
            {
                throw new KumbaraBosException();
            }
            else
            {
                DolanHacim = 0;
                DolanHacim += Paralar.Sum(x => x.Hacim) * 1.25;
            }
        }

    }
}
