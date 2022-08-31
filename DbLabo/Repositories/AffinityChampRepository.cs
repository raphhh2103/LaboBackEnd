using DbLabo.DbEntities;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DbLabo.Repositories
{
    internal class AffinityChampRepository : IRepository<AffinityChampEntity>
    {
        public AffinityChampEntity Create(AffinityChampEntity entity)
        {
            using (DbConnect db = new DbConnect())
            {
                db.AffinityChamps.Add(entity);
                db.SaveChanges();
            }

            return entity;
        }

        public AffinityChampEntity Delete(string str)
        {
            throw new Exception("this functionnality is not possible ");
        }

        public IEnumerable<AffinityChampEntity> GetAll()
        {
            List<AffinityChampEntity> entities = new List<AffinityChampEntity>();

            using (DbConnect db = new DbConnect())
            {
                entities = db.AffinityChamps.AsQueryable().ToList();
            }
            return entities;
        }

        public AffinityChampEntity GetOne(string str)
        {
            AffinityChampEntity afc = new AffinityChampEntity();

            using (DbConnect db = new DbConnect())
            {
                afc = db.AffinityChamps.Find(str);
            }
            return afc;
        }

        public AffinityChampEntity Update(AffinityChampEntity entity)
        {
            AffinityChampEntity afc = new AffinityChampEntity();
            using (DbConnect db = new DbConnect())
            {
                db.AffinityChamps.Update(entity);
                db.SaveChanges();
                afc = db.AffinityChamps.Find(entity.IdAffinityChamp);
            }
            return afc;
        }
    }
}
