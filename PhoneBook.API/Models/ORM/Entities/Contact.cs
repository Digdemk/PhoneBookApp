using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PhoneBook.API.Models.ORM.Entities
{
    public class Contact : Base
    {
        public string Name { get; set; }

        public string Surname { get; set; }

        public string Firm { get; set; }

        public List<ContactInfo> ContactInfos { get; set; }



    }
}
