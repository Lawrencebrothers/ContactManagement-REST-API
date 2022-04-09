using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ContactManagementAPI.Controllers;
using ContactManagementAPI.Models;
using Microsoft.AspNetCore.Mvc;
using ContactManagementAPI.Services;


namespace ContactManagementAPI.Controllers
    {

   [ApiController]
    [Route("[controller]")]
    public class ContactController : ControllerBase
    {
        public ContactController()
        {
            
            
        }
       
[HttpGet]
        public ActionResult<List<ContactDirectory>> GetAll()
        {
          return  contactService.GetAll();
        }

        [HttpGet("{id}")]
        public ActionResult<ContactDirectory> Get(int id)
        {
            var contact = contactService.Get(id);
            if (contact == null)
            
                return NotFound();

           
            return contact;

        }
        [HttpPost]
        public IActionResult Create(ContactDirectory contact
            )
        {
            contactService.Add(contact);
            return CreatedAtAction(nameof(Create), new { id = contact.Id }, contact);
        }

       [ HttpPut("{id}")]
public IActionResult Update(int id, ContactDirectory contact)
        {
            if (id != contact.Id)
                return BadRequest();

            var existingContact = contactService.Get(id);
            if (existingContact is null)
                return NotFound();

            contactService.Update(contact);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var contact = contactService.Get(id);

            if (contact is null)
                return NotFound();

           contactService.Delete(id);

            return NoContent();
        }

    }

}

