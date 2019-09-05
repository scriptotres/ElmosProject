using Slick.Models.People;
using System;
using System.Collections.Generic;
using System.Text;

namespace Slick.Models.Customers
{
    public class AccountManager : BaseEntity
    {
        public virtual Employee Employee { get; set; }
        public Guid EmployeeId { get; set; }
        public Guid AccountId { get; set; }
        public virtual Account Account { get; set; }
        public bool IsActive { get; set; }
    }
}
