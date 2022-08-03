using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SklepSpożywczy
{
    [Serializable]
    public class DzieńRoboczy
    {
        static List<DzieńRoboczy> listaDni = new List<DzieńRoboczy>();
        DateTime data;
        int zaplanowanaLiczbaRoboczogodzin;

        public static List<DzieńRoboczy> ListaDni { get => listaDni; set => listaDni = value; }

        public DateTime Data { get => data; set => data = value; }
        public int ZaplanowanaLiczbaRoboczogodzin { get => zaplanowanaLiczbaRoboczogodzin; set => zaplanowanaLiczbaRoboczogodzin = value; }
        public object[] TabelaDlaDGV()
        {
            object[] tbl = new object[2];
            tbl[0] = Data.ToShortDateString();
            tbl[1] = ZaplanowanaLiczbaRoboczogodzin;
         
            return tbl;
        }
        public override string ToString()
        {
            string txt = string.Empty;
            txt += Data.ToShortDateString();
            return txt;
        }
    }
}
