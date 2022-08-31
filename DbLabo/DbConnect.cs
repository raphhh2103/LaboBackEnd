using DbLabo.DbConfig;
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

        public DbConnect() => this._connectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=DbLaboBadge;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
      //public DbConnect() =>this._connectionString = @"Data Source=NETLAB204\TFTIC;Initial Catalog=DbLaboBadge;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
        public DbConnect(string connectionString):base()
        {
            this._connectionString = connectionString;
        }
    ///NETLAB204\TFTIC
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.EnableDetailedErrors();
            optionsBuilder.UseSqlServer(_connectionString);

            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelbuilder)
        {
            modelbuilder.ApplyConfiguration(new UserConfig());
            modelbuilder.ApplyConfiguration(new SkillConfig());
            modelbuilder.ApplyConfiguration(new EquipmentConfig());
            modelbuilder.ApplyConfiguration(new ChampConfig());
            modelbuilder.ApplyConfiguration(new BasicStatisticConfig());
            modelbuilder.ApplyConfiguration(new AffinityChampConfig()); 


            base.OnModelCreating(modelbuilder);
        }
    
    }
}
