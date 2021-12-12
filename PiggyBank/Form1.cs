using MetroFramework.Forms;
using PiggyBank.Concrete;
using PiggyBank.Enums;
using PiggyBank.Exception_Library;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PiggyBank
{
    public partial class Form1 : MetroForm
    {
        public Kumbara kumbara = new Kumbara();
        public List<Para> paralar = new List<Para>();
        Para para1; // Kağıt para için
        Para para2; // Bozuk para için
        public Form1()
        {
            InitializeComponent();
            ParalariYukle();
            pnlBoyali.Height = 0; // başlangıç olarak 0 alıyoruz
        }
        /// <summary>
        /// Paraları combobox lara yükler
        /// </summary>
        private void ParalariYukle()
        {
            foreach (var item in Enum.GetValues(typeof(Kagitlar)))
            {
                cmbKagit.Items.Add(item);
            }

            foreach (var item in Enum.GetValues(typeof(Bozuklar)))
            {
                cmbBozuk.Items.Add(item);
            }
        }

        private void cmbKagit_SelectedIndexChanged(object sender, EventArgs e)
        {

            if (cmbKagit.SelectedIndex < 1)
            {
                return;
            }
            else if (cmbKagit.SelectedItem is Kagitlar)
            {
                para1 = new KagitPara((Kagitlar)cmbKagit.SelectedItem);
            }
            btnKatla.Visible = true;
        }

        private void cmbBozuk_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbBozuk.SelectedIndex < 1)
            {
                return;
            }
            if (cmbBozuk.SelectedItem is Bozuklar)
            {
                para2 = new BozukPara((Bozuklar)cmbBozuk.SelectedItem);
            }

        }

        private void btnEkle_Click_1(object sender, EventArgs e)
        {
            if (cmbBozuk.SelectedIndex < 0 && cmbKagit.SelectedIndex < 0)
            {
                try
                {
                    throw new BosSecimException();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    return;
                }
            }

            try
            {
                if (para1 == null)
                {
                    kumbara.ParaEkle(para2);
                }
                else if (para2 == null)
                {
                    kumbara.ParaEkle(para1);
                }
                else
                {
                    kumbara.ParaEkle(para2);
                    kumbara.ParaEkle(para1);

                }

                FormuResetle();
                PaneliBoya();
                btnKatla.Visible = false;
                btnTamirEt.Visible = true;
                btnKir.Visible = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnKatla_Click_1(object sender, EventArgs e)
        {
            if (cmbKagit.SelectedIndex < 1)
            {
                try
                {
                    throw new KatlanacakParaSecmemeException();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    return;
                }
            }
            KagitPara kagitPara = (KagitPara)para1;
            try
            {
                kagitPara.Katla();
                MessageBox.Show("Paranız katlandı");
                btnKatla.Visible = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnSalla_Click_1(object sender, EventArgs e)
        {
            try
            {
                kumbara.Shake();
                PaneliBoya();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnKir_Click_1(object sender, EventArgs e)
        {
            dgvKirilanKumbara.Visible = true;
            paralar = kumbara.Break();
            dgvKirilanKumbara.DataSource = paralar;
            lblParalar.Text = $"{kumbara.ToplamParayiGöster():C2}";
            btnKir.Visible = false;

        }

        private void btnTamirEt_Click(object sender, EventArgs e)
        {
            try
            {
                kumbara.TamirEt();
                if (kumbara.TamirEdildiMi && kumbara.KirildiMi)
                {
                    MessageBox.Show("Kumbara daha önce tamir edildiği yada kırılmadığı için tamir edilemez"); // Hata fırlatınca kapama işlemi olmadığı için Messagebox ile verdim.
                    MessageBox.Show($"Kumbarada ki toplam paranız {kumbara.ToplamParayiGöster():C2}"); //Kumbara ikinci kez kırılıdğında bakiyeyi label da göstermez. Programdan çıkarken messagebox ta gösterir.
                    this.Close();
                }
                dgvKirilanKumbara.DataSource = null;
                dgvKirilanKumbara.Visible = false;
                lblParalar.Visible = false;
                FormuResetle();
                PaneliBoya();
                btnTamirEt.Visible = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        /// <summary>
        /// Formu resetler
        /// </summary>
        private void FormuResetle()
        {
            cmbKagit.SelectedIndex = -1;
            cmbBozuk.SelectedIndex = -1;

        }
        /// <summary>
        /// Paneli doluluk oranına göre artırır
        /// </summary>
        private void PaneliBoya()
        {
            pnlBoyali.Height = (int)(pnlKumbara.Height * kumbara.DolulukOranı);

        }
    }
}
