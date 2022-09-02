using DbLabo.DbEntities;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DbLabo.Repositories
{
    public class AffinityChampRepository : IRepository<AffinityChampEntity>
    {
        public AffinityChampEntity Create(AffinityChampEntity entity)
        {
            try
            {
                using (DbConnect db = new DbConnect())
                {
                    db.AffinityChamps.Add(entity);
                    db.SaveChanges();
                }

                return entity;
            }
            catch (SqlException ex)
            {

                throw ex;
            }
        }

        public AffinityChampEntity Delete(string str)
        {
            try
            {
                int id;

                int.TryParse(str, out id);

                if (id != 0)
                {
                    using(DbConnect db = new DbConnect())
                    {
                       AffinityChampEntity afc =  db.AffinityChamps.Where(aff => aff.IdAffinityChamp == id).FirstOrDefault();
                        db.Remove(afc);

                        return new AffinityChampEntity()
                        {
                            IdAffinityChamp = 0,
                            Strong ="deleted",
                            Weak ="deleted"
                        };

                    }
                }
                else
                {
                    throw new Exception($"{str} is does not exist ! ");
                }
            }
            catch (SqlException ex)
            {

                throw ex;
            }
        }

        public IEnumerable<AffinityChampEntity> GetAll()
        {
            try
            {
                List<AffinityChampEntity> entities = new List<AffinityChampEntity>();

                using (DbConnect db = new DbConnect())
                {
                    entities = db.AffinityChamps.AsQueryable().ToList();
                }
                return entities;
            }
            catch (SqlException ex)
            {

                throw ex;
            }
        }

        public AffinityChampEntity GetOne(string str)
        {
            try
            {
                int id;
                AffinityChampEntity afc = new AffinityChampEntity();
                int.TryParse(str, out id);

                using (DbConnect db = new DbConnect())
                {
                    afc = db.AffinityChamps.Find(id);
                }
                return afc;
            }
            catch (SqlException ex)
            {

                throw ex;
            }
        }

        public AffinityChampEntity Update(AffinityChampEntity entity)
        {
            try
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
            catch (SqlException ex)
            {

                throw ex;
            }
        }
    }
}
