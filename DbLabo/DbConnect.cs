using DbLabo.DbEntities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DbLabo
{
    public class DbConnect :DbContext
    {
        private readonly string _connectionString;

        public DbSet<UserEntity> Users { get; set; }

        public DbSet<SkillEntity> Skills { get; set; }

        public DbSet<EquipmentEntity> Equipments { get; set; }

        public DbSet<ChampEntity> Champs { get; set; }
        public DbSet<BasicsStatisticEntity> BasicsStatistics { get; set; }

        public DbSet<AffinityChampEntity> AffinityChamps { get; set; }

        public DbConnect()
        {
            this._connectionString = @"";
        }
        public DbConnect(string connectionString):base()
        {
            this._connectionString=connectionString;
        }
    
    
    }
}
