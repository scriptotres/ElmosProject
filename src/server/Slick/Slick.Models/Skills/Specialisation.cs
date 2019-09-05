using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Slick.Models.Skills
{
    public class Specialisation:BaseEntity
    {
        [Required]
        public string Title { get; set; }
        public string Description { get; set; }
        public bool IsDeleted { get; set; } = false;

        public virtual IList<ConsultantSpecialisation> Consultant { get; set; }

        public Guid SpecialisationLevelId { get; set; }
        public virtual SpecialisationLevel SpecialisationLevel { get; set; }

        public override string ToString()
        {
            return $"{this.Title}";
        }
    }
}
