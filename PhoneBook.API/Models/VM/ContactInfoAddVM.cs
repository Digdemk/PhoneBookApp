using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PhoneBook.API.Models.VM
{
    public class ContactInfoAddVM
    {

        [Required]
        public string phone { get; set; }

        [Required]
        public string eMail { get; set; }

        [Required]
        public string address { get; set; }

        [Required]
        public string content { get; set; }

        [Required]
        public int ContactId { get; set; }

    }
}
