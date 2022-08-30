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
    public class SkillConfig : IEntityTypeConfiguration<SkillEntity>
    {
        public void Configure(EntityTypeBuilder<SkillEntity> builder)
        {
            builder.ToTable("Skill");

            builder.HasKey(sk=>sk.IdSkill);

            builder.Property(sk => sk.Name)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(sk => sk.Description)
                .IsRequired()
                .HasMaxLength(250);

            builder.Property(sk => sk.Effect)
                .IsRequired()
                .HasMaxLength(150);
        
        
        }
    }
}
