using Slick.Models.People;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Slick.Models.Contracts
{
    public class Contract:BaseEntity
    {
        public Guid ContractTypeId { get; set; }
        public virtual ContractType ContractType { get; set; }
        public Guid ContractId { get; set; }
        public virtual Consultant Consultant { get; set; }

        [Required]
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public DateTime? SignedDate { get; set; }

        public string DocumentUrl { get; set; }
        public decimal Salary { get; set; }
        public Guid ConsultantId { get; set; }

        public override string ToString()
        {
            return $"{this.Consultant} - {this.StartDate}-{this.EndDate}";
        }

    }
}
