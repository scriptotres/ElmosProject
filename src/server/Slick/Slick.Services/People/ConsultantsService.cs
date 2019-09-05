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


namespace Slick.Services.People
{
    public class ConsultantsService : IConsultantService
    {
        private readonly IEntityRepository<Consultant> repo;
       // private IEntityRepository<Address> addrRepo;



        public ConsultantsService(IEntityRepository<Consultant> repo)
            //IEntityRepository<Address> adrrepo)
        {
            //this.addrRepo = adrrepo;
            this.repo = repo;
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
            //var address = obj.Address;
            //var a = new Address()
            //{
            //    City = address.City,
            //    Number = address.City,
            //    Street = address.Street,
            //    Zip = address.Zip,
            //    Id = address.Id
            //};

            // addrRepo.Update(a);
            // addrRepo.Update(obj.address);
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

    }
}
