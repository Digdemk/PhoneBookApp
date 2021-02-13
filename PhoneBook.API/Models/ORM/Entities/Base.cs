using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PhoneBook.API.Models.ORM.Entities
{
    public class Base
    {
        public int Id { get; set; }

        private bool _isDeleted = false;
        public bool IsDeleted
        {
            get
            {
                return _isDeleted;
            }
            set
            {
                _isDeleted = value;
            }
        }

        public DateTime AddDate { get; set; } = DateTime.Now;


    }
}
