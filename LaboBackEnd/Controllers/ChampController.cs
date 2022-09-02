using LaboBackEnd.ModelsAPI;
using LaboBLL.ServicesBLL;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using LaboBackEnd.MapperAPI;

namespace LaboBackEnd.Controllers
{
    [ApiController]
    [Route("Champ")]
    public class ChampController : ControllerBase
    {
        private readonly ChampServiceMapper _champService;
        private readonly SkillServiceMapper _skillService;
        private readonly AffinityChampServiceMapper _affinityChampService;

        public ChampController(ChampServiceMapper champService, SkillServiceMapper skillService, AffinityChampServiceMapper affinityChampService)
        {
            this._champService = champService;
            this._skillService = skillService;
            this._affinityChampService = affinityChampService;
        }


        [HttpPost]
        public IActionResult CreateChamp(ChampAPI champ)
        {
            return Ok(_champService.Create(champ.ToBLL()));
        }

        [HttpGet]
        public IActionResult GetAllChamp()
        {
            List<ChampAPI> list = new List<ChampAPI>();
            foreach (var item in _champService.GetAll())
            {

                list.Add(item.ToAPI());
     
            }
            return Ok(list);
        }

        [HttpGet("{Name}")]
        public IActionResult GetOneChamp(string Name)
        {
            return Ok(_champService.GetOne(Name));
        }

        [HttpPut("Name")]
        public IActionResult UpdateChamp(string Name, [FromBody] ChampAPI champ)
        {
            ChampAPI ch = _champService.GetOne(Name).ToAPI();

            if (ch != null)
            {
                ch.Name = champ.Name;
                ch.Affinity = champ.Affinity;
                ch.Skills = champ.Skills;
                ch.BasicsStatistics = champ.BasicsStatistics;
                _champService.Update(ch.ToBLL());
            }
            return Ok(ch);
        }


    }
}
