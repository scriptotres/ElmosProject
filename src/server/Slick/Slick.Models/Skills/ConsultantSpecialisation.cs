using Slick.Models.People;
using System;
using System.Collections.Generic;
using System.Text;

namespace Slick.Models.Skills
{
    public class ConsultantSpecialisation:BaseEntity
    {
        public Guid ConsultantId { get; set; }
        public virtual Consultant Consultant { get; set; }
        public Guid SpecialisationId { get; set; }
        public virtual Specialisation Specialisation { get; set; }
    }
}
