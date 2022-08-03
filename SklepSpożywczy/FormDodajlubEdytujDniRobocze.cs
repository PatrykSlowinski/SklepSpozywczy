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
    public partial class FormDodajlubEdytujDniRobocze : Form
    {
        DzieńRoboczy dzieńRoboczy;
        public FormDodajlubEdytujDniRobocze(DzieńRoboczy d=null)
        {
            InitializeComponent();
            dzieńRoboczy = d;
            if (d == null)
            {
                Text = "Dodaj Dzień Roboczy";

            }
            else
            {
                Text = "Edytuj Dzień Roboczy";
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (dzieńRoboczy == null)
            {

                dzieńRoboczy = new DzieńRoboczy();
                if (czyDzieńNieZostałJeszczeZaplanowany(dateTimePicker1.Value,dzieńRoboczy) == true)
                {
                    dzieńRoboczy.Data = dateTimePicker1.Value;
                    dzieńRoboczy.ZaplanowanaLiczbaRoboczogodzin = (int)numericUpDown1.Value;
                    DzieńRoboczy.ListaDni.Add(dzieńRoboczy);
                    DialogResult = DialogResult.OK;
                }
            }
            else
            {
                if (czyDzieńNieZostałJeszczeZaplanowany(dateTimePicker1.Value,dzieńRoboczy) == true)
                {
                    dzieńRoboczy.Data = dateTimePicker1.Value;
                    dzieńRoboczy.ZaplanowanaLiczbaRoboczogodzin = (int)numericUpDown1.Value;
                    DialogResult = DialogResult.OK;
                }
            }
            

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FormDodajlubEdytujDniRobocze_Load(object sender, EventArgs e)
        {
            if (dzieńRoboczy != null)
            {
                dateTimePicker1.Value = dzieńRoboczy.Data;
                numericUpDown1.Value = (decimal)dzieńRoboczy.ZaplanowanaLiczbaRoboczogodzin;
                
            }
        }
        private bool czyDzieńNieZostałJeszczeZaplanowany(DateTime data,DzieńRoboczy dzień)
        {
            foreach(DzieńRoboczy d in DzieńRoboczy.ListaDni)
            {
                if(data.ToShortDateString()==d.Data.ToShortDateString())
                {
                    if (dzień != d)
                    {
                        MessageBox.Show("Podany dzień został już zaplanowany.");
                        return false;
                    }
                    
                }
            }
            return true;
        }
        
    }
}
