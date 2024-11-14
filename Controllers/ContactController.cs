using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using Ecommerce_.Data;
using Ecommerce_.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Razor.Language;

namespace Ecommerce_.Controllers
{
    public class ContactController : Controller
    {   
        private readonly ApplicationDbContext _context;

        public ContactController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {   
            var contactos = _context.Contactos.OrderBy(c => c.ContactId).ToList();
            return View(contactos);
        }

        public IActionResult ContactCreate()
        {   
            return View();
        }

        [HttpPost]
        public IActionResult ContactCreate(Contact contact)
        {   
            if(!ModelState.IsValid){
                return View(contact);
            }
            else {
                _context.Contactos.Add(contact);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
        }

        public IActionResult ContactEdit(int id)
        {
            Contact? contact = _context.Contactos.Find(id);   
            if(contact == null){
                return NotFound();
            }
            return View(contact);
        }

        [HttpPost]
        public IActionResult ContactEdit(int id, [Bind("ContactId, ContactName, ContactLastName, ContactEmail, ContactPhone, ContactMessage")] Contact updateContact)
        {   
            var contactExisting = _context.Contactos.Find(id);   
            if(contactExisting == null){
                return NotFound();
            }
            contactExisting.Name = updateContact.Name;
            contactExisting.Name = updateContact.LastName;
            contactExisting.Email = updateContact.Email;
            contactExisting.Phone = updateContact.Phone;
            contactExisting.Message = updateContact.Message;
  
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

        public IActionResult ContactDelete(int id)
        {   
            Contact? contact = _context.Contactos.Find(id);
            if(contact == null){
                return NotFound();
            }
            _context.Contactos.Remove(contact);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
    }
}