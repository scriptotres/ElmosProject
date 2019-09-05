using Slick.Models.Customers;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace Slick.Services.Costumers
{
    public interface IAccountConsultantsService
    {
        IEnumerable<AccountConsultant> GetAll();
        IEnumerable<AccountConsultant> GetAll(string sort);
        AccountConsultant GetById(Guid id);
        void Update(AccountConsultant c);
        void Delete(AccountConsultant c);
        AccountConsultant Add(AccountConsultant c);
        IEnumerable<AccountConsultant> FindBy(Expression<Func<AccountConsultant, bool>> predicate);
    }
}
