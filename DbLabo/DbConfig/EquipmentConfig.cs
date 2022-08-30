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
    public class EquipmentConfig : IEntityTypeConfiguration<EquipmentEntity>
    {
        public void Configure(EntityTypeBuilder<EquipmentEntity> builder)
        {
            builder.ToTable("Equipment");

            builder.HasKey(eq => eq.IdEquipment);

            builder.Property(eq => eq.Type)
                .IsRequired()
                .HasMaxLength(100);
            builder.Property(eq => eq.Effect)
                .IsRequired()
                .HasMaxLength(150);

            builder.Property(eq => eq.NbPartsRequired)
                .IsRequired();
        }
    }
}
