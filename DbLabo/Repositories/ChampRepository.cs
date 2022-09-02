using DbLabo.DbEntities;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DbLabo.Repositories
{
    public class ChampRepository : IRepository<ChampEntity>
    {
        private readonly DbConnect _dbConnect;
        public ChampRepository(DbConnect dbConnect)
        {
            this._dbConnect = dbConnect;
        }

        public ChampEntity Create(ChampEntity entity)
        {
            try
            {
                using (_dbConnect)
                {
                    _dbConnect.Champs.Add(entity);
                    _dbConnect.SaveChanges();
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
                using (_dbConnect)
                {
                    var chm = _dbConnect.Champs
                        .Where(ch => ch.Name.Equals(str))
                        .Include(aff => aff.Affinity)
                        .Include(bst => bst.BasicsStatistics)
                        .Include(sk => sk.Skills)
                        .FirstOrDefault();
                    if (chm != null && chm is ChampEntity)
                        _dbConnect.Remove(chm);
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
                using (_dbConnect)
                {
                    list = _dbConnect.Champs
                        .Include(aff => aff.Affinity)
                        .Include(bst => bst.BasicsStatistics)
                        .Include(sk => sk.Skills).ToList();
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
                ChampEntity? entity = new ChampEntity();
                //ChampEntity entity2 = new ChampEntity();
                using (_dbConnect)
                {
                     entity = _dbConnect.Champs
                        .Where(ch => ch.Name.Equals(str))
                        .Include(aff => aff.Affinity)
                        .Include(bst => bst.BasicsStatistics)
                        .Include(sk=> sk.Skills)
                        .FirstOrDefault();
                }
                if (entity == null) throw new Exception("oups we have a problem ! ");
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
                ChampEntity? chm = new ChampEntity();
                using (_dbConnect)
                {
                    _dbConnect.Champs.Update(entity);
                    _dbConnect.SaveChanges();
                    chm = _dbConnect.Champs.Find(entity.IdChamp);
                }
                if (chm == null) throw new Exception("oups ! we have a problem !");
                return chm;
            }
            catch (SqlException ex)
            {
                throw ex;
            }
        }
    }
}
