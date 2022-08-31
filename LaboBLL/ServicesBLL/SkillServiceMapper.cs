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
    public class SkillServiceMapper : IServiceMapper<SkillBLL>
    {
        private readonly SkillRepository _skillRepository;
        public SkillServiceMapper(SkillRepository skillRepository)
        {
            this._skillRepository = skillRepository;
        }

        public SkillBLL Create(SkillBLL entity)
        {
            return _skillRepository.Create(entity.ToEntity()).ToBLL();
        }

        public SkillBLL Delete(string str)
        {
            return _skillRepository.Delete(str).ToBLL();
        }

        public IEnumerable<SkillBLL> GetAll()
        {
            List<SkillBLL> list = new List<SkillBLL>();

            foreach (var item in _skillRepository.GetAll())
            {
                list.Add(item.ToBLL());
            }
            return list;
        }

        public SkillBLL GetOne(string str)
        {
           return _skillRepository.GetOne(str).ToBLL();
        }

        public SkillBLL Update(SkillBLL entity)
        {
            return _skillRepository.Update(entity.ToEntity()).ToBLL();
        }
    }
}
