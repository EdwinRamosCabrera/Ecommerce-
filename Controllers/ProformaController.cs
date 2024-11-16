using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Ecommerce_.Data;
using Ecommerce_.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Ecommerce_.Controllers
{
    public class ProformaController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<IdentityUser> _userManager;
        public ProformaController(ApplicationDbContext context, UserManager<IdentityUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        public IActionResult Index()
        {
            var userId = _userManager.GetUserName( User);
            if(userId == null)
            {
                return RedirectToAction("CatalogMessage", "Catalog");
            }         
            else
            {   
                var proformas = from o in _context.Proformas select o;
                proformas = proformas.Include(p => p.Product).Where(p => p.UserId.Equals(userId) && p.State.Equals("PENDIENTE")).OrderBy(p => p.ProformaId);

                if(proformas == null)
                {
                    List<Proforma> proforma = new List<Proforma>();
                    return View("Index", proforma);
                }

                return View(proformas);
            }
        }

        public IActionResult ProformaAdd(int id)
        {
            var userId = _userManager.GetUserName(User);

            if(userId == null)
            {
                return RedirectToAction("CatalogMessage", "Catalog");
            }
            else {
                var product = _context.Productos.Find(id);
                if(product == null)
                {
                    return NotFound();
                }
                Proforma proforma = new Proforma();
                proforma.ProductId = product.ProductId;
                proforma.Quantity = 1;
                proforma.UserId = userId;
                proforma.Price = product.Price;
                proforma.State = "PENDIENTE";
                _context.Proformas.Add(proforma);
                _context.SaveChanges();

                return RedirectToAction(nameof(Index));
            }
        }

        public IActionResult ProformaEdit(int id)
        {
            var proforma = _context.Proformas.Include(p => p.Product).Where(p => p.ProformaId == id).FirstOrDefault();
            if(proforma == null)
            {
                return NotFound();
            }
            return View(proforma);
        }

        [HttpPost]
        public IActionResult ProformaEdit(int id, int quantity)
        {
            var proforma = _context.Proformas.Find(id);
            if (proforma == null)
            {
                return NotFound();
            }
            proforma.Quantity = quantity;
            _context.Proformas.Update(proforma);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

        public IActionResult ProformaDelete(int id)
        {   
            var proforma = _context.Proformas.Find(id);
            if(proforma == null)
            {
                return NotFound();
            }
            _context.Proformas.Remove(proforma);
            _context.SaveChanges();

            return RedirectToAction(nameof(Index));
        }

        public IActionResult ProformaMessage()
        {
            return View();
        }
    }
}