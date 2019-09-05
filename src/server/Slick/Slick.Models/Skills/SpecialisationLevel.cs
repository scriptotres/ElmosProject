using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Slick.Models.Skills
{
    public class SpecialisationLevel:BaseEntity
    {
        [Required]
        public string Title { get; set; }
        public string Description { get; set; }
        public int Weight { get; set; }
        public bool IsDeleted { get; set; }
    }
}
