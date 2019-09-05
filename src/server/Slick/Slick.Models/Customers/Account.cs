using Slick.Models.Contact;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Slick.Models.Customers
{
    public class Account:BaseEntity
    {
        [Required]
        public string CompanyName { get; set; }
        public string VatNumber { get; set; }
        public string TelephoneNumber { get; set; }
        public Address Address { get; set; }
        public virtual IList<AccountManager> AccountManagers { get; set; }

    }
}
