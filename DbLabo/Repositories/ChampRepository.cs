using DbLabo.DbEntities;
using Microsoft.Data.SqlClient;
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
            try
            {
                using (DbConnect db = new DbConnect())
                {
                    db.Champs.Add(entity);
                    db.SaveChanges();
                }
                return entity;
            }
            catch (SqlException ex)
            {

                throw ex;
            }
        }

        public ChampEntity Delete(string str)
        {

            try
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
            catch (SqlException ex)
            {

                throw ex;
            }

 
        }

        public IEnumerable<ChampEntity> GetAll()
        {
            try
            {
                List<ChampEntity> list = new List<ChampEntity>();
                using (DbConnect db = new DbConnect())
                {
                    list = db.Champs.AsQueryable().ToList();
                }
                return list;

            }
            catch (SqlException ex)
            {

                throw ex;
            }


        }

        public ChampEntity GetOne(string str)
        {
            try
            {
                ChampEntity entity = new ChampEntity();
                using (DbConnect db = new DbConnect())
                {
                    entity = db.Champs.Where(chmp => chmp.Name == str).FirstOrDefault(); ;
                }
                return entity;
            }
            catch (SqlException ex)
            {
                throw ex;
            }


        }

        public ChampEntity Update(ChampEntity entity)
        {
            try
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
            catch (SqlException ex)
            {

                throw ex;
            }
        }
    }
}
