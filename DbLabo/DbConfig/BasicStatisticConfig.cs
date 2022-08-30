using DbLabo.DbEntities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DbLabo.DbConfig
{
    public class BasicStatisticConfig : IEntityTypeConfiguration<BasicsStatisticEntity>
    {
        public void Configure(EntityTypeBuilder<BasicsStatisticEntity> builder)
        {
            builder.ToTable("BasicStatistic");

            builder.HasKey(bs => bs.IdBasicsStatistic);

            builder.Property(bs => bs.Hp);

            builder.Property(bs => bs.Atk);
            builder.Property(bs => bs.Def);
            builder.Property(bs => bs.Vit);
            builder.Property(bs => bs.CriticalRate);
            builder.Property(bs => bs.CriticalDamage);
            builder.Property(bs => bs.Resistor);
            builder.Property(bs => bs.Precision);



        }
    }
}
