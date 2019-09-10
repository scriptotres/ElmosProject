using Slick.Models.Contact;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Slick.Api.Dtos
{
    public class AccountDto
    {
        public string CompanyName { get; set; }
        public string VatNumber { get; set; }
        public string Street { get; set; }
        public string TelephoneNumber { get; set; }
        public string Number { get; set; }
        public string Zip { get; set; }
        public string Country { get; set; }
        public string City { get; set; }
        public Guid Id { get; set; }
        public Guid AddressId { get; set; }
    }
}
