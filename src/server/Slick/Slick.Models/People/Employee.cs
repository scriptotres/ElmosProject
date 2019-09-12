using System;
using System.Collections.Generic;
using System.Text;

namespace Slick.Models.People
{
    public class Employee:Person
    {
        public string Email { get; set; }
        public string Telephone { get; set; }

        public virtual IList<Consultant> Consultant { get; set; }
    }
}
