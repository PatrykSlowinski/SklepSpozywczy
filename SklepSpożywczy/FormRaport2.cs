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
    public partial class FormRaport2 : Form
    {
        public FormRaport2()
        {
            InitializeComponent();
        }

        private void FormRaport2_Load(object sender, EventArgs e)
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
                godzinyprzepracowane();
            }
            else MessageBox.Show("Wybierz pracownika");
        }
        private void godzinyprzepracowane()
        {
            int sumaGodzinMniej = 0;
            int sumaGodzinWięcej = 0;
            int liczbaDniMniej = 0;
            int liczbaDniWięcej = 0;


            foreach (ZaplanowanePrzyjściaDoPracy z in ZaplanowanePrzyjściaDoPracy.ListaZaplanowanychPrzyjść)
            {


                if (listBox1.SelectedItem == z.Pracownik1)
                {
                    if(z.IloscGodzinFaktyczniePrzepracowanych>z.IloscGodzinDoPrzepracowanie)
                    {
                        sumaGodzinWięcej = sumaGodzinWięcej + (z.IloscGodzinFaktyczniePrzepracowanych - z.IloscGodzinDoPrzepracowanie);
                        liczbaDniWięcej++;
                    }
                    else if(z.IloscGodzinFaktyczniePrzepracowanych < z.IloscGodzinDoPrzepracowanie)
                    {
                        sumaGodzinMniej = sumaGodzinMniej + (z.IloscGodzinDoPrzepracowanie - z.IloscGodzinFaktyczniePrzepracowanych);
                        liczbaDniMniej++;
                    }
                    
                }
            }

            MessageBox.Show("Ilość razy kiedy pracownik przepracował mniej godzin niż zaplanowano: "+liczbaDniMniej+" - łącznie brakujących godzin: "+sumaGodzinMniej+". Ilość razy kiedy przepracował więcej godzin niż zaplanowano: "+liczbaDniWięcej+" - łącznie takich godzin: "+sumaGodzinWięcej+".");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
