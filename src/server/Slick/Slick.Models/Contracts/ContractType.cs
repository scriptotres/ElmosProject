using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Slick.Models.Contracts
{
    public class ContractType : BaseEntity
    {
        [Required]
        public string Title { get; set; }
        public bool IsDeleted { get; set; }
        public override string ToString()
        {
            return this.Title;
        }
    }
}
