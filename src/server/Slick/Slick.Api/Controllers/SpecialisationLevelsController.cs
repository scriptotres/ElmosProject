using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Slick.Models.Skills;
using Slick.Services.Skills;

namespace Slick.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SpecialisationLevelsController : ControllerBase
    {
        private readonly ISpecialisationLevelService specLevelService;

        public SpecialisationLevelsController(ISpecialisationLevelService specLevelService)
        {
            this.specLevelService = specLevelService;
        }
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(specLevelService.GetAll());
        }
        [HttpGet("{id}")]
        public IActionResult Get(Guid id)
        {
            var sl = specLevelService.GetById(id);
            if (sl == null) return Ok("helloworld");
            return Ok(sl);
        }
        [HttpPost]
        public IActionResult Post([FromBody]SpecialisationLevel level)
        {
            var newLevel = specLevelService.Add(level);
            return Ok(newLevel);
        }
        [HttpDelete]
        public IActionResult Delete(SpecialisationLevel level)
        {
            specLevelService.Delete(level);
            return NoContent();
        }

        [HttpPut]
        public IActionResult Put(SpecialisationLevel level)
        {
            specLevelService.Update(level);
            return Ok(level);
        }
    }
}