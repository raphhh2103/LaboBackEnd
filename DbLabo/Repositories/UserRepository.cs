using DbLabo.DbEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DbLabo.Repositories
{
    public class UserRepository : IRepository<UserEntity>
    {
        public UserEntity Create(UserEntity entity)
        {
            using(DbConnect db = new DbConnect())
            {
                db.Users.Add(entity);
                db.SaveChanges();
            }
            return entity;
        }

        public UserEntity Delete(string str)
        {
            using (DbConnect db = new DbConnect())
            {
                var us = db.Users.Where(u => u.Email == str).FirstOrDefault();

                if(us != null && us is UserEntity)
                    db.Remove(us);
            }

            return new UserEntity()
            {
                Email = "deleted",
                Rule = "deleted",
                Passwd = "",
                SaltKey = null,
                IdUser = 0
            };
        }

        public IEnumerable<UserEntity> GetAll()
        {
            List<UserEntity> list = new List<UserEntity>();
            using(DbConnect db=new DbConnect())
            {
                list = db.Users.AsQueryable().ToList();
            }
            return list;
        }

        public UserEntity GetOne(string str)
        {
           UserEntity entity = new UserEntity();

            using (DbConnect db = new DbConnect())
            {
                entity = db.Users.Find(str);
            }
            return entity;
        }

        public UserEntity Update(UserEntity entity)
        {
            UserEntity userEntity = new UserEntity();
           using(DbConnect db = new DbConnect())
            {
                db.Users.Update(entity);
                db.SaveChanges();
                userEntity = db.Users.Find(entity.Email);
            }
            return userEntity;

        }
    }
}
