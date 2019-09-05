using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Slick.Database;
using Slick.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace Slick.Repositories
{
    public class EntityRepository<T> : IEntityRepository<T> where T : BaseEntity, new()
    {
        private readonly ApplicationDBContext entitiesContext;

        public EntityRepository(ApplicationDBContext entitiesContext)
        {
            this.entitiesContext = entitiesContext;
        }
        public T Add(T obj)
        {
            entitiesContext.Set<T>().Add(obj);
            entitiesContext.SaveChanges();

            return obj;
        }

        public void Delete(T obj)
        {
            EntityEntry dbEntity = entitiesContext.Entry(obj);
            dbEntity.State = EntityState.Deleted;
            entitiesContext.SaveChanges();

        }

        public IQueryable<T> GetAll()
        {
            entitiesContext.Employees.Include(c => c.Address).ToList();
           // entitiesContext.Consultants.Include(c => c.Address).ToList();

            return entitiesContext.Set<T>();

        }

        public IQueryable<T> FindBy(Expression<Func<T,bool>> predicate)
        {
            return entitiesContext.Set<T>().Where(predicate);
        }

        public T GetById(Guid id)
        {
            var item = GetAll().Where(s => s.Id == id).SingleOrDefault();
            
            return item;
        }

        public IQueryable<T> GetAllIncluding(params Expression<Func<T, object>>[]includeProperties)
        {
            IQueryable<T> query = entitiesContext.Set<T>();
            foreach (var includeProperty in includeProperties)
            {
                query = query.Include(includeProperty);
            }
            return query;
        }

        public void Update(T obj)
        {

            EntityEntry dbEntity = entitiesContext.Entry<T>(obj);
            dbEntity.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            entitiesContext.SaveChanges();
        }
    }
}
