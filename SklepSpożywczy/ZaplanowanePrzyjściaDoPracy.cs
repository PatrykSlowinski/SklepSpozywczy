using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SklepSpożywczy
{
    [Serializable]
    public class ZaplanowanePrzyjściaDoPracy
    {
        Pracownik pracownik1;
        DzieńRoboczy dzieńRoboczy1;
        int iloscGodzinDoPrzepracowanie;
        int iloscGodzinFaktyczniePrzepracowanych;

        static List<ZaplanowanePrzyjściaDoPracy> listaZaplanowanychPrzyjść = new List<ZaplanowanePrzyjściaDoPracy>();

        public Pracownik Pracownik1 { get => pracownik1; set => pracownik1 = value; }
        public DzieńRoboczy DzieńRoboczy1 { get => dzieńRoboczy1; set => dzieńRoboczy1 = value; }
        public int IloscGodzinDoPrzepracowanie { get => iloscGodzinDoPrzepracowanie; set => iloscGodzinDoPrzepracowanie = value; }
        public int IloscGodzinFaktyczniePrzepracowanych { get => iloscGodzinFaktyczniePrzepracowanych; set => iloscGodzinFaktyczniePrzepracowanych = value; }
        public static List<ZaplanowanePrzyjściaDoPracy> ListaZaplanowanychPrzyjść { get => listaZaplanowanychPrzyjść; set => listaZaplanowanychPrzyjść = value; }

        public object[] TabelaDlaDGV()
        {
            object[] tbl = new object[4];
            tbl[0] = DzieńRoboczy1;
            tbl[1] = Pracownik1;
            tbl[2] = IloscGodzinDoPrzepracowanie;
            tbl[3] = IloscGodzinFaktyczniePrzepracowanych;
        

            return tbl;
        }
        
    }
}
