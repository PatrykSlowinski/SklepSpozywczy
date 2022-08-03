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
    public partial class FormZaplanowanePrzyjścia : Form
    {
        public FormZaplanowanePrzyjścia()
        {
            InitializeComponent();
        }
        void WyświetlListęZaplanowanych()
        {
            dataGridView1.Rows.Clear();
            foreach (ZaplanowanePrzyjściaDoPracy zaplanowane in ZaplanowanePrzyjściaDoPracy.ListaZaplanowanychPrzyjść)
            {
                int index = dataGridView1.Rows.Add(zaplanowane.TabelaDlaDGV());
                dataGridView1.Rows[index].Tag = zaplanowane;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FormDodajLubEdytujZaplanowane form = new FormDodajLubEdytujZaplanowane();

            form.ShowDialog();
            sortowanie();
            WyświetlListęZaplanowanych();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count != 1)
                return;

            ZaplanowanePrzyjściaDoPracy z = (ZaplanowanePrzyjściaDoPracy)(dataGridView1.SelectedRows[0].Tag);
            FormDodajLubEdytujZaplanowane form = new FormDodajLubEdytujZaplanowane(z);

            form.ShowDialog();
            sortowanie();
            WyświetlListęZaplanowanych();
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
                ZaplanowanePrzyjściaDoPracy z = (ZaplanowanePrzyjściaDoPracy)(dataGridView1.SelectedRows[0].Tag);
                ZaplanowanePrzyjściaDoPracy.ListaZaplanowanychPrzyjść.Remove(z);
                sortowanie();
                WyświetlListęZaplanowanych();

            }

        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count != 1)
                return;
            ZaplanowanePrzyjściaDoPracy z = (ZaplanowanePrzyjściaDoPracy)(dataGridView1.SelectedRows[0].Tag);
            FormFaktycznaLiczbaGodzin form = new FormFaktycznaLiczbaGodzin(z);

            form.ShowDialog();
            sortowanie();
            WyświetlListęZaplanowanych();
        }

        private void FormZaplanowanePrzyjścia_Load(object sender, EventArgs e)
        {
            WyświetlListęZaplanowanych();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        private void sortowanie()
        {
            ZaplanowanePrzyjściaDoPracy.ListaZaplanowanychPrzyjść.Sort((x, y) => x.DzieńRoboczy1.Data.CompareTo(y.DzieńRoboczy1.Data));
        }
    }
}
