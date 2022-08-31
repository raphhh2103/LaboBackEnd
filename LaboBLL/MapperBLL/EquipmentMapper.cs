using DbLabo.DbEntities;
using LaboBLL.ModelsBLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LaboBLL.MapperBLL
{
    public static class EquipmentMapper
    {
        public static EquipmentEntity ToEntity(this EquipmentBLL equipment)
        {
            return new EquipmentEntity()
            {
                Type = equipment.Type,
                NbPartsRequired = equipment.NbPartsRequired,
                Effect = equipment.Effect,
                IdEquipment = equipment.IdEquipment,
            };
        }

        public static EquipmentBLL ToBLL(this EquipmentEntity equipment)
        {
            return new EquipmentBLL()
            {
                Type = equipment.Type,
                NbPartsRequired = equipment.NbPartsRequired,
                Effect = equipment.Effect,
                IdEquipment = equipment.IdEquipment,
            };
        }
    }
}
