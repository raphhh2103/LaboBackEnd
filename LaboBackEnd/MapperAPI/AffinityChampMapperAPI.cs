using LaboBackEnd.ModelsAPI;
using LaboBLL.ModelsBLL;

namespace LaboBackEnd.MapperAPI
{
    public static class AffinityChampMapperAPI
    {
        public static AffinityChampBLL ToBLL(this AffinityChampAPI affinityChamp)
        {
            return new AffinityChampBLL()
            {
               IdAffinityChamp=affinityChamp.IdAffinityChamp,
               Strong=affinityChamp.Strong,
               Weak=affinityChamp.Weak,

            };
        }

        public static AffinityChampAPI ToAPI(this AffinityChampBLL affinityChamp)
        {
            return new AffinityChampAPI()
            {
                IdAffinityChamp = affinityChamp.IdAffinityChamp,
                Strong = affinityChamp.Strong,
                Weak = affinityChamp.Weak,
            };
        }

    }
}
