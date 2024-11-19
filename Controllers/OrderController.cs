using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using Ecommerce_.Data;
using Ecommerce_.Models;
using Microsoft.AspNetCore.DataProtection.AuthenticatedEncryption.ConfigurationModel;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace Ecommerce_.Controllers
{
    public class OrderController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<IdentityUser> _userManager;

        public OrderController(ApplicationDbContext context, UserManager<IdentityUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        public IActionResult Index()
        {
            var userId = _userManager.GetUserName(User);
            var orders = _context.Pedidos.Include(o => o.Payment).Where(o => o.UserId.Equals(userId)).ToList();
            return View(orders);
        }

        public IActionResult OrderList()
        {
            var orders = _context.Pedidos.OrderBy(o => o.OrderId).ToList();
            return View(orders);
        }

        public IActionResult OrderView(int id)
        {
            var order = _context.Pedidos.Find(id);
            if(order == null)
            {
                return NotFound();
            }
            List<Order> orders = new List<Order>();
            orders.Add(order);
            return View("OrderList", orders);
        }

        public IActionResult OrderEdit(int id)
        {
            var order = _context.Pedidos.Find(id);
            return View(order);
        }

        [HttpPost]
        public IActionResult OrderEdit(int id, Order orderUpdate)
        {
            _context.Update(orderUpdate);
            _context.SaveChanges();
            return RedirectToAction(nameof(OrderList));
        }

        public IActionResult OrderDelete(int id)
        {   
            var order = _context.Pedidos.Find(id);
            if (order == null)
            { 
                return NotFound();
            }
            _context.Pedidos.Remove(order);
            _context.SaveChanges();
            return RedirectToAction(nameof(OrderList));
        }
    }
}