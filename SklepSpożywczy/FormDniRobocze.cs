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
    public partial class FormDniRobocze : Form
    {
        public FormDniRobocze()
        {
            InitializeComponent();
        }
        void WyświetlListęDniRoboczych()
        {
            dataGridView1.Rows.Clear();
            foreach (DzieńRoboczy dzień in DzieńRoboczy.ListaDni)
            {
                int index = dataGridView1.Rows.Add(dzień.TabelaDlaDGV());
                dataGridView1.Rows[index].Tag = dzień;
            }
        }

        private void FormDniRobocze_Load(object sender, EventArgs e)
        {
            WyświetlListęDniRoboczych();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FormDodajlubEdytujDniRobocze form = new FormDodajlubEdytujDniRobocze();

            form.ShowDialog();
            sortowanie();
            WyświetlListęDniRoboczych();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count != 1) return;
               
            
            DzieńRoboczy d = (DzieńRoboczy)(dataGridView1.SelectedRows[0].Tag);
            FormDodajlubEdytujDniRobocze form = new FormDodajlubEdytujDniRobocze(d);

            form.ShowDialog();
            sortowanie();
            WyświetlListęDniRoboczych();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count != 1)
            {
                MessageBox.Show("Nie zaznaczono żadnego wiersza.");
                return;
            }
            DialogResult dialogResult = MessageBox.Show("Czy na pewno chcesz usunąć pracownika?", "", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                DzieńRoboczy d = (DzieńRoboczy)(dataGridView1.SelectedRows[0].Tag);
                DzieńRoboczy.ListaDni.Remove(d);
                sortowanie();
                WyświetlListęDniRoboczych();
            }
           
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void sortowanie()
        {
            DzieńRoboczy.ListaDni.Sort((x, y) => x.Data.CompareTo(y.Data));
        }
    }
}
