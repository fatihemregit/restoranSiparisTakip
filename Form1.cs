using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RestoranSiparisTakip
{
    public partial class Form1 : Form
    {

        int toplamTutar = 0;
        int adanaadet = 0;
        Dictionary<string, int> siparisAdetleri = new Dictionary<string, int>();
        Dictionary<string, int> siparisOldValue = new Dictionary<string, int>();
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //adet varsayılan değer tanımlama
            siparisAdetleri["Adana kebap"] = 0;
            siparisAdetleri["sis Kebap"] = 0;
            //old value varsayılan değer tanımlama
            siparisOldValue["Adana kebap"] = 0;
            siparisOldValue["sis Kebap"] = 0;



        }

        private int siparisUcretiniOgren(String siparisIsmi)
        {
            //dict kullanarak tüm sipariş fiyatlarını al adetleride dictde tut
            // adetleri dict te tutmadan önce basit bir değişkende tut ve test et sonra dict e geçir
            //burada jsondan sipariş ismine göre sipariş ücretini getiren kodlar yazılacak
            return 1;
        }
        private void toplamtutarHesapla(bool plusorminus)
        {
            foreach (var siparisadet in siparisAdetleri)
            {
                if (plusorminus == true) {
                    //değer arttır
                    toplamTutar += Convert.ToInt16(siparisadet.Value) * siparisUcretiniOgren($"{siparisadet.Key}");
                }
                else if (plusorminus == false)
                {
                    //değer azalt
                    toplamTutar -= Convert.ToInt16(siparisadet.Value) * siparisUcretiniOgren($"{siparisadet.Key}");
                }
            }
            label3.Text = $"{toplamTutar}";
        }

        int oldvalue;
        private void numericUpdownValueChanged(object sender, EventArgs e, string siparisIsmi)
        {
            //numeric up down değeri değiştinde çalışacak fonksiyon
            //numericUpdownChanged main function
            NumericUpDown numericUpDown = (NumericUpDown)sender;
            int fark = Convert.ToInt16(numericUpDown.Value) - siparisOldValue[siparisIsmi];
            if (fark > 0)
            {
                //değer artmış
                siparisAdetleri[siparisIsmi] = Convert.ToInt16(fark);
                toplamtutarHesapla(true);
            }
            else if (fark < 0)
            {
                siparisAdetleri[siparisIsmi] = Convert.ToInt16(Math.Abs(fark));
                toplamtutarHesapla(false);
            }
            siparisOldValue[siparisIsmi] = Convert.ToInt16(numericUpDown.Value);

        }
        private void clickToCheckBox(object sender, EventArgs e,NumericUpDown numer)
        {
            //checkbox a tıklandığında çalışacak fonksiyon
            //checkbox clicked main function
            //niye NumericUpDown parametresi istedik?
            /*
             Çünkü numericupdown ı tıklamaya göre açıp kapatacağız
             */
            //controller ve değişken tanımlamaları
            CheckBox checkBox  = (CheckBox) sender;
            if (checkBox.Checked == true)
            {
                //eğer checkbox işaretli ise çalışacak yer
                numer.Visible = true;
            }
            else
            {
                //eğer checkbox işaretli değil ise çalışacak yer
                numer.Visible = false;
            }


        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            //adana kebab checkbox function
            clickToCheckBox(sender, e, adananum);

        }
        private void adananum_ValueChanged(object sender, EventArgs e)
        {
            // Adana kebap numericupdown function
            numericUpdownValueChanged(sender, e, "Adana kebap");
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            clickToCheckBox(sender, e, sisnum);
        }

        private void sisnum_ValueChanged(object sender, EventArgs e)
        {
            numericUpdownValueChanged(sender, e, "sis Kebap");
        }
    }
}
