using LaboBackEnd.ModelsAPI;
using LaboBLL.ModelsBLL;

namespace LaboBackEnd.MapperAPI
{
    public static class ChampMapperAPI
    {
        public static ChampBLL ToBLL(this ChampAPI champ)
        {
            ChampBLL result =  new ChampBLL()
            {
                Name= champ.Name,
                Affinity= champ.Affinity,
                //BasicsStatistics.IdBasicsStatistic = champ.BasicsStatisticsId,
                //BasicsStatistics.IdBasicsStatistic = champ.BasicsStatisticsId,
                IdChamp= champ.IdChamp,
                Skills= champ.Skills,
            };
            result.BasicsStatistics.IdBasicsStatistic = champ.BasicsStatisticsId;
            return result;
        }

        public static ChampAPI ToAPI(this ChampBLL champ)
        {
            return new ChampAPI()
            {
                Name = champ.Name,
                Affinity = champ.Affinity,
                BasicsStatisticsId = champ.BasicsStatistics.IdBasicsStatistic,
                IdChamp = champ.IdChamp,
                Skills = champ.Skills,
            };
        }

    }
}
