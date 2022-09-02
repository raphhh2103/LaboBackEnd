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
        public EquipmentEntity Create(EquipmentEntity entity)
        {
            try
            {
                using (DbConnect db = new DbConnect())
                {
                    db.Equipments.Add(entity);
                    db.SaveChanges();
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
                using (DbConnect db = new DbConnect())
                {
                    var eqp = db.Equipments.Where(eq => eq.IdEquipment == id).FirstOrDefault();
                    if (eqp != null && eqp is EquipmentEntity)
                    {
                        db.Remove(eqp);
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
                using (DbConnect db = new DbConnect())
                {
                    list = db.Equipments.AsQueryable().ToList();

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
                using (DbConnect db = new DbConnect())
                {
                    entity = db.Equipments.Find(id);
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

                using (DbConnect db = new DbConnect())
                {
                    db.Equipments.Update(entity);
                    db.SaveChanges();
                    equipment = db.Equipments.Find(entity);
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
