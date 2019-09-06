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
        public string lastname { get; set; }
        public string firstname { get; set; }
        public Guid id { get; set; }
    }
}
