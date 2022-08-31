using DbLabo.Repositories;
using LaboBLL.MapperBLL;
using LaboBLL.ModelsBLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LaboBLL.ServicesBLL
{
    public class EquipmentServiceMapper : IServiceMapper<EquipmentBLL>
    {
        private readonly EquipmentRepository _equipmentRepository;

        public EquipmentServiceMapper(EquipmentRepository equipmentRepository)
        {
            this._equipmentRepository = equipmentRepository;
        }

        public EquipmentBLL Create(EquipmentBLL entity)
        {
            return _equipmentRepository.Create(entity.ToEntity()).ToBLL();
        }

        public EquipmentBLL Delete(string str)
        {
            return _equipmentRepository.Delete(str).ToBLL();
        }

        public IEnumerable<EquipmentBLL> GetAll()
        {
            List<EquipmentBLL> list = new List<EquipmentBLL>();

            foreach (var item in _equipmentRepository.GetAll())
            {
                list.Add(item.ToBLL());
            }
            return list;
        }

        public EquipmentBLL GetOne(string str)
        {
            return _equipmentRepository.GetOne(str).ToBLL();
        }

        public EquipmentBLL Update(EquipmentBLL entity)
        {
            return _equipmentRepository.Update(entity.ToEntity()).ToBLL();
        }
    }
}
