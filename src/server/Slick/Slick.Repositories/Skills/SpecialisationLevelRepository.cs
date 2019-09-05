using System;
using System.Collections.Generic;
using System.Text;
using Slick.Database;
using Slick.Models.Skills;
using System.Linq;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.AspNetCore.Mvc;
using System.Linq.Expressions;

namespace Slick.Repositories.Skills
{
    public class SpecialisationLevelRepository : IEntityRepository<SpecialisationLevel>
    {
        private readonly ApplicationDBContext entetiesContext;

        public SpecialisationLevelRepository(ApplicationDBContext entitiesContext)
        {
            this.entetiesContext = entitiesContext;
        }
        public SpecialisationLevel Add(SpecialisationLevel level)
        {
            entetiesContext.Set<SpecialisationLevel>().Add(level);
            entetiesContext.SaveChanges();

            return level;
        }

        public void Delete(SpecialisationLevel level)
        {
            EntityEntry dbEntity = entetiesContext.Entry<SpecialisationLevel>(level);
            dbEntity.State = Microsoft.EntityFrameworkCore.EntityState.Deleted;
            entetiesContext.SaveChanges();

        }

        public IQueryable<SpecialisationLevel> FindBy(Expression<Func<SpecialisationLevel, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public IQueryable<SpecialisationLevel> GetAll()
        {
            var items = entetiesContext.Set<SpecialisationLevel>();

            return items;
        }

        public IQueryable<SpecialisationLevel> GetAllIncluding(params Expression<Func<SpecialisationLevel, object>>[] includeProperties)
        {
            throw new NotImplementedException();
        }

        public SpecialisationLevel GetById(Guid id)
        {
            var item = GetAll().Where(s => s.Id == id).SingleOrDefault();

            return item;
        }

        public void Update(SpecialisationLevel level)
        {
            EntityEntry dbEntity = entetiesContext.Entry(level);
            dbEntity.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            entetiesContext.SaveChanges();
        }
    }
}
