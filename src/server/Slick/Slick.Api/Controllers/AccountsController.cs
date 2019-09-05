using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Slick.Api.Dtos;
using Slick.Models.Customers;
using Slick.Services.Costumers;

namespace Slick.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountsController : ControllerBase
    {
        private readonly IAccountService service;

        public AccountsController(IAccountService service)
        {
            this.service = service;
        }

        [HttpGet]
        public IActionResult Get()
        {
            service.GetAll();
            IList<AccountDto> account = new List<AccountDto>();
            IEnumerable<Account> accountfromthedatabase = service.GetAll();
            
            foreach (var a in accountfromthedatabase)
            {
                account.Add(new AccountDto()
                {
                    City = a.Address?.City,
                    CompanyName = a.CompanyName,
                    Street = a.Address?.City,
                    Number = a.Address?.Number,
                    id=a.Id
                });
            }
            return Ok(account);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(Guid id)
        {
            var a = service.GetById(id);
            var accountsdto = new AccountDto()
            {
                CompanyName = a.CompanyName
            };
            return Ok(accountsdto);
        }

        [HttpPost]
        public IActionResult Post([FromBody] Account account)
        {
            this.service.Add(account);
            if (account.Id == Guid.Empty)
            {
                return StatusCode(500);
            }
            return Ok(account);
        }

        [HttpDelete]
        public IActionResult Delete(Account a)
        {
            service.Delete(a);
            return NoContent();
        }

        [HttpPut]
        public IActionResult Put(Account a)
        {
            service.Update(a);
            return Ok(a);
        }
    }
}
