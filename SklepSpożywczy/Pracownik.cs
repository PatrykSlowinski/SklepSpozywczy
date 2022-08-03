using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SklepSpożywczy
{
    [Serializable]
    public class Pracownik
    {
        string imię, nazwisko, pesel,numerTelefonu;
        DateTime dataUrodzenia,dataRozpoczęciaPracy;
        string adresZamieszkania, urządSkarbowy;
        int stawkaGodzinowa;

        static List<Pracownik> listaPracowników = new List<Pracownik>();

        public string Imię { get => imię; set => imię = value; }
        public string Nazwisko { get => nazwisko; set => nazwisko = value; }
        public string Pesel { get => pesel; set => pesel = value; }
        public string NumerTelefonu { get => numerTelefonu; set => numerTelefonu = value; }
        public DateTime DataUrodzenia { get => dataUrodzenia; set => dataUrodzenia = value; }
        public DateTime DataRozpoczęciaPracy { get => dataRozpoczęciaPracy; set => dataRozpoczęciaPracy = value; }
        public string AdresZamieszkania { get => adresZamieszkania; set => adresZamieszkania = value; }
        public string UrządSkarbowy { get => urządSkarbowy; set => urządSkarbowy = value; }
        public int StawkaGodzinowa { get => stawkaGodzinowa; set => stawkaGodzinowa = value; }
        public static List<Pracownik> ListaPracowników { get => listaPracowników; set => listaPracowników = value; }

        public object[] TabelaDlaDGV()
        {
            object[] tbl = new object[9];
            tbl[0] = Imię;
            tbl[1] = Nazwisko;
            tbl[2] = Pesel;
            tbl[3] = NumerTelefonu;
            tbl[4] = DataUrodzenia.ToShortDateString();
            tbl[5] = DataRozpoczęciaPracy.ToShortDateString();
            tbl[6] = AdresZamieszkania;
            tbl[7] = UrządSkarbowy;
            tbl[8] = StawkaGodzinowa;

            return tbl;
        }
        public override string ToString()
        {
            string txt = string.Empty;
            txt += Imię;
            txt += " " + Nazwisko;
            return txt;
        }
    }
    
}
