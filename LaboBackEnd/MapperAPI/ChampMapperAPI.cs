using LaboBackEnd.ModelsAPI;
using LaboBLL.ModelsBLL;

namespace LaboBackEnd.MapperAPI
{
    public static class ChampMapperAPI
    {
        public static ChampBLL ToBLL(this ChampAPI champ)
        {
            return new ChampBLL()
            {
                Name= champ.Name,
                Affinity= champ.Affinity,
                BasicsStatistics= champ.BasicsStatistics,
                IdChamp= champ.IdChamp,
                Skills= champ.Skills,
            };
        }

        public static ChampAPI ToAPI(this ChampBLL champ)
        {
            return new ChampAPI()
            {
                Name = champ.Name,
                Affinity = champ.Affinity,
                BasicsStatistics = champ.BasicsStatistics,
                IdChamp = champ.IdChamp,
                Skills = champ.Skills,
            };
        }

    }
}
