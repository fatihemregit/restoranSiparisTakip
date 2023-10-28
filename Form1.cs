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
        

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
        }

        private int siparisUcretiniOgren(String siparisIsmi)
        {
            //burada jsondan sipariş ismine göre sipariş ücretini getiren kodlar yazılacak
            return 1;
        }

        private void clickToCheckBox(object sender, EventArgs e,NumericUpDown numer)
        {
            CheckBox checkBox = (CheckBox)sender;
            string siparisIsmi = checkBox.Text;
            //checkbox checklendiğinde fiyatın artma ve azaltma işlemleri
            if (checkBox.Checked)
            {
                numer.Visible = true;
                numer.Value = 1;
                //toplamTutar += Convert.ToInt16(numer.Value) * siparisUcretiniOgren(siparisIsmi);

            }
            else
            {
                numer.Visible = false;

                //toplamTutar -= siparisUcretiniOgren(siparisIsmi);
            }
        }

        private void tutarHesapla(bool eklemeDurumu,int eklenecekFiyat,int adet) {
            if (eklemeDurumu) {
                toplamTutar += eklenecekFiyat * adet;
            }
            else
            {
                toplamTutar -= eklenecekFiyat * adet;
            }
            label3.Text = $": {toplamTutar}";
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            //adana kebab
            NumericUpDown  adana = adananum;


            clickToCheckBox(sender, e,adana);
        }

        decimal oldValue;

        private void adananum_ValueChanged(object sender, EventArgs e)
        {
            NumericUpDown numericUpDown = (NumericUpDown)sender;
            if(numericUpDown.Value == 0){
                numericUpDown.Visible = false;
                toplamTutar = 0;
                label3.Text = $": {toplamTutar}";
            }
            else
            {

                numericUpDown.Visible = true;
                int fark = (int)numericUpDown.Value - (int)oldValue;
                if(fark < 0)
                {
                    //değer azalmış
                    tutarHesapla(false, siparisUcretiniOgren("Adana Kebab"), Math.Abs(fark));

                }
                else
                {
                    //değer artmış
                    tutarHesapla(true, siparisUcretiniOgren("Adana Kebab"), fark);
                }

                //if (numericUpDown.Value > oldValue)
                //{
                //    //değer artmış
                //    int fark = (int)numericUpDown.Value - (int)oldValue;
                //    tutarHesapla(true, siparisUcretiniOgren("Adana Kebab"),fark);
                //}
                //else
                //{
                //    //değer azalmış
                //    int fark = (int)oldValue - (int)numericUpDown.Value;
                //    tutarHesapla(false, siparisUcretiniOgren("Adana Kebab"),fark);
                //}
                oldValue = numericUpDown.Value;
            }
            



        }
    }
}
