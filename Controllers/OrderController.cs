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
    public class OrderController : Controller
    {
        private readonly ApplicationDbContext _context;

        public OrderController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var orders = _context.Pedidos.Include(o => o.Payment).ToList();
            return View(orders);
        }

        public IActionResult OrderList(int id)
        {
            var orders = _context.Pedidos.Where(o => o.PaymentId == id).ToList();
            if(orders == null)
            {
                return NotFound();
            }
            return View();
        }
    }
}