using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PhoneBook.API.Models.ORM.Entities
{
    public class Base
    {
        public int Id { get; set; }
        public bool _isDeleted { get; set; }
    

    }
}
