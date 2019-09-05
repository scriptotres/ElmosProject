using Slick.Models.People;
using Slick.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using System.Text;

namespace Slick.Services.People
{
    public class EmployeesService : IEmployeeService
    {
        private readonly IEntityRepository<Employee> repo;

        public EmployeesService(IEntityRepository<Employee> repo)
        {
            this.repo = repo;
        }

        public Employee Add(Employee e)
        {
            return repo.Add(e);
        }

        public void Delete(Employee e)
        {
            repo.Delete(e);
        }

        public IEnumerable<Employee> FindBy(Expression<Func<Employee, bool>> predicate)
        {
            return repo.FindBy(predicate);
        }

        public IEnumerable<Employee> FindByFirstName(string firstname)
        {
            return this.repo.FindBy(c => c.Firstname == firstname).ToList();
        }

        public IEnumerable<Employee> FindByFirstName(string firstname, string sort)
        {
            if (string.IsNullOrEmpty(sort)) sort = "firstname";//default sort is firstname
            return this.repo.FindBy(c => c.Firstname == firstname).OrderBy(sort).ToList();

        }

        public IEnumerable<Employee> FindByLastName(string lastname)
        {
            return this.repo.FindBy(c => c.Lastname == lastname).ToList();

        }

        public IEnumerable<Employee> FindByLastName(string lastname, string sort)
        {
            if (string.IsNullOrEmpty(sort)) sort = "firstname";//default sort is firstname
            return this.repo.FindBy(c => c.Lastname == lastname).OrderBy(sort).ToList();

        }

        public IEnumerable<Employee> GetAll()
        {
            return repo.GetAll();
        }

        public IEnumerable<Employee> GetAll(string sort)
        {
            if (string.IsNullOrEmpty(sort)) sort = "firstname";//default sort is firstname
            return this.repo.GetAll().OrderBy(sort).ToList();
        }

        public Employee GetById(Guid id)
        {
            return repo.GetById(id);
        }

        public void Update(Employee e)
        {
            repo.Update(e);
        }
    }
}
