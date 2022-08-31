using DbLabo.DbEntities;
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
            using (DbConnect db = new DbConnect())
            {
                db.Equipments.Add(entity);
                db.SaveChanges();
            }
            return entity;
        }

        public EquipmentEntity Delete(string str)
        {
            int id;
            int.TryParse(str, out id);
            using (DbConnect db = new DbConnect())
            {
               var eqp =  db.Equipments.Where(eq => eq.IdEquipment == id).FirstOrDefault();
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

        public IEnumerable<EquipmentEntity> GetAll()
        {
            List<EquipmentEntity> list = new List<EquipmentEntity>();
            using (DbConnect db = new DbConnect())
            {
                list = db.Equipments.AsQueryable().ToList();

            }
            return list;
        
        }

        public EquipmentEntity GetOne(string str)
        {
           EquipmentEntity entity = new EquipmentEntity();
            using (DbConnect db = new DbConnect())
            {
                entity = db.Equipments.Find(str);
            }
            return entity;
        }

        public EquipmentEntity Update(EquipmentEntity entity)
        {
            EquipmentEntity equipment = new EquipmentEntity();

            using(DbConnect db = new DbConnect())
            {
                db.Equipments.Update(entity);
                db.SaveChanges();
                equipment = db.Equipments.Find(entity);
            }
            return equipment;

        }
    }
}
