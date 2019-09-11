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

        public string ContractTypeTitle { get; set; }
        public DateTime StartDate { get; set; }
        public string Date { get; set; }

        public DateTime? EndDate { get; set; }
        public DateTime? SignedDate { get; set; }
        public decimal SellingPrice { get; set; }
        public decimal PurchasePrice { get; set; }
        public string Commentary { get; set; }
        public decimal Margin { get; set; }
        public decimal MarginPercent { get; set; }
        public Guid ConsultantId { get; set; }
        public string DocumentUrl { get; set; }
        public decimal Salary { get; set; }
    }
}
