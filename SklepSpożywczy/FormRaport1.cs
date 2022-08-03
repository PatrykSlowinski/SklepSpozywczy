using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SklepSpożywczy
{
    public partial class FormRaport1 : Form
    {
        public FormRaport1()
        {
            InitializeComponent();
        }

        private void FormRaport1_Load(object sender, EventArgs e)
        {
            foreach(DzieńRoboczy d in DzieńRoboczy.ListaDni)
            {
                if(sumaGodzin(d.Data)<d.ZaplanowanaLiczbaRoboczogodzin)
                {
                    listBox1.Items.Add(d.Data.ToShortDateString() + ", brakujące godziny: " + (d.ZaplanowanaLiczbaRoboczogodzin - sumaGodzin(d.Data)).ToString());
                    
                }
                else if(sumaGodzin(d.Data) > d.ZaplanowanaLiczbaRoboczogodzin)
                {
                    listBox2.Items.Add(d.Data.ToShortDateString() +", godziny ponadplanowe: "+ (sumaGodzin(d.Data) - d.ZaplanowanaLiczbaRoboczogodzin).ToString());
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {

         
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
        
        private int sumaGodzin(DateTime data)
        {
            int suma = 0;
            foreach(ZaplanowanePrzyjściaDoPracy z in ZaplanowanePrzyjściaDoPracy.ListaZaplanowanychPrzyjść)
            {
                if (z.DzieńRoboczy1.Data == data)
                {
                    suma = suma + z.IloscGodzinDoPrzepracowanie;
                }
            }
            return suma;
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
