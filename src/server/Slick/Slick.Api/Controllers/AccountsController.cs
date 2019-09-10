using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Slick.Api.Dtos;
using Slick.Database;
using Slick.Models.Customers;
using Slick.Services.Costumers;

namespace Slick.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountsController : ControllerBase
    {
        private readonly ApplicationDBContext entitiesContext;
        private readonly IAccountService service;

        public AccountsController(IAccountService service, ApplicationDBContext entitiesContext)
        {
            this.service = service;
            this.entitiesContext = entitiesContext;
        }

        [HttpGet]
        public IActionResult Get()
        {

            IList<AccountDto> account = new List<AccountDto>();
            IEnumerable<Account> accountfromthedatabase = service.GetAll();
            entitiesContext.Accounts.Include(acc => acc.Address).ToList();

            service.GetAll();
            foreach (var a in accountfromthedatabase)
            {
                account.Add(new AccountDto()
                {
                    CompanyName = a.CompanyName,
                    VatNumber = a.VatNumber,
                    City = a.Address?.City,
                    Street = a.Address?.Street,
                    Country = a.Address?.Country,
                    Zip = a.Address?.Zip,
                    Number = a.Address?.Number,

                    Id = a.Id
                });
            }
            return Ok(account);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(Guid id)
        {
            entitiesContext.Accounts.Include(Accounts => Accounts.Address).ToList();

            if (id != Guid.Empty && id != null)
            {
                var a = service.GetById(id);
                var accountsdto = new AccountDto()
                {
                    CompanyName = a.CompanyName,
                    VatNumber = a.VatNumber,
                    Zip = a.Address?.Zip,
                    City = a.Address?.City,
                    Country = a.Address?.Country,
                    Street = a.Address?.Street,
                    Number = a.Address?.Number,
                    TelephoneNumber=a.TelephoneNumber
                    

                };
                return Ok(accountsdto);
            }
            else
                return Ok(null);
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
