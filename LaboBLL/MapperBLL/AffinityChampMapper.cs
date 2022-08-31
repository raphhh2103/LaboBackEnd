using DbLabo.DbEntities;
using LaboBLL.ModelsBLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LaboBLL.MapperBLL
{
    public static class AffinityChampMapper
    {

        public static AffinityChampEntity ToEntity(this AffinityChampBLL affinityChamp)
        {
            return new AffinityChampEntity()
            {
                IdAffinityChamp = affinityChamp.IdAffinityChamp,
                Strong = affinityChamp.Strong,
                Weak = affinityChamp.Weak,
            };
        }

        public static AffinityChampBLL ToBLL(this AffinityChampEntity affinityChamp)
        {
            return new AffinityChampBLL()
            {
                IdAffinityChamp = affinityChamp.IdAffinityChamp,
                Strong = affinityChamp.Strong,
                Weak = affinityChamp.Weak,
            };
        }
    }
}
