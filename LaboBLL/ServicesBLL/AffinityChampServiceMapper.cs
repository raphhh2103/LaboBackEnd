using LaboBLL.ModelsBLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DbLabo.Repositories;
using LaboBLL.MapperBLL;

namespace LaboBLL.ServicesBLL
{
    public class AffinityChampServiceMapper : IServiceMapper<AffinityChampBLL>
    {
        private readonly AffinityChampRepository _affinityChampRepository;


        public AffinityChampServiceMapper(AffinityChampRepository affinityChampRepository)
        {
            this._affinityChampRepository = affinityChampRepository;
        }

        public AffinityChampBLL Create(AffinityChampBLL entity)
        {
            return _affinityChampRepository.Create(entity.ToEntity()).ToBLL();
        }

        public AffinityChampBLL Delete(string str)
        {
            return _affinityChampRepository.Delete(str).ToBLL();
        }

        public IEnumerable<AffinityChampBLL> GetAll()
        {
            List<AffinityChampBLL> list = new List<AffinityChampBLL>();

            foreach (var item in _affinityChampRepository.GetAll())
            {
                list.Add(item.ToBLL());
            }
            return list;
        }

        public AffinityChampBLL GetOne(string str)
        {
            return _affinityChampRepository.GetOne(str).ToBLL();
        }

        public AffinityChampBLL Update(AffinityChampBLL entity)
        {
            return _affinityChampRepository.Update(entity.ToEntity()).ToBLL();
        }
    }
}
