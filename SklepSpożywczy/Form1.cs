using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace SklepSpożywczy
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            string path = Application.StartupPath.ToString();
            WindowState = FormWindowState.Normal; 
            DialogResult result = MessageBox.Show("Czy otworzyć przykładowe dane?", "Pobieranie danych", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes) 
            {

                try
                {
                    FileStream file = new FileStream(Application.StartupPath + "\\PrzykładoweDane.appr", FileMode.Open, FileAccess.Read);
                    BinaryFormatter bf = new BinaryFormatter();
                    Pracownik.ListaPracowników = (List<Pracownik>)bf.Deserialize(file);
                    DzieńRoboczy.ListaDni = (List<DzieńRoboczy>)bf.Deserialize(file);
                    ZaplanowanePrzyjściaDoPracy.ListaZaplanowanychPrzyjść = (List<ZaplanowanePrzyjściaDoPracy>)bf.Deserialize(file);

                    file.Close();
                    referencja();


                }
                catch (Exception ex)
                {
                    MessageBox.Show("Nie udało się odczytać danych z pliku:\n" + ex.Message, "Błąd");
                }
            }

            DialogResult result2 = MessageBox.Show("Czy otworzyć dane z pliku?", "Pobieranie danych", MessageBoxButtons.YesNo);
            if (result2 == DialogResult.No)
                return;
            else

            {
                OpenFileDialog ofd = new OpenFileDialog();
                ofd.FileName = String.Empty;
                
                try
                {
                    ofd.Filter = "Pliki aplikacji SKLEP (*.appr)|*.appr";
                    if (ofd.ShowDialog() != DialogResult.OK)
                        return;

                    FileStream file = new FileStream(ofd.FileName,FileMode.Open, FileAccess.Read);
                    BinaryFormatter bf = new BinaryFormatter();
                    Pracownik.ListaPracowników = (List<Pracownik>)bf.Deserialize(file);
                    DzieńRoboczy.ListaDni = (List<DzieńRoboczy>)bf.Deserialize(file);
                    ZaplanowanePrzyjściaDoPracy.ListaZaplanowanychPrzyjść = (List<ZaplanowanePrzyjściaDoPracy>)bf.Deserialize(file);

                    file.Close();
                    referencja();


                }
                catch (Exception ex)
                {
                    MessageBox.Show("Nie udało się odczytać danych z pliku:\n" + ofd.FileName + "\n" + ex.Message, "Błąd");
                }
            }
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FormPracownicy form = new FormPracownicy();
            form.ShowDialog();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            FormDniRobocze form = new FormDniRobocze();
            form.ShowDialog();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            FormZaplanowanePrzyjścia form = new FormZaplanowanePrzyjścia();
            form.ShowDialog();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            try
            {
               
                DialogResult result = MessageBox.Show("Czy zapisać dane do pliku?", "Zamykanie aplikacji", MessageBoxButtons.YesNoCancel);
                if (result == DialogResult.No)
                    return;
                if (result == DialogResult.Cancel)
                {
                    e.Cancel = true;
                    return;
                }

                sfd.Filter = "Pliki aplikacji SKLEP (*.appr)|*.appr";
                if (sfd.ShowDialog() != DialogResult.OK)
                {
                    e.Cancel = true;
                    return;
                }

                FileStream file = new FileStream(sfd.FileName, FileMode.Create, FileAccess.ReadWrite);
                BinaryFormatter bf = new BinaryFormatter();
                bf.Serialize(file, Pracownik.ListaPracowników);
                bf.Serialize(file, DzieńRoboczy.ListaDni);
                bf.Serialize(file, ZaplanowanePrzyjściaDoPracy.ListaZaplanowanychPrzyjść);
                file.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Nie udało się zapisać danych do pliku:\n" + sfd.FileName + "\n" + ex.Message, "Błąd");
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            FormMenuRaporty form = new FormMenuRaporty();
            form.ShowDialog();
        }

        private void referencja()
        {
            foreach(ZaplanowanePrzyjściaDoPracy z in ZaplanowanePrzyjściaDoPracy.ListaZaplanowanychPrzyjść)
            {
                foreach(Pracownik pracownik in Pracownik.ListaPracowników)
                {
                    if(pracownik.Pesel==z.Pracownik1.Pesel)
                    {
                        z.Pracownik1 = pracownik;
                    }
                        
                }
                foreach(DzieńRoboczy d in DzieńRoboczy.ListaDni)
                {
                    if(d.Data.ToShortDateString()==z.DzieńRoboczy1.Data.ToShortDateString())
                    {
                        z.DzieńRoboczy1 = d;
                    }
                }
            }

        }

        private void button5_Click_1(object sender, EventArgs e)
        {
            int maxsuma = 0;
            int suma = 0;
            foreach (ZaplanowanePrzyjściaDoPracy z in ZaplanowanePrzyjściaDoPracy.ListaZaplanowanychPrzyjść)
            {
                foreach (ZaplanowanePrzyjściaDoPracy zap in ZaplanowanePrzyjściaDoPracy.ListaZaplanowanychPrzyjść)
                {
                    if (zap.DzieńRoboczy1 == z.DzieńRoboczy1)
                    {
                        suma = suma + zap.IloscGodzinFaktyczniePrzepracowanych;
                       
                    }
                }
                List<ZaplanowanePrzyjściaDoPracy> lista = new List<ZaplanowanePrzyjściaDoPracy>();
                if (suma > maxsuma)
                {
                    lista.Clear();
                    listBox1.Items.Clear();
                    maxsuma = suma;
                    label1.Text = z.DzieńRoboczy1.Data.ToShortDateString() +" "+ maxsuma.ToString()+" godzin";
                    foreach (ZaplanowanePrzyjściaDoPracy za in ZaplanowanePrzyjściaDoPracy.ListaZaplanowanychPrzyjść)
                    {
                        
                        if (za.DzieńRoboczy1 == z.DzieńRoboczy1)
                        {
                            listBox1.Items.Add(za.Pracownik1);
                            lista.Add(za);

                        }
                        
                    }
                    for (int i = 0; i < lista.Count - 1; i++)
                    {
                        if (lista[i].IloscGodzinFaktyczniePrzepracowanych < lista[i + 1].IloscGodzinFaktyczniePrzepracowanych)
                        {
                            ZaplanowanePrzyjściaDoPracy d = lista[i];
                            lista[i] = lista[i + 1];
                            lista[i + 1] = d;
                            i = -1;
                        }
                    }
                    listBox1.Items.Clear();
                    foreach (ZaplanowanePrzyjściaDoPracy zaplanowane in lista)
                        listBox1.Items.Add(zaplanowane.Pracownik1.ToString() + zaplanowane.IloscGodzinFaktyczniePrzepracowanych.ToString());




                }
                suma = 0;
            }
            
        }
    }
}
