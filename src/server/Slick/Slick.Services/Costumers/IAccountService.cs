using Slick.Models.Customers;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace Slick.Services.Costumers
{
    public interface IAccountService
    {
        IEnumerable<Account> GetAll();
       // IEnumerable<Account> GetAll(string sort);
        Account GetById(Guid id);
        void Update(Account a);
        void Delete(Account a);
        Account Add(Account a);
        IEnumerable<Account> FindBy(Expression<Func<Account, bool>> predicate);
    }
}

