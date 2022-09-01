using LaboBackEnd.MapperAPI;
using LaboBackEnd.ModelsAPI;
using LaboBLL.ModelsBLL;
using LaboBLL.ServicesBLL;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LaboBackEnd.Controllers
{
    [Route("api/[Equipment]")]
    [ApiController]
    public class EquipmentController : ControllerBase
    {
        private readonly EquipmentServiceMapper _equipmentServiceMapper;

        public EquipmentController(EquipmentServiceMapper equipmentServiceMapper)
        {
            this._equipmentServiceMapper = equipmentServiceMapper;
        }


        [HttpPost]
        public IActionResult CreateEquipment(EquipmentAPI equipment)
        {
            return Ok(_equipmentServiceMapper.Create(equipment.ToBLL()));
        }

        [HttpGet("{id}")]
        public IActionResult GetOneEquipment(string id)
        {
            return Ok(_equipmentServiceMapper.GetOne(id));
        }

        [HttpGet]
        public IActionResult GetAllEquipment()
        {
            return Ok(_equipmentServiceMapper.GetAll());
        }

        [HttpPut("id")]
        public IActionResult UpdateEquipment(string id, [FromBody] EquipmentAPI equipment)
        {
            EquipmentBLL eq = _equipmentServiceMapper.GetOne(id);
            if (eq != null)
            {
                eq.NbPartsRequired = equipment.NbPartsRequired;
                eq.Effect = equipment.Effect;
                eq.Type = equipment.Type;
                
                _equipmentServiceMapper.Update(eq);
            }
            return Ok(eq.ToAPI());
        }

    }
}
