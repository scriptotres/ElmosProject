using Slick.Models.Customers;
using Slick.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using System.Text;

namespace Slick.Services.Costumers
{
    public class AccountsService : IAccountService
    {
        private readonly IEntityRepository<Account> repo;

        public AccountsService(IEntityRepository<Account> repo)
        {
            this.repo = repo;
        }

        public Account Add(Account a)
        {
            return repo.Add(a);
        }

        public void Delete(Account a)
        {
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

        public void Update(Account a)
        {
            repo.Update(a);
        }
    }
}
