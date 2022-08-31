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
    public class BasicsStatisticServiceMapper :IServiceMapper<BasicsStatisticBLL>
    {

        private readonly BasicsStatisticRepository _basicsStatisticRepository;

        public BasicsStatisticServiceMapper(BasicsStatisticRepository basicsStatisticRepository)
        {
            this._basicsStatisticRepository = basicsStatisticRepository;
        }

        public BasicsStatisticBLL Create(BasicsStatisticBLL entity)
        {
            return _basicsStatisticRepository.Create(entity.ToEntity()).ToBLL();

        }

        public BasicsStatisticBLL Delete(string str)
        {
            return _basicsStatisticRepository.Delete(str).ToBLL();
        }

        public IEnumerable<BasicsStatisticBLL> GetAll()
        {
            List<BasicsStatisticBLL> list = new List<BasicsStatisticBLL>();

            foreach (var item in _basicsStatisticRepository.GetAll())
            {
                list.Add(item.ToBLL());
            }
            return list;
        }

        public BasicsStatisticBLL GetOne(string str)
        {
            return _basicsStatisticRepository.GetOne(str).ToBLL();
        }

        public BasicsStatisticBLL Update(BasicsStatisticBLL entity)
        {
            return _basicsStatisticRepository.Update(entity.ToEntity()).ToBLL();
        }
    }
}
