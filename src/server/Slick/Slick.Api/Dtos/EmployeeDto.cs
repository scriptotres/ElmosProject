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
        public Guid Id { get; set; }
    }
}
