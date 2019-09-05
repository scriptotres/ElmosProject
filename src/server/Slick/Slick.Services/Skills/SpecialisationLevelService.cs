using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using Slick.Models.Skills;
using Slick.Repositories;
using Slick.Repositories.Skills;

namespace Slick.Services.Skills
{
    public class SpecialisationLevelService : ISpecialisationLevelService
    {
        private readonly IEntityRepository<SpecialisationLevel> repo;

        public SpecialisationLevelService(IEntityRepository<SpecialisationLevel> repo)
        {
            this.repo = repo;
        }
        public SpecialisationLevel Add(SpecialisationLevel level)
        {
            return repo.Add(level);
        }

        public void Delete(SpecialisationLevel level)
        {
            level.IsDeleted = true;
            repo.Update(level);
        }

        public IQueryable<SpecialisationLevel> FindBy(Expression<Func<SpecialisationLevel, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<SpecialisationLevel> GetAll()
        {
            return repo.GetAll().Where(sl=>sl.IsDeleted==false).ToList();
        }

        public IQueryable<SpecialisationLevel> GetAllIncluding(params Expression<Func<SpecialisationLevel, object>>[] includeProperties)
        {
            throw new NotImplementedException();
        }

        public SpecialisationLevel GetById(Guid id)
        {
            return repo.GetById(id);
        }

        public void Update(SpecialisationLevel level)
        {
            repo.Update(level);
        }
    }
}
