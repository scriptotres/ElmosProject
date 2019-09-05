using Slick.Models.Skills;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace Slick.Services.Skills
{
    public interface ISpecialisationLevelService
    {
        IEnumerable<SpecialisationLevel> GetAll();
        SpecialisationLevel GetById(Guid iD);
        IQueryable<SpecialisationLevel> FindBy(Expression<Func<SpecialisationLevel, bool>> predicate);
        IQueryable<SpecialisationLevel> GetAllIncluding(params Expression<Func<SpecialisationLevel, object>>[] includeProperties);
        void Update(SpecialisationLevel level);
        void Delete(SpecialisationLevel level);
        SpecialisationLevel Add(SpecialisationLevel level);
    }
}
