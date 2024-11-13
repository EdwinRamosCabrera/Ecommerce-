using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Ecommerce_.Data;
using Ecommerce_.Models;
using Microsoft.AspNetCore.Mvc;

namespace Namespace
{
    public class OrderController : Controller
    {
        public IActionResult Index()
        {
            
            return View();
        }
    }
}

namespace Ecommerce_.Controllers
{
    public class OrderController : Controller
    {
        private readonly ApplicationDbContext _context;

        public OrderController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var order = _context.Pedidos.ToList();
            return View(order);
        }
    }
}