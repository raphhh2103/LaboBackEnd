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
    public class ChampConfig : IEntityTypeConfiguration<ChampEntity>
    {
        public void Configure(EntityTypeBuilder<ChampEntity> builder)
        {
            builder.ToTable("Champ");

            builder.Property(ch => ch.Name)
                .IsRequired()
                .HasMaxLength(150);

        }
    }
}
