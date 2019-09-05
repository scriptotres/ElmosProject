using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Slick.Api.Dtos;
using Slick.Database;
using Slick.Models.People;
using Slick.Services.People;

namespace Slick.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        private readonly IEmployeeService service;

        public EmployeesController(IEmployeeService service)
        {
            this.service = service;
        }

        [HttpGet]
        public IActionResult Get([FromQuery]string sort, [FromQuery] string filter, [FromQuery] string value)
        {

                return Ok(service.GetAll(sort));
        }

        [HttpGet("{id}")]
        public IActionResult GetById(Guid id)
        {
            var e = service.GetById(id);
            var employee = new EmployeeDto()
            {
                lastname = e.Firstname,
                Telephone = e.Telephone,
                Email = e.Email
            };
            return Ok(employee);

        }

        [HttpPost]
        public IActionResult Post([FromBody] Employee employee)
        {
            this.service.Add(employee);
            if (employee.Id == Guid.Empty)
            {
                return StatusCode(500);
            }
            return Ok(employee);
        }

        [HttpDelete]
        public IActionResult Delete(Employee e)
        {
            service.Delete(e);
            return NoContent();
        }

        [HttpPut]
        public IActionResult Put(Employee e)
        {
            service.Update(e);
            return Ok(e);
        }
    }
}