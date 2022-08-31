using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LaboBLL.ModelsBLL
{
    public class ChampBLL
    {
        public int IdChamp { get; set; }
        public string Name { get; set; }

        public BasicsStatisticBLL? BasicsStatistics { get; set; }

        public AffinityChampBLL? Affinity { get; set; }

        public IEnumerable<SkillBLL>? Skills { get; set; }
    }


}
}
