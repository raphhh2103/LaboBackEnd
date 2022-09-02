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
        public SkillEntity Create(SkillEntity entity)
        {
            try
            {
                using (DbConnect db = new DbConnect())
                {
                    db.Skills.Add(entity);
                    db.SaveChanges();
                }
                return entity;
            }
            catch (SqlException ex) { throw ex; }
        }

        public SkillEntity Delete(string str)
        {
            try
            {
                using (DbConnect db = new DbConnect())
                {
                    var skl = db.Skills.Where(sk => sk.Name == str).FirstOrDefault();
                    if (skl != null && skl is SkillEntity)
                    {
                        db.Remove(skl);
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
        {try
            {
                List<SkillEntity> list = new List<SkillEntity>();
                using (DbConnect db = new DbConnect())
                {
                    list = db.Skills.AsQueryable().ToList();
                }
                return list;
            }
            catch (SqlException ex) { throw ex; }
        }

        public SkillEntity GetOne(string str)
        {try
            {
                int id;
                int.TryParse(str, out id);

                SkillEntity skill = new SkillEntity();
                using (DbConnect db = new DbConnect())
                {
                    skill = db.Skills.Find(id);
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
                using (DbConnect db = new DbConnect())
                {
                    db.Skills.Update(entity);
                    db.SaveChanges();
                    skl = db.Skills.Find(entity.Name);
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
