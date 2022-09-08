using LaboBLL.ModelsBLL;

namespace LaboBackEnd.ModelsAPI
{
    public class ChampAPI
    {
        public int IdChamp { get; set; }
        public string Name { get; set; }

        public int BasicsStatisticsId { get; set; }

        public AffinityChampBLL? Affinity { get; set; }

        public IEnumerable<SkillBLL>? Skills { get; set; }

    }
}
