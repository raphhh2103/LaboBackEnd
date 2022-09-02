using DbLabo.DbConfig;
using DbLabo.DbEntities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using System.Runtime.InteropServices;

namespace DbLabo
{
    public class DbConnect : DbContext
    {
        public DbConnect(DbContextOptions<DbConnect> options) : base(options)
        {
            Users = Set<UserEntity>();
            Skills = Set<SkillEntity>();
            Equipments = Set<EquipmentEntity>();
            Champs = Set<ChampEntity>();
            BasicsStatistics = Set<BasicsStatisticEntity>();
            AffinityChamps = Set<AffinityChampEntity>();
        }

        public DbSet<UserEntity> Users { get; set; }
        public DbSet<SkillEntity> Skills { get; set; }
        public DbSet<EquipmentEntity> Equipments { get; set; }
        public DbSet<ChampEntity> Champs { get; set; }
        public DbSet<BasicsStatisticEntity> BasicsStatistics { get; set; }
        public DbSet<AffinityChampEntity> AffinityChamps { get; set; }


        ///NETLAB204\TFTIC
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.EnableDetailedErrors();
            if (!optionsBuilder.IsConfigured)
            {

                if (!optionsBuilder.IsConfigured)
                {

                }
                string csbuilder = new ConfigurationBuilder()
                    .SetBasePath(Directory.GetCurrentDirectory())
                    .AddJsonFile("Appsetting.json", optional: true, reloadOnChange: true)
                    .Build().GetConnectionString("Connection").ToString();
                optionsBuilder.UseSqlServer(csbuilder);

            }
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
