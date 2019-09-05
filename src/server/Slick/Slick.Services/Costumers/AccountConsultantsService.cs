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
    public class AccountConsultantsService : IAccountConsultantsService
    {
        private readonly IEntityRepository<AccountConsultant> repo;

        public AccountConsultantsService(IEntityRepository<AccountConsultant> repo)
        {
            this.repo = repo;
        }
        public AccountConsultant Add(AccountConsultant a)
        {
            return repo.Add(a);
        }

        public void Delete(AccountConsultant a)
        {
            repo.Delete(a);
        }

        public IEnumerable<AccountConsultant> FindBy(Expression<Func<AccountConsultant, bool>> predicate)
        {
            return repo.FindBy(predicate);
        }

        public IEnumerable<AccountConsultant> GetAll()
        {
            return repo.GetAll();
        }

        public IEnumerable<AccountConsultant> GetAll(string sort)
        {
            return this.repo.GetAll().OrderBy(sort).ToList();
        }

        public AccountConsultant GetById(Guid id)
        {
            return repo.GetById(id);
        }

        public void Update(AccountConsultant a)
        {
            repo.Update(a);
        }
    }
}
