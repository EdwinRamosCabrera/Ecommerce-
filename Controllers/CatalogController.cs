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
           var products = _context.Productos.Include(p => p.Category).OrderBy(c => c.ProductId).ToList();
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
            ViewBag.Category = _context.Categorias.Select(c => new SelectListItem(c.CategoryName, c.CategoryId.ToString()));
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
            ViewBag.Category = _context.Categorias.Select(c => new SelectListItem(c.CategoryName, c.CategoryId.ToString()));
            productExisting.ProductId = product.ProductId;
            productExisting.ProductCode = product.ProductCode;
            productExisting.ProductName = product.ProductName;
            productExisting.ProductImage = product.ProductImage;
            productExisting.ProductDescription = product.ProductDescription;
            productExisting.ProductPrice = product.ProductPrice;
            productExisting.ProductStatus = product.ProductStatus;
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
            Console.WriteLine(Id);
            var userId = _userManager.GetUserName(User);
            if(userId == null)
            {
                Console.WriteLine("No hay usuario");
                return RedirectToAction(nameof(CatalogMessage));
            }
            
                Console.WriteLine("Bienvenido");
                var product = _context.Productos.Find(Id);
                
                Proforma proforma = new Proforma();
                proforma.ProductId = product.ProductId;
                proforma.ProformaQuantity = quantity;
                proforma.UserId = userId;
                _context.Proformas.Add(proforma);
                _context.SaveChanges();
                Console.WriteLine("Añadido al carrito");
                return RedirectToAction("Index", "Proforma");
            
        }

        public IActionResult CatalogMessage()
        {
            return View();
        }

    }
}