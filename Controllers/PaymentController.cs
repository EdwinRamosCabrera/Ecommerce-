using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Ecommerce_.Data;
using Ecommerce_.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Razor.Language;
using Microsoft.EntityFrameworkCore;

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
            var payment =_context.Pagos.OrderBy(p => p.PaymentId).ToList();
            return View(payment);
        }

        public IActionResult PaymentCreate()
        {   
            var userId = _userManager.GetUserName(User);
            var proforma = _context.Proformas.Where(p => p.UserId == userId && p.State == "PENDIENTE").ToList();
            if(proforma == null || userId == null)
            {
                return NotFound();
            }
            var total = proforma.Sum(p => p.Quantity * p.Price);

            Payment payment= new Payment();
            payment.UserId = userId;
            payment.AmountTotal = total;
            return View(payment);
        }

        [HttpPost]
        public IActionResult PaymentCreate(string name, string lastName, string email, string phone, string address, Payment payment)
        {
            payment.DatePay = DateTime.UtcNow;
            Console.WriteLine(payment.DatePay);
            Console.WriteLine(payment.AmountTotal);
            _context.Pagos.Add(payment);
            _context.SaveChanges();

            Order order = new Order();
            order.PaymentId = payment.PaymentId;
            order.UserId = payment.UserId;
            order.AmountTotal = payment.AmountTotal;
            order.State = "PENDIENTE";
            order.Name = name;
            order.LastName = lastName;
            order.Email = email;
            order.Phone = phone;
            order.Address = address;
            _context.Pedidos.Add(order);
            _context.SaveChanges();

            var proforma = _context.Proformas.Include(p => p.Product).Where(p => p.UserId == payment.UserId).ToList();
            foreach(var item in proforma)
            {
                item.State = "PROCESADO";
                _context.SaveChanges();

                OrderDetails orderDetails = new OrderDetails();
                orderDetails.OrderId = order.OrderId;
                orderDetails.ProformaId = item.ProformaId;
                orderDetails.Name = item.Product.Name;
                orderDetails.Quantity = item.Quantity;
                orderDetails.Price = item.Price;
                _context.DetallePedidos.Add(orderDetails);
                _context.SaveChanges();
            }

            return RedirectToAction("Index", "Home");
        }

        public IActionResult PaymentEdit(int id)
        {
            var payment =_context.Pagos.Find(id);
            return View(payment);
        }

        [HttpPost]
        public IActionResult PaymentEdit(int id, Payment paymentUpdate)
        {
            var payment =_context.Pagos.Find(id);
            if(payment == null)
            {
                return NotFound();
            }
            payment.NameCard = paymentUpdate.NameCard;
            payment.Observations = paymentUpdate.Observations;
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

        public IActionResult PaymentDelete(int id)
        {
            var payment =_context.Pagos.Find(id);
            if(payment == null)
            {
                return NotFound();
            }
            _context.Pagos.Remove(payment);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }

    
}