using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Ecommerce_.Data;
using Ecommerce_.Models;
using Microsoft.AspNetCore.Mvc;

namespace Ecommerce_.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CategoryController(ApplicationDbContext context)
        {
            _context = context;
        }

        public ActionResult Index()
        {   
            var categorias = _context.Categorias.OrderBy(c => c.CategoryId).ToList();
            return View(categorias);
        }

        public ActionResult CategoryCreate()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CategoryCreate(Category category)
        {   
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

                return View(category);
            }
            _context.Categorias.Add(category);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

        public ActionResult CategoryEdit(int id)
        {   
            Category? category = _context.Categorias.FirstOrDefault(c => c.CategoryId == id);
            if(category == null)
            {
                return NotFound();
            }
            return View(category);
        }

        [HttpPost]
        public ActionResult CategoryEdit(Category category)
        {   
            _context.Update(category);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));

        }

        public ActionResult CategoryDelete(int id)
        {
            Category? category = _context.Categorias.Find(id);
            if(category == null)
            {
                return NotFound();
            }
            _context.Remove(category);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
        
    }   
}