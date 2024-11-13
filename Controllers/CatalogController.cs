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
using Microsoft.AspNetCore.Identity;

namespace Ecommerce_.Controllers
{
    public class CatalogController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<IdentityUser> _userManager;

        public CatalogController(ApplicationDbContext context, UserManager<IdentityUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        public ActionResult Index()
        {
           var products = _context.Productos.ToList();
            return View(products);
        }

        public ActionResult CatalogList()
        {
           var products = _context.Productos.Include(p => p.Category).OrderBy(c => c.Id).ToList();
            return View(products);
        }

        public ActionResult CatalogCreate()
        {   
            ViewBag.Category = _context.Categorias.Select(c => new SelectListItem(c.Name, c.Id.ToString()));
            return View();
        }

        [HttpPost]
        public ActionResult CatalogCreate(Product product)
        {   
            ViewBag.Category = _context.Categorias.Select(c => new SelectListItem(c.Name, c.Id.ToString()));
                       if(!ModelState.IsValid)
            {   
                foreach (var entry in ModelState)
                {
                    var fieldName = entry.Key;  // Nombre del campo que falló la validación
                    var state = entry.Value;
                    // Recorre todos los errores asociados a ese campo
                    foreach (var error in state.Errors)
                    {
                        var errorMessage = error.ErrorMessage;  // Mensaje de error que describe qué falló
                        Console.WriteLine($"Error en el campo {fieldName}: {errorMessage}");
                    }
                }
                return View();
            }
            _context.Productos.Add(product);
            _context.SaveChanges();
            return RedirectToAction(nameof(CatalogList));
        }

        public IActionResult CatalogEdit(int id)
        {   
            var product = _context.Productos.Find(id);
            if(product == null)
            {
                return NotFound();
            }
            ViewBag.Category = _context.Categorias.Select(c => new SelectListItem(c.Name, c.Id.ToString()));
            return View(product);
        }

        [HttpPost]
        public IActionResult CatalogEdit(int id, [Bind("ProductId", "ProductCode", "ProductName", "ProductImage", "ProductDescription", "ProductPrice", "ProductStatus", "CategoryId" )] Product product)
        {   
            var productExisting = _context.Productos.Find(id);
            if(productExisting == null)
            {
                return NotFound();
            }
            ViewBag.Category = _context.Categorias.Select(c => new SelectListItem(c.Name, c.Id.ToString()));
            productExisting.Id = product.Id;
            productExisting.Code = product.Code;
            productExisting.Name = product.Name;
            productExisting.Image = product.Image;
            productExisting.Description = product.Description;
            productExisting.Price = product.Price;
            productExisting.State = product.State;
            productExisting.CategoryId = product.CategoryId;

            _context.SaveChangesAsync();
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

        public async Task<IActionResult> CatalogCar(int Id)
        {
            Product? product = await _context.Productos.FindAsync(Id);
            if(product == null)
            {
                return NotFound();
            }
            return View(product);
        }

        [HttpPost]
        public IActionResult CatalogCar(int Id, int quantity)
        {
            var userId = _userManager.GetUserName(User);
            if(userId == null)
            {
                Console.WriteLine("No hay usuario");
                return RedirectToAction(nameof(CatalogMessage));
            }
            
                var product = _context.Productos.Find(Id);
                if(product == null)
                {
                    return NotFound();
                }
                    
                Proforma proforma = new Proforma();
                proforma.ProductId = product.Id;
                proforma.Quantity = quantity;
                proforma.UserId = userId;
                proforma.Price = product.Price;
                proforma.State = "PENDIENTE";
                _context.Proformas.Add(proforma);
                _context.SaveChanges();
                return RedirectToAction("Index", "Proforma");
        }

        public IActionResult CatalogMessage()
        {
            return View();
        }
    }
}