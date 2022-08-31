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
    public class ChampServiceMapper : IServiceMapper<ChampBLL>
    {
        private readonly ChampRepository _champRepository;


        public ChampServiceMapper(ChampRepository champRepository)
        {
            this._champRepository = champRepository;
        }

        public ChampBLL Create(ChampBLL entity)
        {
            return _champRepository.Create(entity.ToEntity()).ToBLL();
        }

        public ChampBLL Delete(string str)
        {
            return _champRepository.Delete(str).ToBLL();
        }

        public IEnumerable<ChampBLL> GetAll()
        {
            List<ChampBLL> list = new List<ChampBLL>();
            foreach (var item in _champRepository.GetAll())
            {
                list.Add(item.ToBLL());
            }
            return list;
        }

        public ChampBLL GetOne(string str)
        {
            return _champRepository.GetOne(str).ToBLL();
        }

        public ChampBLL Update(ChampBLL entity)
        {
            return _champRepository.Update(entity.ToEntity()).ToBLL();
        }
    }
}
