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
    public class UserConfig : IEntityTypeConfiguration<UserEntity>
    {
        public void Configure(EntityTypeBuilder<UserEntity> builder)
        {
            builder.ToTable("users");

            builder.HasKey(us=>us.IdUser);

            builder.Property(us => us.Email)
                .IsRequired()
                .HasMaxLength(384);

            builder.Property(us => us.Passwd)
                .IsRequired()
                .HasMaxLength(512);

            builder.Property(us => us.SaltKey).IsRequired().HasMaxLength(16);
        }
    }
}
