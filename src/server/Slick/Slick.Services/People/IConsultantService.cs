using Slick.Models.People;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace Slick.Services.People
{
    public interface IConsultantService
    {
        IEnumerable<Consultant> GetAll();
        IEnumerable<Consultant> GetAll(string sort);
        Consultant GetById(Guid id);
        void Update(Consultant c);
        void Delete(Consultant c);
        Consultant Add(Consultant c);
        IEnumerable<Consultant> FindBy(Expression<Func<Consultant, bool>> predicate);
        IEnumerable<Consultant> FindByFirstName(string firstname);
        IEnumerable<Consultant> FindByFirstName(string firstname, string sort);
        IEnumerable<Consultant> FindByLastName(string lastname);
        IEnumerable<Consultant> FindByLastName(string lastname, string sort);
    }
}
