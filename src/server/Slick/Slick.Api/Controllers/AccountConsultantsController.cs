using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Slick.Models.Customers;
using Slick.Services.Costumers;
using AutoMapper;

namespace Slick.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountConsultantsController : ControllerBase
    {
        private readonly IAccountConsultantsService service;

        public AccountConsultantsController(IAccountConsultantsService service)
        {
            this.service = service;
        }
        [HttpGet]
        public IActionResult Get()
        {

            return Ok(service.GetAll());
        }

        [HttpGet("{id}")]
        public IActionResult GetById(Guid id)
        {
            return Ok(service.GetById(id));
        }

        [HttpPost]
        public IActionResult Post([FromBody] AccountConsultant account)
        {
            this.service.Add(account);
            if (account.Id == Guid.Empty)
            {
                return StatusCode(500);
            }
            return Ok(account);
        }

        [HttpDelete]
        public IActionResult Delete(AccountConsultant a)
        {
            service.Delete(a);
            return NoContent();
        }

        [HttpPut]
        public IActionResult Put(AccountConsultant a)
        {
            service.Update(a);
            return Ok(a);
        }
    }
}
