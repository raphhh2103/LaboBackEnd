using DbLabo.DbEntities;
using Microsoft.Data.SqlClient;
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
            try
            {
                using (DbConnect db = new DbConnect())
                {
                    db.Users.Add(entity);
                    db.SaveChanges();
                }
                return entity;
            }
            catch (SqlException ex)
            {

                throw ex;
            }
        }

        public UserEntity Delete(string str)
        {
            try
            {
                using (DbConnect db = new DbConnect())
                {
                    var us = db.Users.Where(u => u.Email == str).FirstOrDefault();

                    if (us != null && us is UserEntity)
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
            catch (SqlException ex)
            {

                throw ex;
            }
        }

        public IEnumerable<UserEntity> GetAll()
        {
            try
            {
                List<UserEntity> list = new List<UserEntity>();
                using (DbConnect db = new DbConnect())
                {
                    list = db.Users.AsQueryable().ToList();
                }
                return list;
            }
            catch (SqlException ex)
            {

                throw ex;
            }
        }

        public UserEntity GetOne(string str)
        {
            try
            {
                UserEntity entity = new UserEntity();

                using (DbConnect db = new DbConnect())
                {
                    entity = db.Users.Where(us => us.Email == str).FirstOrDefault();
                    //entity= db.Users.Select( str)
                }
                return entity;
            }
            catch (SqlException ex)
            {

                throw ex;
            }
        }

        public UserEntity Update(UserEntity entity)
        {
            try
            {
                UserEntity userEntity = new UserEntity();
                using (DbConnect db = new DbConnect())
                {
                    db.Users.Update(entity);
                    db.SaveChanges();
                    userEntity = db.Users.Where(us => us.Email == entity.Email).FirstOrDefault(); ;
                }
                return userEntity;
            }
            catch (SqlException ex)
            {

                throw ex;
            }

        }
    }
}
