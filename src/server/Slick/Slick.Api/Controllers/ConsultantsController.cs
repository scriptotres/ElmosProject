using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Slick.Database;
using Slick.Models.People;
using Slick.Repositories;
using Slick.Services;
using Slick.Services.People;
using System.Linq.Dynamic.Core;
using Slick.Api.Dtos;
using Slick.Services.Contracts;
using Slick.Models.Contracts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;
using Slick.Models.Contact;


namespace Slick.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ConsultantsController : ControllerBase
    {
        private readonly IConsultantService service;
        private IContractService contractService;
        private readonly ApplicationDBContext entitiesContext;
        private Contract contracts;


        public ConsultantsController(IConsultantService service, IContractService contractService, ApplicationDBContext entitiesContext)
        {
            this.service = service;
            this.contractService = contractService;
            this.entitiesContext = entitiesContext;
        }


        //[controller] 
        //string sort gaat sorteren op fistname filter gaat filteren value is waarde voor filter
        // -->       ?sort=lastname&filter=lastname&value=de%20bielde
        [HttpGet]
        [AllowAnonymous]
        public IActionResult Get([FromQuery]string sort, [FromQuery] string filter, [FromQuery] string value)
        {
            IList<ConslutantDto> consultants = new List<ConslutantDto>();
            IEnumerable<Consultant> consultantsfromDB = new List<Consultant>();
            entitiesContext.Consultants.Include(Consultant => Consultant.Address).ToList();

            service.GetAll(sort);

            foreach (var c in consultantsfromDB)// zorgt ervoor dat enkel onderstaande properties worden getoont!!!
            {
                consultants.Add(new ConslutantDto()
                {
                    Firstname = c.Firstname,
                    Lastname = c.Lastname,
                    Email = c.Email,
                    WorkEmail = c.WorkEmail,
                    Telephone = c.Telephone,
                    Street = c.Address?.Street,
                    Number = c.Address?.Number,
                    City = c.Address?.City,
                    Zip = c.Address.Zip,

                });
            }

            return Ok(service.GetAll(sort));
        }

        //[controller]/id
        [HttpGet("{id}")]
        public IActionResult Get(Guid id)
        {
            entitiesContext.Consultants.Include(Consultant => Consultant.Address).ToList();
            var c = service.GetById(id);
            if (c == null) return NotFound();
            var consultant = new ConslutantDto()
            {

                Firstname = c.Firstname,
                Lastname = c.Lastname,
                Email = c.Email,
                WorkEmail = c.WorkEmail,
                Telephone = c.Telephone,
                Mobile = c.Mobile,
                Birthdate = c.Birthdate,
                AddressId = c.Address.Id,
                Street = c.Address?.Street,
                Number = c.Address?.Number,
                Country = c.Address?.Country,
                City = c.Address?.City,
                Zip = c.Address.Zip,

            };

            var contractFromDB = this.contractService.GetContractForConsultants(id);


            consultant.Contracts = new List<ContractDto>();
            foreach (Contract cont in contractFromDB)
            {
                consultant.Contracts.Add(new ContractDto
                {
                    EndDate = cont.EndDate,
                    StartDate = cont.StartDate,
                    DocumentUrl = cont.DocumentUrl,
                    Salary = cont.Salary,
                    SignedDate = cont.SignedDate,
                    contractId = cont.Id,
                    ContractType = cont.ContractType
                });

            }
            return Ok(consultant);
        }

        [HttpPost]
        public IActionResult Post([FromBody]Consultant c)
        {
            this.service.Add(c);
            if (c.Id == Guid.Empty)
            {
                return StatusCode(500);
            }
            return Ok(c);
        }
        [HttpDelete]
        public IActionResult Delete([FromBody] Consultant c)
        {
            service.Delete(c);
            return NoContent();
        }

        [HttpPut]
        public IActionResult Put(ConslutantDto cDTO)
        {
            
            var currentcontract = new Contract()
            {
                EndDate = cDTO.CurrentContract.EndDate,
                StartDate = cDTO.CurrentContract.StartDate,
                DocumentUrl = cDTO.CurrentContract.DocumentUrl,
                Salary = cDTO.CurrentContract.Salary,
                SignedDate = cDTO.CurrentContract.SignedDate,
                Id = cDTO.CurrentContract.contractId,
                ContractId = cDTO.CurrentContract.contractId,
                ConsultantId=cDTO.Id, //moet dit??
                ContractType = cDTO.CurrentContract.ContractType

                //TODO Kevin: er is een contractId en een id van baseentity? database updaten dat contractid wegvalt of?
            };
                //geen contracten in put omdat deze niet aangepast moeten worden in de App

            var address = new Address()
            {
                City = cDTO.City,
                Number = cDTO.Number,
                Street = cDTO.Street,
                Zip = cDTO.Zip,
                Country = cDTO.Country,
                Id = cDTO.AddressId

            };
            var consultant = new Consultant()
            {
                Id = cDTO.Id,
                Firstname = cDTO.Firstname,
                Lastname = cDTO.Lastname,
                Birthdate = cDTO.Birthdate,
                Email = cDTO.Email,
                WorkEmail = cDTO.WorkEmail,
                Mobile = cDTO.Mobile,
                Telephone = cDTO.Telephone,

                Address = address,
                AddressId = address.Id,
                CurrentContract= currentcontract

                //    CurrentContract=currentcontract


            };



            //TODO: Adress en contract saven??
            Guid id = consultant.Id;
            service.Update(consultant);
            return Ok(consultant);
        }

        //[HttpGet]
        //public IActionResult FindBy()
        //{
        //    return Ok(service.FindBy(c=> c.Firstname=="jonan"));
        //}

    }
}