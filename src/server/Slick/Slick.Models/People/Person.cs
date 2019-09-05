using Slick.Models.Contact;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Slick.Models.People
{
    public abstract class Person :BaseEntity
    {
        [Required]
        public string Firstname { get; set; }
        [Required]
        public string Lastname { get; set; }
        public string Middlename { get; set; }

        [DisplayFormat(DataFormatString = "{0:dd.MM.yyyy}")]
        public DateTime Birthdate { get; set; }

        public Guid AddressId { get; set; }
        public virtual Address Address { get; set; }
        public bool IsDeleted { get; set; } = false;

        public override string ToString()
        {
            return $"{this.Firstname} {this.Lastname}";
        }
    }
}
