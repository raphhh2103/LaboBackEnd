using DbLabo.DbEntities;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace DbLabo.Repositories
{
    public class SkillRepository : IRepository<SkillEntity>
    {

        private readonly DbConnect _dbConnect;

        public SkillRepository(DbConnect dbConnect)
        {
            this._dbConnect = dbConnect;
        }


        public SkillEntity Create(SkillEntity entity)
        {
            try
            {
                using (_dbConnect)
                {
                    _dbConnect.Skills.Add(entity);
                    _dbConnect.SaveChanges();
                }
                return entity;
            }
            catch (SqlException ex) { throw ex; }
        }

        public SkillEntity Delete(string str)
        {
            try
            {
                using (_dbConnect)
                {
                    var skl = _dbConnect.Skills.Where(sk => sk.Name == str).FirstOrDefault();
                    if (skl != null && skl is SkillEntity)
                    {
                        _dbConnect.Remove(skl);
                    }
                }

                return new SkillEntity()
                {
                    Name = "deleted",
                    Description = "deleted",
                    Effect = "deleted",

                };
            }
            catch (SqlException ex)
            {

                throw ex;
            }
        }

        public IEnumerable<SkillEntity> GetAll()
        {
            try
            {
                List<SkillEntity> list = new List<SkillEntity>();
                using (_dbConnect)
                {
                    list = _dbConnect.Skills.AsQueryable().ToList();
                }
                return list;
            }
            catch (SqlException ex) { throw ex; }
        }

        public SkillEntity GetOne(string str)
        {
            try
            {
                int id;
                int.TryParse(str, out id);

                SkillEntity skill = new SkillEntity();
                using (_dbConnect)
                {
                    skill = _dbConnect.Skills.Find(id);
                }
                return skill;
            }
            catch (SqlException ex) { throw ex; }
        }

        public SkillEntity Update(SkillEntity entity)
        {
            try
            {
                SkillEntity skl = new SkillEntity();
                using (_dbConnect)
                {
                    _dbConnect.Skills.Update(entity);
                    _dbConnect.SaveChanges();
                    skl = _dbConnect.Skills.Find(entity.Name);
                }

                return skl;
            }
            catch (SqlException ex)
            {

                throw ex;
            }
        }
    }
}
