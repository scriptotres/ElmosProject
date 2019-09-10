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
        private readonly ApplicationDBContext entitiesContext;

        public EmployeesController(IEmployeeService service, ApplicationDBContext entitiesContext)
        {
            this.service = service;
            
            this.entitiesContext = entitiesContext;

        }

    [HttpGet]
        public IActionResult Get()
        {
            IList<EmployeeDto> employees = new List<EmployeeDto>();
            IEnumerable<Employee> employeesfromdatabase = service.GetAll();
            entitiesContext.Employees.Include(emp => emp.Address).ToList();

            service.GetAll();
            foreach (var e in employeesfromdatabase)
            {
                employees.Add(new EmployeeDto()
                {
                    City = e.Address?.City,
                    Country = e.Address?.Country,
                    Number = e.Address?.Number,
                    Street = e.Address?.Street,
                    Zip = e.Address?.Zip,

                    Firstname = e.Firstname,
                    Lastname = e.Lastname,
                    Telephone = e.Telephone,
                    Email = e.Email,
                    Birthdate=e.Birthdate,

                    Id = e.Id
                });
            }
            return Ok(employees);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(Guid id)
        {
            var e = service.GetById(id);
            if (e != null)
            {
                var employee = new EmployeeDto()
                {
                    Firstname = e.Firstname,
                    Lastname = e.Lastname,
                    Telephone = e.Telephone,
                    Email = e.Email
                };
                return Ok(employee);
            }
            return Ok(null);
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