using PhoneBook.API.Models.ORM.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PhoneBook.API.Models.VM
{
    public class ContactListVM
    {

        public int ID { get; set; }
        public string name { get; set; }
        public string surname { get; set; }
        public string firm { get; set; }
        public List<ContactInfo> contactInfos { get; set; }
    }
}
