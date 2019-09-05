using Slick.Models.People;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace Slick.Services.People
{
   public interface IEmployeeService
    {
        IEnumerable<Employee> GetAll();
        IEnumerable<Employee> GetAll(string sort);
        Employee GetById(Guid id);
        void Update(Employee c);
        void Delete(Employee c);
        Employee Add(Employee c);
        IEnumerable<Employee> FindBy(Expression<Func<Employee, bool>> predicate);
        IEnumerable<Employee> FindByFirstName(string firstname);
        IEnumerable<Employee> FindByFirstName(string firstname, string sort);
        IEnumerable<Employee> FindByLastName(string lastname);
        IEnumerable<Employee> FindByLastName(string lastname, string sort);
    }
}
