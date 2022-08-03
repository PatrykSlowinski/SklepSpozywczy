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
    public partial class FormDodajlubEdytujPracownika : Form
    {
        Pracownik pracownik;
        public FormDodajlubEdytujPracownika(Pracownik p=null)
        {
            InitializeComponent();
            pracownik = p;
            if(p==null)
            {
                Text = "Dodaj Pracownika";
                
            }
            else
            {
                Text = "Edytuj Pracownika";
            }
        }
        
        private void button1_Click(object sender, EventArgs e)
        {
            if (pracownik== null)
            {
                
                Pracownik pracownik = new Pracownik();

                bool czyZgodność = warunki();
                
                if (czyZgodność==true)
                {
                    #region Podstawianie
                    pracownik.Imię = textBoxImie.Text;
                    pracownik.Nazwisko = textBoxNazwisko.Text;
                    pracownik.Pesel = textBoxPesel.Text;
                    pracownik.NumerTelefonu = textBoxTelefon.Text;
                    pracownik.DataUrodzenia = dateTimePickerDataUrodzenia.Value;
                    pracownik.DataRozpoczęciaPracy = dateTimeDataRozpoczęciaPracy.Value;
                    pracownik.AdresZamieszkania = textBoxAdres.Text;
                    pracownik.UrządSkarbowy = textBoxUrzad.Text;
                    pracownik.StawkaGodzinowa = (int)numericUpDown1.Value;
                    Pracownik.ListaPracowników.Add(pracownik);
                    DialogResult = DialogResult.OK;
                    #endregion
                }
                
            }
            else
            {

                
                bool czyZgodność = warunki();
                #region Podstawianie


                if (czyZgodność == true)
                {
                    pracownik.Imię = textBoxImie.Text;
                    pracownik.Nazwisko = textBoxNazwisko.Text;
                    pracownik.Pesel = textBoxPesel.Text;
                    pracownik.NumerTelefonu = textBoxTelefon.Text;
                    pracownik.DataUrodzenia = dateTimePickerDataUrodzenia.Value;
                    pracownik.DataRozpoczęciaPracy = dateTimeDataRozpoczęciaPracy.Value;
                    pracownik.AdresZamieszkania = textBoxAdres.Text;
                    pracownik.UrządSkarbowy = textBoxUrzad.Text;
                    pracownik.StawkaGodzinowa = (int)numericUpDown1.Value;
                    DialogResult = DialogResult.OK;
                }
                
                #endregion 
            }
            
            
            
        }

        private void FormDodajlubEdytujPracownika_Load(object sender, EventArgs e)
        {

             if(pracownik!=null)
            {
                textBoxImie.Text = pracownik.Imię;
                textBoxNazwisko.Text = pracownik.Nazwisko;
                textBoxPesel.Text = pracownik.Pesel;
                textBoxTelefon.Text = pracownik.NumerTelefonu;
                dateTimePickerDataUrodzenia.Value = pracownik.DataUrodzenia;
                dateTimeDataRozpoczęciaPracy.Value = pracownik.DataRozpoczęciaPracy;
                textBoxAdres.Text = pracownik.AdresZamieszkania;
                textBoxUrzad.Text = pracownik.UrządSkarbowy;
                numericUpDown1.Value = (decimal)pracownik.StawkaGodzinowa;
            }
             else
            {
                dateTimePickerDataUrodzenia.Value = DateTime.Today.AddYears(-15);
            }
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        
        private bool czyUnikatowyPesel(string pesel,Pracownik a)
        {
            foreach(Pracownik p in Pracownik.ListaPracowników)
            {
                if(pesel==p.Pesel)
                {
                    if (a != p)
                    {
                        return false;
                    }
                    
                }
            }
            return true;
        }
        private bool czyUnikatowyNumer(string numer,Pracownik a)
        {
            foreach(Pracownik p in Pracownik.ListaPracowników)
            {
                if(numer==p.NumerTelefonu)
                {
                    if (a != p)
                    {


                        return false;
                    }
                }
            }
            return true;
        }
        private bool czyPoprawnaDługość(string a, int b)
        {
            if(a.Length!=b)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
        private bool czyPrzynajmniej15Lat(DateTime data)
        {
            DateTime x = new DateTime();
            x = DateTime.Today.AddYears(-15).AddDays(1);
            if ((DateTime.Today - data) >( DateTime.Today - x))
            {
                return true;
            }
            return false;
        }
        private bool czyPrzynajmniej15LatMiędzyUrodzeniemAZatrudnieniem(DateTime dataUrodzenia,DateTime dataZatrudnienia)
        {
            DateTime x = dataZatrudnienia.AddYears(-15);
            if(dataUrodzenia<x)
            {
                return true;
            }
            return false;
        }
        
        private bool warunki()
        { 
            if (string.IsNullOrWhiteSpace(textBoxImie.Text))
            {
                MessageBox.Show("Podaj imię pracownika");

                return false;
            }
            else if (string.IsNullOrWhiteSpace(textBoxNazwisko.Text))
            {
                MessageBox.Show("Podaj nawisko pracownika");

                return false;
            }
            else if (string.IsNullOrWhiteSpace(textBoxPesel.Text))
            {
                MessageBox.Show("Podaj pesel pracownika");

                return false;
            }
            else if (czyUnikatowyPesel(textBoxPesel.Text, pracownik) == false)
            {
                MessageBox.Show("Ten pesel został już przypisany innemu pracownikowi.");

                return false;
            }
            else if (czyPoprawnaDługość(textBoxPesel.Text, 11) == false)
            {
                MessageBox.Show("Pesel musi składać się z 11 cyfr.");

                return false;
            }
            else if (string.IsNullOrWhiteSpace(textBoxTelefon.Text))
            {
                MessageBox.Show("Podaj numer telefonu pracownika.");

                return false;
            }
            else if (czyPoprawnaDługość(textBoxTelefon.Text, 9) == false)
            {
                MessageBox.Show("Numer telefonu musi składać się z 9 cyfr");

                return false;
            }
            else if (czyUnikatowyNumer(textBoxTelefon.Text, pracownik) == false)
            {
                MessageBox.Show("Ten numer został już przypisany innemy pracownikowi");

                return false;
            }
            else if (czyPrzynajmniej15Lat(dateTimePickerDataUrodzenia.Value) == false)
            {
                MessageBox.Show("Pracownik musi mieć przynajmniej 15 lat.");

                return false;
            }
            else if (czyPrzynajmniej15LatMiędzyUrodzeniemAZatrudnieniem(dateTimePickerDataUrodzenia.Value, dateTimeDataRozpoczęciaPracy.Value) == false)
            {
                MessageBox.Show("Pracownik podczas zatrudnienia musiał mieć przynajmniej 15 lat.");

                return false;
            }
            else if (string.IsNullOrWhiteSpace(textBoxAdres.Text))
            {
                MessageBox.Show("Podaj adres zamieszkania pracownika.");

                return false;
            }
            else if (string.IsNullOrWhiteSpace(textBoxUrzad.Text))
            {
                MessageBox.Show("Podaj urząd skarbowy pracownika.");
                return false;
            }
            else { return true; }
        }




    }
}
