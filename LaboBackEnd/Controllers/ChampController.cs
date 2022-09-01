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

        public ChampController(ChampServiceMapper champService)
        {
            this._champService = champService;
        }


        [HttpPost]
        public IActionResult CreateChamp(ChampAPI champ)
        {
            return Ok(_champService.Create(champ.ToBLL()));
        }

        [HttpGet]
        public IActionResult GetAllChamp()
        {
            return Ok(_champService.GetAll());
        }

        [HttpGet("{Name}")]
        public IActionResult GetOneChamp(string Name)
        {
            return Ok(_champService.GetOne(Name));
        }

        [HttpPut("Name")]
        public IActionResult UpdateChamp(string Name, [FromBody] ChampAPI champ)
        {
           ChampAPI ch =  _champService.GetOne(Name).ToAPI();

            if (ch !=null)
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
