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
    public partial class FormRaport3 : Form
    {
        public FormRaport3()
        {
            InitializeComponent();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void FormRaport3_Load(object sender, EventArgs e)
        {
            foreach (Pracownik pracownik in Pracownik.ListaPracowników)
            {

                listBox1.Items.Add(pracownik);
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {

            if (listBox1.SelectedItem != null)
            {
                należność();
            }
            else MessageBox.Show("Wybierz pracownika");
        }
        private void należność()
        {
            int suma = 0;
            int naleznosc = 0;
            
            
            foreach(ZaplanowanePrzyjściaDoPracy z in ZaplanowanePrzyjściaDoPracy.ListaZaplanowanychPrzyjść)
            {
                

                if (listBox1.SelectedItem==z.Pracownik1)
                {
                    
                    suma = suma + z.IloscGodzinFaktyczniePrzepracowanych;
                    naleznosc = naleznosc + (z.Pracownik1.StawkaGodzinowa * z.IloscGodzinFaktyczniePrzepracowanych);
                }
            }

            MessageBox.Show("Pracownik przepracował faktycznie " + suma + " godzin. Należy mu się " + naleznosc + " zł.");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
