using DbLabo.DbEntities;
using LaboBLL.ModelsBLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LaboBLL.MapperBLL
{
    public static class UserMapper
    {
        public static UserEntity ToEntity(this UserBLL user)
        {
            return /*UserEntity userE =*/ new UserEntity()
            {
                Email = user.Email,
                Passwd = user.Passwd,
                SaltKey = user.SaltKey,
                Rule = user.Rule,
                IdUser = user.IdUser,
            };
        }

        public static UserBLL ToBLL(this UserEntity user)
        {
            return new UserBLL()
            {
                Email = user.Email,
                Passwd = user.Passwd,
                SaltKey = user.SaltKey,
                Rule = user.Rule,
                IdUser = user.IdUser,

            };
        }

    }
}
