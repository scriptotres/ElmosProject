using Slick.Models.Contracts;
using Slick.Models.Skills;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.ComponentModel.DataAnnotations.Schema;

namespace Slick.Models.People
{
    public class Consultant:Person
    {
        public string Email { get; set; }
        public string WorkEmail { get; set; }
        public string Telephone { get; set;}
        public string Mobile { get; set;}

        public virtual IList<ConsultantSpecialisation> Specialisations { get; set; }
        public virtual IList<Contract> Contracts { get; set; }
        [NotMapped]
        public Contract CurrentContract
        {

            get
            {
                if (this.Contracts != null)
                {
                    var query = from c in this.Contracts
                                orderby c.StartDate descending
                                where c.EndDate >= DateTime.Now
                                
                                select c;

                    return query.FirstOrDefault();
                }
                else
                    return null;
            }
            set { }
        }

        //TODO account
    }
}
