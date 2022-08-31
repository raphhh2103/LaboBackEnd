using DbLabo.DbEntities;
using LaboBLL.ModelsBLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LaboBLL.MapperBLL
{
    public static class ChampMapper
    {

        public static ChampEntity ToEntity(this ChampBLL champ)
        {
            List<SkillEntity> list = new List<SkillEntity>();
            foreach (var item in champ.Skills)
            {
                list.Add(item.ToEntity());
            }

            return new ChampEntity()
            {
                Name = champ.Name,
                Affinity = champ.Affinity.ToEntity(),
                BasicsStatistics = champ.BasicsStatistics.ToEntity(),
                Skills = list,
                IdChamp = champ.IdChamp
            };
            //return null;
        }

        public static ChampBLL ToBLL(this ChampEntity champ)
        {
            List<SkillBLL> list = new List<SkillBLL>();
            foreach (var item in champ.Skills)
            {
                list.Add(item.ToBLL());
            }

            return new ChampBLL()
            {
                Name = champ.Name,
                Affinity = champ.Affinity.ToBLL(),
                BasicsStatistics = champ.BasicsStatistics.ToBLL(),
                Skills = list,
                IdChamp = champ.IdChamp
            };

        }

    }
}
