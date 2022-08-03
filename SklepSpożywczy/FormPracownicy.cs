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
    public partial class FormPracownicy : Form
    {
        
        public FormPracownicy()
        {
            InitializeComponent();
        }
        void WyświetlListęPracowników()
        {
            dataGridView1.Rows.Clear();
            foreach (Pracownik pracownik in Pracownik.ListaPracowników)
            {
                int index = dataGridView1.Rows.Add(pracownik.TabelaDlaDGV());
                dataGridView1.Rows[index].Tag = pracownik;
            }
        }
        
        private void button1_Click(object sender, EventArgs e)
        {
            
            
            FormDodajlubEdytujPracownika form = new FormDodajlubEdytujPracownika();
            
            form.ShowDialog();
            WyświetlListęPracowników();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            
            if (dataGridView1.SelectedRows.Count != 1)
                return;
            
            Pracownik p = (Pracownik)(dataGridView1.SelectedRows[0].Tag);
            FormDodajlubEdytujPracownika form = new FormDodajlubEdytujPracownika(p);
            
            form.ShowDialog();
            WyświetlListęPracowników();
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
                Pracownik p = (Pracownik)(dataGridView1.SelectedRows[0].Tag);
                Pracownik.ListaPracowników.Remove(p);
                WyświetlListęPracowników();

            }
        }
        private void FormPracownicy_Load(object sender, EventArgs e)
        {
            WyświetlListęPracowników();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Close();

        }
    }
}
