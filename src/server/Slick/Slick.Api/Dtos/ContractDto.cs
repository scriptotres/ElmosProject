using Slick.Models.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Slick.Api.Dtos
{
    public class ContractDto
    {
        public Guid Id { get; set; }
        public Guid ContractTypeId { get; set; }

        public ContractType ContractType { get; set; }
        public string ContractTypeTitle { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public DateTime? SignedDate { get; set; }

        public Guid ConsultantId { get; set; }
        public string DocumentUrl { get; set; }
        public decimal Salary { get; set; }
    }
}
