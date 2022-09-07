﻿using LaboBackEnd.MapperAPI;
using LaboBackEnd.ModelsAPI;
using LaboBLL.ModelsBLL;
using LaboBLL.ServicesBLL;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LaboBackEnd.Controllers
{
    //[Authorize]
    [ApiController]
    [Route("AffinityChamp")]
    public class AffinityChampController : ControllerBase
    {
        private readonly AffinityChampServiceMapper _affinityChampServiceMapper;

        public AffinityChampController(AffinityChampServiceMapper affinityChampService)
        {
            this._affinityChampServiceMapper = affinityChampService;
        }

        [HttpPost]
        public IActionResult AffinityChampCreating(AffinityChampAPI affinityChamp)
        {
           return Ok ( _affinityChampServiceMapper.Create(affinityChamp.ToBLL()));

        }

        [HttpGet("{id}")]
        public IActionResult GetAffinityChamp(string id)
        {
            
            return Ok(_affinityChampServiceMapper.GetOne(id));
        }

        [HttpPut("{id}")]
        public IActionResult UpdateAffinityChamp(string id, [FromBody] AffinityChampAPI affinityChamp)
        {
            AffinityChampBLL afc = _affinityChampServiceMapper.GetOne(id);

            if (afc != null)
            {
                afc.IdAffinityChamp = affinityChamp.IdAffinityChamp;
                afc.Weak = affinityChamp.Weak;
                afc.Strong = affinityChamp.Strong;
                _affinityChampServiceMapper.Update(afc);
            }
            return Ok(afc.ToAPI());
        }

    }
}
