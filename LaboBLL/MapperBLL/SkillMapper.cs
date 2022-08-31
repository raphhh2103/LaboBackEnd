using DbLabo.DbEntities;
using LaboBLL.ModelsBLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LaboBLL.MapperBLL
{
    public static class SkillMapper
    {
        public static SkillEntity ToEntity(this SkillBLL skill)
        {
            return new SkillEntity()
            {
                Name = skill.Name,
                Description = skill.Description,
                Effect = skill.Effect,
                IdSkill = skill.IdSkill,
            };
        }

        public static SkillBLL ToBLL(this SkillEntity skill)
        {
            return new SkillBLL() 
            { 
                    Name = skill.Name,
                Description = skill.Description,
                Effect = skill.Effect,
                IdSkill = skill.IdSkill,
                
            };
        }


    }
}
