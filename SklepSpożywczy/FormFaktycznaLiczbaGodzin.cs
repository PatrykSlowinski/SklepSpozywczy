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
    public partial class FormFaktycznaLiczbaGodzin : Form
    {
        ZaplanowanePrzyjściaDoPracy zaplanowane;
        public FormFaktycznaLiczbaGodzin(ZaplanowanePrzyjściaDoPracy z = null)
        {
            InitializeComponent();
            zaplanowane = z;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            zaplanowane.IloscGodzinFaktyczniePrzepracowanych = (int)numericUpDown1.Value;
            DialogResult=DialogResult.OK;
        }

        private void FormFaktycznaLiczbaGodzin_Load(object sender, EventArgs e)
        {
            label1.Text = zaplanowane.Pracownik1.Imię +" "+ zaplanowane.Pracownik1.Nazwisko;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FormFaktycznaLiczbaGodzin_FormClosing(object sender, FormClosingEventArgs e)
        {
            
        }
    }
}
