using LaboBackEnd.ModelsAPI;
using LaboBLL.ModelsBLL;

namespace LaboBackEnd.MapperAPI
{
    public static class SkillMapperAPI
    {
        public static SkillBLL ToBLL(this SkillAPI Skill)
        {
            return new SkillBLL()
            {
                Name = Skill.Name,
                IdSkill = Skill.IdSkill,
                Description = Skill.Description,
                Effect = Skill.Effect,
            };
        }

        public static SkillAPI ToApi(this SkillBLL Skill)
        {
            return new SkillAPI()
            {
                Name = Skill.Name,
                IdSkill = Skill.IdSkill,
                Description = Skill.Description,
                Effect = Skill.Effect,
            };
        }

    }
}
