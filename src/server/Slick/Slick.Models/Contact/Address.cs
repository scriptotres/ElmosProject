﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Slick.Models.Contact
{
    public class Address:BaseEntity
    {
        public string Street { get; set; }
        public string Number { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public int Zip { get; set; }
    }
}
