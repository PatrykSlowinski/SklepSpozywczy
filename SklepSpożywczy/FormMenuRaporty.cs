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
    public partial class FormMenuRaporty : Form
    {
        public FormMenuRaporty()
        {
            InitializeComponent();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FormRaport1 form = new FormRaport1();
            form.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            FormRaport2 form = new FormRaport2();
            form.ShowDialog();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            FormRaport3 form = new FormRaport3();
            form.ShowDialog();
        }
    }
}
