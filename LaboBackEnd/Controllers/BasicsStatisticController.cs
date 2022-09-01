using LaboBackEnd.MapperAPI;
using LaboBackEnd.ModelsAPI;
using LaboBLL.ServicesBLL;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LaboBackEnd.Controllers
{
    [Route("api/[BasicStat]")]
    [ApiController]
    public class BasicsStatisticController : ControllerBase
    {
        private readonly BasicsStatisticServiceMapper _basicsStatisticService;

        public BasicsStatisticController(BasicsStatisticServiceMapper basicsStatisticService)
        {
            this._basicsStatisticService = basicsStatisticService;
        }

        [HttpPost]
        public IActionResult CreatingBasicStat(BasicStatisticAPI basicStatistic)
        {
            return Ok(_basicsStatisticService.Create(basicStatistic.ToBLL()));
        }

        [HttpGet("id")]
        public IActionResult GetBasicStat(string id)
        {
            return Ok(_basicsStatisticService.GetOne(id));
        }
        [HttpPut("{Id}")]
        public IActionResult UpdateBasicStat(string Id, [FromBody] BasicStatisticAPI basicStatistic)
        {
            BasicStatisticAPI bst = _basicsStatisticService.GetOne(Id).ToAPI();
            if (bst != null)
            {
                bst.Hp = basicStatistic.Hp;
                bst.Atk = basicStatistic.Atk;
                bst.Resistor = basicStatistic.Resistor;
                bst.CriticalRate = basicStatistic.CriticalRate;
                bst.CriticalDamage = basicStatistic.CriticalDamage;
                bst.Def = basicStatistic.Def;
                bst.Precision = basicStatistic.Precision;
                bst.Vit = basicStatistic.Vit;

                _basicsStatisticService.Update(bst.ToBLL());
            }

            return Ok(bst);
        }
    }
}
