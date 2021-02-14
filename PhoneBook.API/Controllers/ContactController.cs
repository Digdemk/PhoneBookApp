using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PhoneBook.API.Models.ORM.Context;
using PhoneBook.API.Models.ORM.Entities;
using PhoneBook.API.Models.VM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PhoneBook.API.Controllers
{

    [ApiController]
    public class ContactController : ControllerBase
    {

        private readonly PhoneBookContext _phoneBookContext;
        public ContactController(PhoneBookContext phoneBookContext)
        {
            _phoneBookContext = phoneBookContext;
        }


        [Route("Contact")]
        [HttpGet]
        public List<ContactListVM> GetContactList()
        {
            var contacts = _phoneBookContext.Contacts.Where(q => !q.IsDeleted).Select(q => new ContactListVM()
            {
                ID = q.Id,
                name = q.Name,
                surname = q.Surname,
                firm = q.Firm,
                contactInfos = q.ContactInfos.Where(q => q.IsDeleted ==false).ToList()


            }).ToList();

            return contacts;
        }

        //[Route("Contact/Add")]
        //[HttpPost]

        //public IActionResult AddContact([FromForm] Contact contact)
        //{
        //    try
        //    {
        //        _eCommerceContext.Add(category);
        //        _eCommerceContext.SaveChanges();
        //        return Ok(category);
        //    }
        //    catch (Exception)
        //    {

        //        return BadRequest();
        //    }
        //}

        [Route("Contact/Add")]
        [HttpPost]
        public IActionResult Add([FromForm] ContactAddVM contactadd)
        {

            if (ModelState.IsValid)
            {
                Contact contact = new Contact();
                contact.Name = contactadd.name;
                contact.Surname = contactadd.surname;
                contact.Firm = contactadd.firm;
               
            

                _phoneBookContext.Contacts.Add(contact);
                _phoneBookContext.SaveChanges();

                contactadd.ID = contact.Id;

                return Ok(contactadd);
            }
            else
            {
                return BadRequest(ModelState.Values);
            }

        }







    }



}
