using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LaboBLL.ModelsBLL
{
    public class BasicsStatisticBLL
    {

        public int IdBasicsStatistic { get; set; }
        public int Hp { get; set; }
        public int Atk { get; set; }
        public int Def { get; set; }

        public int Vit { get; set; }
        public int CriticalRate { get; set; }
        public int CriticalDamage { get; set; }
        public int Resistor { get; set; }
        public int Precision { get; set; }
    }
}
