﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace PhoneBook.API.Models.ORM.Entities
{
    public class ContactInfo : Base
    {
        public string Phone { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public string Content { get; set; }

        public int ContactId { get; set; }

        [ForeignKey("ContactId")]
        public Contact Contact { get; set; }



    }
}
