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
    public class UserSericeBLL : IServiceMapper<UserBLL>
    {
        private readonly UserRepository _userRepository;

        public UserSericeBLL(UserRepository userRepository)
        {
            this._userRepository = userRepository;
        }

        public UserBLL Create(UserBLL entity)
        {
            return _userRepository.Create(entity.ToEntity()).ToBLL();
        }

        public UserBLL Delete(string str)
        {
           return _userRepository.Delete(str).ToBLL();
        }

        public IEnumerable<UserBLL> GetAll()
        {
            List<UserBLL> list = new List<UserBLL>();
            foreach (var item in _userRepository.GetAll())
            {
                list.Add(item.ToBLL());
            }
            return list;
        }

        public UserBLL GetOne(string str)
        {
            return _userRepository.GetOne(str).ToBLL();
        }

        public UserBLL Update(UserBLL entity)
        {
            return _userRepository.Update(entity.ToEntity()).ToBLL();
        }
    }
}
