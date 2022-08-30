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
    public class AffinityChampConfig : IEntityTypeConfiguration<AffinityChampEntity>
    {
        public void Configure(EntityTypeBuilder<AffinityChampEntity> builder)
        {
            builder.ToTable("AffinityChamp");

            builder.HasKey(afc=>afc.IdAffinityChamp);

            builder.Property(afc => afc.Weak)
                .IsRequired()
                .HasMaxLength(50);

            builder.Property(afc => afc.Strong)
                .IsRequired()
                .HasMaxLength(50);
        }
    }
}
