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
        private readonly DbConnect _dbConnect;
        public AffinityChampRepository(DbConnect dbConnect)
        {
            this._dbConnect = dbConnect; 
        }

        public AffinityChampEntity Create(AffinityChampEntity entity)
        {
            try
            {
                using (_dbConnect )
                {
                    _dbConnect.AffinityChamps.Add(entity);
                    _dbConnect.SaveChanges();
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
                    using(_dbConnect)
                    {
                       AffinityChampEntity afc = _dbConnect.AffinityChamps.Where(aff => aff.IdAffinityChamp == id).FirstOrDefault();
                        _dbConnect.Remove(afc);

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

                using (_dbConnect)
                {
                    entities = _dbConnect.AffinityChamps.AsQueryable().ToList();
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

                using (_dbConnect)
                {
                    afc = _dbConnect.AffinityChamps.Find(id);
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
                using (_dbConnect)
                {
                    _dbConnect.AffinityChamps.Update(entity);
                    _dbConnect.SaveChanges();
                    afc = _dbConnect.AffinityChamps.Find(entity.IdAffinityChamp);
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
