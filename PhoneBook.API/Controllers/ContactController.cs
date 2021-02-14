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


        [Route("Contact/{id}")]
        [HttpGet]
        public IActionResult GetContact(int id)
        {
            var contact = _phoneBookContext.Contacts.Where(q => !q.IsDeleted).FirstOrDefault(q => q.Id == id);

            if (contact != null)
            {
                ContactListVM contactList = new ContactListVM();

                contactList.ID = contact.Id;
                contactList.name = contact.Name;
                contactList.surname = contact.Surname;
                contactList.firm = contact.Firm;
                contactList.contactInfos = contact.ContactInfos.Where(q => q.IsDeleted == false).ToList();

                return Ok(contactList);


            }

            else
            {
                return BadRequest("There is no contact with that id!");
            }


        }


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

        [Route("Contact/Delete")]
        [HttpPost]
        public IActionResult Delete([FromForm] ContactDeleteVM contactDelete)
        {
            Contact contact = _phoneBookContext.Contacts.Find(contactDelete.ID);

            if (contact != null)
            {
                contact.IsDeleted = true;
                _phoneBookContext.SaveChanges();

                return Ok(contact);

            }

            else
            {
                return BadRequest("There is no contact with that id!");
            }
        }

        [Route("ContactInfo/Add")]
        [HttpPost]
        public IActionResult Add([FromForm] ContactInfoAddVM infoadd)
        {
            if (ModelState.IsValid)
            {
                ContactInfo contactInfo = new ContactInfo();
                contactInfo.Phone = infoadd.phone;
                contactInfo.Email = infoadd.eMail;
                contactInfo.Address = infoadd.address;
                contactInfo.Content = infoadd.content;
                contactInfo.ContactId = infoadd.ContactId;

                _phoneBookContext.ContactInfos.Add(contactInfo);
                _phoneBookContext.SaveChanges();

                infoadd.ContactId = contactInfo.ContactId;

                return Ok(infoadd);

            }
            else
            {
                return BadRequest(ModelState.Values);
            }
        }

        [Route("ContactInfo/Delete")]
        [HttpPost]
        public IActionResult Delete([FromForm] ContactInfoDeleteVM infoDelete)
        {
            ContactInfo contactinfo = _phoneBookContext.ContactInfos.Find(infoDelete.ID);

            if (contactinfo != null)
            {
                contactinfo.IsDeleted = true;
                _phoneBookContext.SaveChanges();

                return Ok(contactinfo);

            }

            else
            {
                return BadRequest("There is no information with that id!");
            }
        }







    }



}
