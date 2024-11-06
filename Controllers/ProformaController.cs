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
                var proformas = _context.Proformas.Where(p => p.UserId == userId).Include(p => p.Product).ToList();
                if(proformas.Count == 0)
                {
                    return View();
                }
                return View(proformas);
            }
        }

        public IActionResult ProformaAdd(int id)
        {
            var userId = _userManager.GetUserName(User);
            if(userId == null)
            {
                Console.WriteLine("No hay usuario");
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
                proforma.ProformaQuantity = 1;
                proforma.UserId = userId;
                _context.Proformas.Add(proforma);
                _context.SaveChanges();
                Console.WriteLine("Añadido al carrito");
                return RedirectToAction(nameof(Index));
            }
        }

        public IActionResult ProformaMessage()
        {
            return View();
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
    }
}