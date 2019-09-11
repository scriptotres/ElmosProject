using Slick.Database;
using Slick.Models.Contact;
using Slick.Models.Customers;
using Slick.Models.People;
using Slick.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Slick.Services.Costumers
{
    public class AccountsService : IAccountService
    {
        private readonly IEntityRepository<Account> repo;
        private readonly IEntityRepository<Consultant> consultantrepo;
        private readonly ApplicationDBContext databaseconnection;
        private readonly IEntityRepository<Address> addrRepo;

        public AccountsService(IEntityRepository<Account> repo, IEntityRepository<Address> addrRepo, IEntityRepository<Consultant> consultantRepo, ApplicationDBContext entitiesContext)
        {
            this.repo = repo;
            this.consultantrepo = consultantRepo;
            this.databaseconnection = entitiesContext;
            this.addrRepo = addrRepo;
        }

        public Account Add(Account a)
        {
            return repo.Add(a);
        }

        public void Delete(Account a)
        {
            var consultants = consultantrepo.GetAll().ToList();
            
      //      IList<Consultant> consultantlist = consultants;
            foreach (var c in consultants)
            {
                if (c.AccountId == a.Id)
                {
                    c.AccountId = null;
                    c.Account = null;
                    consultantrepo.Update(c);
                }
                else if (c.AccountId != a.Id)
                    Console.WriteLine("consultant bevat Account niet");

            }
              repo.Delete(a);

        }

        public IEnumerable<Account> FindBy(Expression<Func<Account, bool>> predicate)
        {
            return repo.FindBy(predicate);
        }

        public IEnumerable<Account> GetAll()
        {
            return repo.GetAll();
        }

        //public IEnumerable<Account> GetAll(string sort)
        //{

        //    return this.repo.GetAll().OrderBy(sort).ToList();
        //}

        public Account GetById(Guid id)
        {
            return repo.GetById(id);
        }

        public void Update(Account obj)
        {
            var addr = obj.Address;
            var address = new Address()
            {
                City = addr.City,
                Number = addr.Number,
                Street = addr.Street,
                Zip = addr.Zip,
                Id = addr.Id,
                Country = addr.Country
            };
            addrRepo.Update(addr);
            repo.Update(obj);
        }
    }
}
