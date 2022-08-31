using DbLabo.DbEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DbLabo.Repositories
{
    public class ChampRepository : IRepository<ChampEntity>
    {
        public ChampEntity Create(ChampEntity entity)
        {
            using (DbConnect db = new DbConnect())
            {
                db.Champs.Add(entity);
                db.SaveChanges();
            }
            return entity;
        }

        public ChampEntity Delete(string str)
        {
            using (DbConnect db = new DbConnect())
            {
                var chm = db.Champs.Where(ch => ch.Name == str).FirstOrDefault();
                if (chm != null && chm is ChampEntity)
                    db.Remove(chm);
            }
            return new ChampEntity()
            {
                Name = "deleted",
                Affinity = null,
                BasicsStatistics = null,
                Skills = null,

            };
        }

        public IEnumerable<ChampEntity> GetAll()
        {
           List<ChampEntity> list = new List<ChampEntity> ();
            using (DbConnect db = new DbConnect())
            {
                list = db.Champs.AsQueryable().ToList();
            }
            return list;
        
        }

        public ChampEntity GetOne(string str)
        {
            ChampEntity entity = new ChampEntity();
            using (DbConnect db = new DbConnect())
            {
               entity=  db.Champs.Find(str);
            }
            return entity;
        }

        public ChampEntity Update(ChampEntity entity)
        {
            ChampEntity chm = new ChampEntity();

            using (DbConnect db = new DbConnect())
            {
                db.Champs.Update(entity);
                db.SaveChanges();
                chm = db.Champs.Find(entity.IdChamp);
            }

            return chm;
        }
    }
}
