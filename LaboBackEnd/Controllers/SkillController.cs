using LaboBackEnd.MapperAPI;
using LaboBackEnd.ModelsAPI;
using LaboBLL.ModelsBLL;
using LaboBLL.ServicesBLL;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LaboBackEnd.Controllers
{
    [Route("api/[Skill]")]
    [ApiController]
    public class SkillController : ControllerBase
    {
        private readonly SkillServiceMapper _skillService;


        public SkillController(SkillServiceMapper skillServiceMapper)
        {
            this._skillService = skillServiceMapper;
        }

        [HttpPost]
        public IActionResult CreateSkill(SkillAPI Skill)
        {
            return Ok(_skillService.Create(Skill.ToBLL()));
        }

        [HttpGet("id")]
        public IActionResult GetOneSkill(string id)
        {
            return Ok(_skillService.GetOne(id));
        }

        [HttpGet]
        public IActionResult GetAllSkill()
        {
            return Ok(_skillService.GetAll());
        }

        [HttpPut("id")]
        public IActionResult UpdateSkill(string id, [FromBody] SkillAPI skill)
        {
            SkillBLL sk= _skillService.GetOne(id);

            if (sk != null)
            {
                sk.Name = skill.Name;
                sk.Description = skill.Description;
                sk.Effect = skill.Effect;
                
                _skillService.Update(sk);
            }
            return Ok(skill);
        }

    }
}
