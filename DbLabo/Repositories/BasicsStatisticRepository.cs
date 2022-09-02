using DbLabo.DbEntities;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DbLabo.Repositories
{
    public class BasicsStatisticRepository : IRepository<BasicsStatisticEntity>
    {
        private readonly DbConnect _dbConnect;

        public BasicsStatisticRepository(DbConnect dbConnect)
        {
            _dbConnect = dbConnect;
        }


        public BasicsStatisticEntity Create(BasicsStatisticEntity entity)
        {
            try
            {
                using (_dbConnect)
                {
                    _dbConnect.BasicsStatistics.Add(entity);
                    _dbConnect.SaveChanges();
                }
                return entity;
            }
            catch (SqlException ex)
            {

                throw ex;
            }
        }

        public BasicsStatisticEntity Delete(string str)
        {
            try
            {
                int dt;
                if (int.TryParse(str, out dt))
                {
                    using (_dbConnect)
                    {
                        var bs = _dbConnect.BasicsStatistics.Where(bst => bst.IdBasicsStatistic == dt).FirstOrDefault();
                        if (bs != null && _dbConnect is BasicsStatisticEntity)
                            _dbConnect.Remove(bs);
                    }
                }
                else
                {
                    throw new Exception("this basics statistics does not exist ");
                }
                return new BasicsStatisticEntity()
                {
                    Atk = 0,
                    Def = 0,
                    CriticalDamage = 0,
                    CriticalRate = 0,
                    IdBasicsStatistic = 0,
                    Hp = 0,
                    Precision = 0,
                    Resistor = 0,
                    Vit = 0,
                };
            }
            catch (SqlException ex)
            {

                throw ex;
            }

        }

        public IEnumerable<BasicsStatisticEntity> GetAll()
        {
            try
            {
                List<BasicsStatisticEntity> list = new List<BasicsStatisticEntity>();
                using (_dbConnect)
                {
                    list = _dbConnect.BasicsStatistics.AsQueryable().ToList();
                }
                return list;
            }
            catch (SqlException ex)
            {

                throw ex;
            }
        }

        public BasicsStatisticEntity GetOne(string str)
        {
            try
            {
                int id;
                BasicsStatisticEntity bst = new BasicsStatisticEntity();

                if (int.TryParse(str, out id))
                {
                    using (_dbConnect)
                    {
                        bst = _dbConnect.BasicsStatistics.Find(id);
                    }
                }
                return bst;
            }
            catch (SqlException ex)
            {

                throw ex;
            }

        }

        public BasicsStatisticEntity Update(BasicsStatisticEntity entity)
        {
            try
            {
                using (_dbConnect)
                {
                    _dbConnect.BasicsStatistics.Update(entity);
                    _dbConnect.SaveChanges();

                }
                return entity;
            }
            catch (SqlException ex)
            {

                throw ex;
            }
        }
    }
}
