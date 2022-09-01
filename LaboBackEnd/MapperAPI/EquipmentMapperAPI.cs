using LaboBackEnd.ModelsAPI;
using LaboBLL.ModelsBLL;

namespace LaboBackEnd.MapperAPI
{
    public static class EquipmentMapperAPI
    {
        public static EquipmentBLL ToBLL(this EquipmentAPI equipment)
        {
            return new EquipmentBLL()
            {
                IdEquipment = equipment.IdEquipment,
                Effect=equipment.Effect,
                NbPartsRequired = equipment.NbPartsRequired,
                Type = equipment.Type,
            };
        }
        public static EquipmentAPI ToAPI(this EquipmentBLL equipment)
        {
            return new EquipmentAPI()
            {
                IdEquipment = equipment.IdEquipment,
                Effect = equipment.Effect,
                NbPartsRequired = equipment.NbPartsRequired,
                Type = equipment.Type,
            };
        }

    }
}
