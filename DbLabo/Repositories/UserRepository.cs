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

        private readonly DbConnect _dbConnect;

        public UserRepository(DbConnect dbConnect)
        {
            this._dbConnect = dbConnect;
        }
        public UserEntity Create(UserEntity entity)
        {
            try
            {
                using (_dbConnect)
                {
                    _dbConnect.Users.Add(entity);
                    _dbConnect.SaveChanges();
                }
                return entity;
            }
            catch (SqlException ex)
            {
                throw ex;
            }
        }

        public UserEntity GetOwnerCredentials(string credentialToVerify)
        {
            UserEntity entity = new UserEntity();
            using (_dbConnect)
            {
                _dbConnect.Users.Where(us=>us.Email == credentialToVerify).FirstOrDefault();
            }
            return entity ?? new UserEntity();
        }

        public UserEntity VerifyUser(UserEntity auth)
        {
            UserEntity? user = new UserEntity();
            try
            {
                if (_dbConnect.Users.Find(auth.Email) != null && _dbConnect.Users.Find(auth.Passwd) != null)
                {
                    user = _dbConnect.Users.Find(auth.Email);
                    return user;
                }
                else
                {
                    throw new Exception("this user does not exist ! ");
                }
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
                using (_dbConnect)
                {
                    var us = _dbConnect.Users.Where(u => u.Email == str).FirstOrDefault();

                    if (us != null && us is UserEntity)
                        _dbConnect.Remove(us);
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
                using (_dbConnect)
                {
                    list = _dbConnect.Users.AsQueryable().ToList();
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

                using (_dbConnect)
                {
                    entity = _dbConnect.Users.Where(us => us.Email == str).FirstOrDefault();
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
                using (_dbConnect)
                {
                    _dbConnect.Users.Update(entity);
                    _dbConnect.SaveChanges();
                    userEntity = _dbConnect.Users.Where(us => us.Email == entity.Email).FirstOrDefault(); ;
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
