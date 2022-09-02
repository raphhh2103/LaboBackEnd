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
        public BasicsStatisticEntity Create(BasicsStatisticEntity entity)
        {
            try
            {
                using (DbConnect db = new DbConnect())
                {
                    db.BasicsStatistics.Add(entity);
                    db.SaveChanges();
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
                    using (DbConnect db = new DbConnect())
                    {
                        var bs = db.BasicsStatistics.Where(bst => bst.IdBasicsStatistic == dt).FirstOrDefault();
                        if (bs != null && db is BasicsStatisticEntity)
                            db.Remove(bs);
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
                using (DbConnect db = new DbConnect())
                {
                    list = db.BasicsStatistics.AsQueryable().ToList();
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
                    using (DbConnect db = new DbConnect())
                    {
                        bst = db.BasicsStatistics.Find(id);
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
                using (DbConnect db = new DbConnect())
                {
                    db.BasicsStatistics.Update(entity);
                    db.SaveChanges();

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
