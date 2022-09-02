using DbLabo.DbEntities;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DbLabo.Repositories
{
    public class EquipmentRepository : IRepository<EquipmentEntity>
    {

        private readonly DbConnect _dbConnect;

        public EquipmentRepository(DbConnect dbConnect)
        {
                this._dbConnect = dbConnect;
        }

        public EquipmentEntity Create(EquipmentEntity entity)
        {
            try
            {
                using (_dbConnect)
                {
                    _dbConnect.Equipments.Add(entity);
                    _dbConnect.SaveChanges();
                }
                return entity;
            }
            catch (SqlException ex)
            {

                throw ex;
            }
        }

        public EquipmentEntity Delete(string str)
        {
            try
            {
                int id;
                int.TryParse(str, out id);
                using (_dbConnect)
                {
                    var eqp = _dbConnect.Equipments.Where(eq => eq.IdEquipment == id).FirstOrDefault();
                    if (eqp != null && eqp is EquipmentEntity)
                    {
                        _dbConnect.Remove(eqp);
                    }
                }
                return new EquipmentEntity()
                {
                    Effect = "deleted",
                    NbPartsRequired = 0,
                    Type = " deleted"
                };
            }
            catch (SqlException ex)
            {

                throw ex;
            }
        }

        public IEnumerable<EquipmentEntity> GetAll()
        {
            try
            {
                List<EquipmentEntity> list = new List<EquipmentEntity>();
                using (_dbConnect)
                {
                    list = _dbConnect.Equipments.AsQueryable().ToList();

                }
                return list;
            }
            catch (SqlException ex)
            {

                throw ex;
            }

        }

        public EquipmentEntity GetOne(string str)
        {
            try
            {
                int id;
                int.TryParse(str, out id);
                EquipmentEntity entity = new EquipmentEntity();
                using (_dbConnect)
                {
                    entity = _dbConnect.Equipments.Find(id);
                }
                return entity;
            }
            catch (SqlException ex)
            {

                throw ex;
            }
        }

        public EquipmentEntity Update(EquipmentEntity entity)
        {
            try
            {
                EquipmentEntity equipment = new EquipmentEntity();

                using (_dbConnect)
                {
                    _dbConnect.Equipments.Update(entity);
                    _dbConnect.SaveChanges();
                    equipment = _dbConnect.Equipments.Find(entity);
                }
                return equipment;
            }
            catch (SqlException ex)
            {

                throw ex;
            }

        }
    }
}
