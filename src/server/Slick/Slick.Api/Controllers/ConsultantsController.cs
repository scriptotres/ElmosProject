﻿using System;
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
using Slick.Models.Customers;
using Slick.Services.Costumers;

namespace Slick.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ConsultantsController : ControllerBase
    {
        private readonly IConsultantService service;
        private IContractService contractService;
        private readonly ApplicationDBContext entitiesContext;
        private readonly IEmployeeService employeeService;
        private readonly IAccountService accountService;

        public ConsultantsController(IConsultantService service,
            IEmployeeService employeeService, 
            IContractService contractService,
            IAccountService accountService,
            ApplicationDBContext entitiesContext)
        {
            this.service = service;
            this.contractService = contractService;
            this.entitiesContext = entitiesContext;
            this.employeeService = employeeService;
            this.accountService = accountService;
        }


        //[controller] 
        //string sort gaat sorteren op fistname filter gaat filteren value is waarde voor filter
        // -->       ?sort=lastname&filter=lastname&value=de%20bielde
        [HttpGet]
        [AllowAnonymous]
        public IActionResult Get([FromQuery]string sort)
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
            entitiesContext.Consultants.Include(Consultant => Consultant.Employee).ToList();
            entitiesContext.Consultants.Include(Consultant => Consultant.Account).ToList();
            entitiesContext.Contracts.Include(contracts => contracts.ContractType).ToList();

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
               
                EmployeeId = c.Employee == null ? Guid.Empty : c.Employee.Id,

                AccountId = c.Account == null ? Guid.Empty : c.Account.Id

            };

            if (c.Employee != null)
            {
                var employee = this.employeeService.GetById(consultant.EmployeeId);
                consultant.Employee = new EmployeeDto()
                {
                    Id = employee.Id,
                    Lastname = employee.Lastname,
                    Firstname = employee.Firstname,
                    Email = employee.Email,
                    Telephone = employee.Telephone
                };
            }
            if (c.Account != null)
            {
                var account = this.accountService.GetById(consultant.AccountId);
                consultant.Account = new AccountDto()
                {
                    Id=account.Id,
                    CompanyName = account.CompanyName,
                    VatNumber = account.VatNumber
                };
            }

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
                    Id = cont.Id,
                    ConsultantId = cont.ConsultantId,
                    ContractTypeId = cont.ContractTypeId,
                    ContractTypeTitle = cont.ContractType.Title
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

            EmployeeDto emp = new EmployeeDto();
            AccountDto acc = new AccountDto();

            IList<Contract> contract = new List<Contract>();

            foreach (var contr in cDTO.Contracts)
            {
                var contracttype = new ContractType()
                {
                    Title = contr.ContractTypeTitle,
                    Id = contr.ContractTypeId
                };
                contract.Add(new Contract
                {

                    EndDate = contr.EndDate,
                    StartDate = contr.StartDate,
                    DocumentUrl = contr.DocumentUrl,
                    Salary = contr.Salary,
                    SignedDate = contr.SignedDate,
                    Id = contr.Id,
                    ConsultantId = cDTO.Id,
                    ContractTypeId = contracttype.Id,
                    ContractType = contracttype

                });
            }

            var address = new Address()
            {
                City = cDTO.City,
                Number = cDTO.Number,
                Street = cDTO.Street,
                Zip = cDTO.Zip,
                Country = cDTO.Country,
                Id = cDTO.AddressId

            };

            if (cDTO.Account != null)
            {
                var account = new AccountDto()
                {
                    CompanyName = cDTO.Account.CompanyName,
                    VatNumber = cDTO.Account.VatNumber,
                    Id = cDTO.AccountId

                };
                acc = account;
            }
            else if (cDTO.AccountId != null)
            {
                var account = new AccountDto()
                {
                    Id = cDTO.AccountId
                };
                acc = account;
            }

                if (cDTO.Employee != null)
            {
                var employee = new EmployeeDto()
                {
                    Firstname = cDTO.Employee.Firstname,
                    Email = cDTO.Employee.Email,
                    Telephone = cDTO.Employee.Telephone,
                    Lastname = cDTO.Employee.Lastname,
                    Id = cDTO.EmployeeId

                };
                emp = employee;
            }

            else if (cDTO.EmployeeId!= null)
            {
                var employee = new EmployeeDto()
                {
                    Id = cDTO.EmployeeId,
                    
                };

                 emp = employee;
            }


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

                EmployeeId = cDTO.EmployeeId == null ? Guid.Empty : emp.Id,

                AccountId = cDTO.Account == null ? Guid.Empty : acc.Id,

                Contracts = contract
            };



            Guid id = consultant.Id;
            service.Update(consultant);
            return Ok(cDTO);
        }

    }
}