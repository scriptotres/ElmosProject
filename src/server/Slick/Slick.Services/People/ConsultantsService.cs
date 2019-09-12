using Slick.Models.People;
using Slick.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Linq.Dynamic.Core;
using Slick.Models.Contact;
using Slick.Database;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore;
using Slick.Models.Contracts;
using Slick.Services.Contracts;

namespace Slick.Services.People
{
    public class ConsultantsService : IConsultantService
    {
        private readonly IEntityRepository<Consultant> repo;
        private readonly IContractService contractService;
        private IEntityRepository<Address> addrRepo;



        public ConsultantsService(IEntityRepository<Consultant> repo, IEntityRepository<Address> adrrepo, IContractService contractService)
        {
            this.addrRepo = adrrepo;
            this.repo = repo;
            this.contractService = contractService;
        }
        public Consultant Add(Consultant c)
        {
            return repo.Add(c);
        }

        public void Delete(Consultant c)
        {
            c.IsDeleted = true;
            repo.Delete(c);
        }


        public IEnumerable<Consultant> FindBy(Expression<Func<Consultant, bool>> predicate)
        {
            return repo.FindBy(predicate);
        }


        public IEnumerable<Consultant> GetAll()
        {
            return repo.GetAll().Where(sl => sl.IsDeleted == false);
        }

        public IEnumerable<Consultant> GetAll(string sort)
        {
            if (string.IsNullOrEmpty(sort)) sort = "firstname";//default sort is firstname
            return this.repo.GetAll().OrderBy(sort).ToList();
        }

        public Consultant GetById(Guid id)
        {
            return repo.GetById(id);
        }

        public void Update(Consultant obj)
        {

            var address = obj.Address;
            var a = new Address()
            {
                City = address.City,
                Number = address.Number,
                Street = address.Street,
                Zip = address.Zip,
                Id = address.Id,
                Country=address.Country
            };

            var currentcontract = obj.CurrentContract;
            var cc = new Contract()
            {
                DocumentUrl = currentcontract.DocumentUrl,
                Id = currentcontract.Id,
                EndDate = currentcontract.EndDate,
                Salary = currentcontract.Salary,
                SellingPrice=currentcontract.SellingPrice,
                PurchasePrice=currentcontract.PurchasePrice,
                Commentary=currentcontract.Commentary,
                SignedDate = currentcontract.SignedDate,
                StartDate = currentcontract.StartDate,
                Consultant = obj,
                ConsultantId = currentcontract.ConsultantId,
                ContractType = currentcontract.ContractType,
                ContractTypeId = currentcontract.ContractTypeId
            };

            contractService.Update(cc);
            addrRepo.Update(a);
            repo.Update(obj);
        }

        public IEnumerable<Consultant> FindByFirstName(string firstname)
        {
            return this.repo.FindBy(c => c.Firstname == firstname).ToList();
        }
        public IEnumerable<Consultant> FindByFirstName(string firstname,string sort)
        {
            if (string.IsNullOrEmpty(sort)) sort = "firstname";//default sort is firstname
            return this.repo.FindBy(c => c.Firstname == firstname).OrderBy(sort).ToList();
        }
        public IEnumerable<Consultant> FindByLastName(string lastname)
        {
            return this.repo.FindBy(c => c.Lastname == lastname).ToList();
        }
        public IEnumerable<Consultant> FindByLastName(string lastname, string sort)
        {
            if (string.IsNullOrEmpty(sort)) sort = "lastname";//default sort is firstname
            return this.repo.FindBy(c => c.Lastname == lastname).OrderBy(sort).ToList();
        }

           IEnumerable<Consultant> IConsultantService.GetConsultantsForEmployees(Guid employeeId)
        {
            return this.repo.FindBy(c => c.EmployeeId == employeeId).OrderBy(c => c.Lastname).ToList();

        }
    }
}
