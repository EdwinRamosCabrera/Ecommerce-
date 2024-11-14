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
    public class OrderDetailsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public OrderDetailsController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var orderDetails = _context.DetallePedidos.ToList();
            return View(orderDetails);
        }

        public IActionResult OrderDetailsList(int id)
        {
            var orderDetails = _context.DetallePedidos.Include(o => o.Proforma).ThenInclude(p => p.Product).Where(p => p.OrderId == id).ToList();
            return View("Index", orderDetails);
        }
    }
}