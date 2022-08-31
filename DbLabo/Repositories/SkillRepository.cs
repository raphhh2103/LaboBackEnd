using DbLabo.DbEntities;
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
            using (DbConnect db = new DbConnect())
            {
                db.Skills.Add(entity);
                db.SaveChanges();
            }
            return entity;

        }

        public SkillEntity Delete(string str)
        {
            using (DbConnect db = new DbConnect())
            {
                var skl = db.Skills.Where(sk=>sk.Name == str).FirstOrDefault();
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

        public IEnumerable<SkillEntity> GetAll()
        {
            List<SkillEntity> list = new List<SkillEntity>();
            using (DbConnect db = new DbConnect())
            {
                list = db.Skills.AsQueryable().ToList();
            }
            return list;
        }

        public SkillEntity GetOne(string str)
        {
            SkillEntity skill = new SkillEntity();
            using (DbConnect db = new DbConnect())
            {
                skill = db.Skills.Find(str);
            }
            return skill;
        }

        public SkillEntity Update(SkillEntity entity)
        {
            SkillEntity  skl = new SkillEntity();
            using (DbConnect db = new DbConnect())
            {
                db.Skills.Update(entity);
                db.SaveChanges();
                skl = db.Skills.Find(entity.Name);
            }

            return skl;
        }
    }
}
