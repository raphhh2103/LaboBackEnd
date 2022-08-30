using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DbLabo.DbEntities
{
    public class ChampEntity
    {
        public int IdChamp { get; set; }
        public string Name { get; set; }

        public BasicsStatisticEntity? BasicsStatistics { get; set; }

        public AffinityChampEntity? Affinity { get; set; }

        public IEnumerable<SkillEntity>? Skills { get; set; }
    }
}
