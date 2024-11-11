using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Ecommerce_.Data;
using Ecommerce_.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Razor.Language;

namespace Ecommerce_.Controllers
{
    public class PaymentController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<IdentityUser> _userManager;
        public PaymentController(ApplicationDbContext context, UserManager<IdentityUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        public IActionResult Index()
        {
            var pagos =_context.Pagos.ToList();
            return View(pagos);
        }

        public IActionResult PaymentCreate()
        {   
            var userId = _userManager.GetUserName(User);
            var proforma = _context.Proformas.Where(p => p.UserId == userId).ToList();
            if(proforma == null || userId == null)
            {
                return NotFound();
            }
            var total = proforma.Sum(p => p.ProformaQuantity*p.ProductPrice);

            Payment payment= new Payment();
            payment.UserId = userId;
            payment.AmountTotal = total;
            return View(payment);
        }

        [HttpPost]
        public IActionResult PaymentCreate(Payment payment)
        {
            payment.DatePay = DateTime.UtcNow;
            Console.WriteLine(payment.DatePay);
            Console.WriteLine(payment.AmountTotal);
            _context.Pagos.Add(payment);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
    }
}