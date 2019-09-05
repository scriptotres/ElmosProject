using Slick.Models.Skills;
using System;
using System.Collections.Generic;
using System.Text;

namespace Slick.Repositories.Skills
{
    public interface ISpecialisationLevelRepository
    {
        IEnumerable<SpecialisationLevel> GetAll();
        SpecialisationLevel GetById(Guid id);
        SpecialisationLevel Add(SpecialisationLevel level);
        void Update(SpecialisationLevel level);
        void Delete(SpecialisationLevel level);
    }
}
