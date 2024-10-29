using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using Ecommerce_.Data;
using Ecommerce_.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace Ecommerce_.Controllers
{
    public class CatalogController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CatalogController(ApplicationDbContext context)
        {
            _context = context;
        }

        public ActionResult Index()
        {
           var products = _context.Productos.ToList();
            return View(products);
        }

        public ActionResult CatalogList()
        {
           var products = _context.Productos.Include(p => p.Category).ToList();
            return View(products);
        }

        public ActionResult CatalogCreate()
        {   
            ViewBag.Category = _context.Categorias.Select(c => new SelectListItem(c.CategoryName, c.CategoryId.ToString()));
            return View();
        }

        [HttpPost]
        public ActionResult CatalogCreate(Product product)
        {   
            ViewBag.Category = _context.Categorias.Select(c => new SelectListItem(c.CategoryName, c.CategoryId.ToString()));
            product.ProductCreationDate = DateTime.Now.ToUniversalTime();
            _context.Productos.Add(product);
            _context.SaveChanges();
            return RedirectToAction(nameof(CatalogList));
        }

        public async Task<IActionResult> CatalogEdit(int id)
        {   
            var product = _context.Productos.Find(id);
            if(product == null)
            {
                return NotFound();
            }
            _context.Productos.Update(product);
            await _context.SaveChangesAsync();
            return View(product);
        }

        [HttpPost]
        public async Task<IActionResult> CatalogEdit(Product product)
        {   
            _context.Productos.Update(product);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(CatalogList));
        }

        public async Task<IActionResult> CatalogDelete(int id)
        {
            var product = _context.Productos.Find(id);
            if(product == null)
            {
                return NotFound();
            }
            _context.Productos.Remove(product);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(CatalogList));
        }
    }
}