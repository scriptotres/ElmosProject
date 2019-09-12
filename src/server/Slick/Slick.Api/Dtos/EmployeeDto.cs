using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Slick.Api.Dtos
{
    public class EmployeeDto
    {
        public string Email { get; set; }
        public string Telephone { get; set; }
        public string Lastname { get; set; }
        public string Firstname { get; set; }
        public DateTime Birthdate { get; set; }
        public string Street { get; set; }
        public string Number { get; set; }
        public string Zip { get; set; }
        public string Country { get; set; }
        public string City { get; set; }
        public Guid Id { get; set; }
        public IList<ConslutantDto> consultants { get; set; }

    }
}
