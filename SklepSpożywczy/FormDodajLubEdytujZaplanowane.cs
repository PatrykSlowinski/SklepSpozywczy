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
    public partial class FormDodajLubEdytujZaplanowane : Form
    {
        ZaplanowanePrzyjściaDoPracy zaplanowane;
        public FormDodajLubEdytujZaplanowane(ZaplanowanePrzyjściaDoPracy z=null)
        { 
            InitializeComponent();
            zaplanowane = z;
            if(z==null)
            {
                Text = "Zaplanuj dzień pracownika";
            }
            else
            {
                Text = "Edytuj dzień pracownika";
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (zaplanowane == null)
            {
                if (listBox1.SelectedItem != null)
                {
                    if (comboBox1.SelectedItem != null)
                    {
                        
                        if (czyPracownikNieJestWpisany2Razy ()== true)
                        {
                            zaplanowane = new ZaplanowanePrzyjściaDoPracy();
                            zaplanowane.DzieńRoboczy1 = (DzieńRoboczy)listBox1.SelectedItem;
                            zaplanowane.Pracownik1 = (Pracownik)comboBox1.SelectedItem;
                            zaplanowane.IloscGodzinDoPrzepracowanie = (int)numericUpDown1.Value;
                            if (zaplanowane.DzieńRoboczy1.Data < zaplanowane.Pracownik1.DataRozpoczęciaPracy)
                            {
                                MessageBox.Show("Pracownik nie może pracować przed datą zatrudnienia go.");
                                return;
                            }
                            else
                            {
                                ZaplanowanePrzyjściaDoPracy.ListaZaplanowanychPrzyjść.Add(zaplanowane);
                                DialogResult = DialogResult.OK;
                            }
                        }
                    }
                    else MessageBox.Show("Wybierz pracownika.");
                }
                else MessageBox.Show("Wybierz datę.");
            }
            else
            {
                if (czyPracownikNieJestWpisany2Razy() == true)
                {
                    zaplanowane.DzieńRoboczy1 = (DzieńRoboczy)listBox1.SelectedItem;
                    zaplanowane.Pracownik1 = (Pracownik)comboBox1.SelectedItem;
                    zaplanowane.IloscGodzinDoPrzepracowanie = (int)numericUpDown1.Value;
                    if (zaplanowane.DzieńRoboczy1.Data < zaplanowane.Pracownik1.DataRozpoczęciaPracy)
                    {
                        MessageBox.Show("Pracownik nie może pracować przed datą zatrudnienia go.");
                        return;
                    }
                    else DialogResult = DialogResult.OK;
                }
            }
            
        }

        private void FormDodajLubEdytujZaplanowane_Load(object sender, EventArgs e)
        {

            foreach (Pracownik pracownik in Pracownik.ListaPracowników)
            {

                comboBox1.Items.Add(pracownik);
            }
            foreach (DzieńRoboczy dzień in DzieńRoboczy.ListaDni)
            {
                listBox1.Items.Add(dzień);
            }
            if (zaplanowane != null)
            {
                comboBox1.SelectedItem = zaplanowane.Pracownik1;
                listBox1.SelectedItem = zaplanowane.DzieńRoboczy1;
                
                numericUpDown1.Value = (decimal)zaplanowane.IloscGodzinDoPrzepracowanie;

            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        private bool czyPracownikNieJestWpisany2Razy()
        {
            foreach(ZaplanowanePrzyjściaDoPracy z in ZaplanowanePrzyjściaDoPracy.ListaZaplanowanychPrzyjść)
            {
                if((listBox1.SelectedItem==z.DzieńRoboczy1)&&(comboBox1.SelectedItem==z.Pracownik1))
                {
                    if (zaplanowane != z)
                    {
                        MessageBox.Show("Ten pracownik jest już wpisany na ten dzień.");
                        return false;
                    }
                }
            }
            return true;
        }
        
        
        
    }
}
